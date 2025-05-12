using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using  System.Net.NetworkInformation;
using Microsoft.Win32;
using System.Collections;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Management;

namespace tianaliser
{
    public partial class FormTiAnalyzer : Form
    {
        public FormTiAnalyzer()
        {
            InitializeComponent();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            this.Text += Application.ProductVersion;
            lblMac.Text += getMacAddress();
            lblSerialWindows.Text += GetWindowsProductKey();
            lblWindowsVersion.Text += Environment.OSVersion.ToString();
            lblWinVersion.Text += getOSInfo();
            if (InternalCheckIsWow64())
            {
                lblBits.Text += "64 BITS";
            }
            else { lblBits.Text += "32 BITS"; }
            DisplayTotalRam(lblMemory);
            getHDS();
            lblUser.Text = "NOME USUARIO: " + Environment.UserName + " MAQUINA NOME :  " + Environment.MachineName + " NOME DOMINIO: " + Environment.UserDomainName;
            ProcessorAndMotherBoard();
            lblMotherBoardProcessor.Text += " NUCLEOS : " + Environment.ProcessorCount;
            lblDriverRom.Text += DetectedDriverRom();
        }

        //Get Version Windows Simplify
        private string getOSInfo()
        {
            //Get Operating system information.
            OperatingSystem os = Environment.OSVersion;
            //Get version information about the os.
            Version vs = os.Version;

            //Variable to hold our return value
            string operatingSystem = "";

            if (os.Platform == PlatformID.Win32Windows)
            {
                //This is a pre-NT version of Windows
                switch (vs.Minor)
                {
                    case 0:
                        operatingSystem = "95";
                        break;
                    case 10:
                        if (vs.Revision.ToString() == "2222A")
                            operatingSystem = "98SE";
                        else
                            operatingSystem = "98";
                        break;
                    case 90:
                        operatingSystem = "Me";
                        break;
                    default:
                        break;
                }
            }
            else if (os.Platform == PlatformID.Win32NT)
            {
                switch (vs.Major)
                {
                    case 3:
                        operatingSystem = "NT 3.51";
                        break;
                    case 4:
                        operatingSystem = "NT 4.0";
                        break;
                    case 5:
                        if (vs.Minor == 0)
                            operatingSystem = "2000";
                        else
                            operatingSystem = "XP";
                        break;
                    case 6:
                        if (vs.Minor == 0)
                            operatingSystem = "Vista";
                        else
                            operatingSystem = "7";
                        break;
                    default:
                        break;
                }
            }
            //Make sure we actually got something in our OS check
            //We don't want to just return " Service Pack 2" or " 32-bit"
            //That information is useless without the OS version.
            if (operatingSystem != "")
            {
                //Got something.  Let's prepend "Windows" and get more info.
                operatingSystem = "Windows " + operatingSystem;
                //See if there's a service pack installed.
                if (os.ServicePack != "")
                {
                    //Append it to the OS name.  i.e. "Windows XP Service Pack 3"
                    operatingSystem += " " + os.ServicePack;
                }
                //Append the OS architecture.  i.e. "Windows XP Service Pack 3 32-bit"
                //operatingSystem += " " + getOSArchitecture().ToString() + "-bit";
            }
            //Return the information we've gathered.
            return operatingSystem;
        }

        //Get MAC ADRESS
        private static String getMacAddress()
        {
            return (from nic in NetworkInterface.GetAllNetworkInterfaces()
                    where nic.OperationalStatus == OperationalStatus.Up
                    select nic.GetPhysicalAddress().ToString()
                          ).FirstOrDefault();
        }

        //Get Serial Windows
        #region
        public static string GetWindowsProductKey()
        {
            //var key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine,
            //                              RegistryView.Default);
            //const string keyPath = @"Software\Microsoft\Windows NT\CurrentVersion";
            //var digitalProductId = (byte[])key.OpenSubKey(keyPath).GetValue("DigitalProductId");
            
            if (InternalCheckIsWow64())
            {
                 var baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
                 var reg = baseKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", false);

                 var digitalProductId = reg.GetValue("DigitalProductId") as byte[];

                 var isWin8OrUp =
                     (Environment.OSVersion.Version.Major == 6 && System.Environment.OSVersion.Version.Minor >= 2)
                     ||
                     (Environment.OSVersion.Version.Major > 6);

                 var productKey = isWin8OrUp ? DecodeProductKeyWin8AndUp(digitalProductId) : DecodeProductKey(digitalProductId);
                 return productKey;
            }
            else {
                 var baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
                 var reg = baseKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", false);

                 var digitalProductId = reg.GetValue("DigitalProductId") as byte[];

                 var isWin8OrUp =
                     (Environment.OSVersion.Version.Major == 6 && System.Environment.OSVersion.Version.Minor >= 2)
                     ||
                     (Environment.OSVersion.Version.Major > 6);

                 var productKey = isWin8OrUp ? DecodeProductKeyWin8AndUp(digitalProductId) : DecodeProductKey(digitalProductId);
                 return productKey;
            }

            
        }
        
        public static string DecodeProductKeyWin8AndUp(byte[] digitalProductId)
        {
            var key = String.Empty;
            const int keyOffset = 52;
            var isWin8 = (byte)((digitalProductId[66] / 6) & 1);
            digitalProductId[66] = (byte)((digitalProductId[66] & 0xf7) | (isWin8 & 2) * 4);

            // Possible alpha-numeric characters in product key.
            const string digits = "BCDFGHJKMPQRTVWXY2346789";
            int last = 0;
            for (var i = 24; i >= 0; i--)
            {
                var current = 0;
                for (var j = 14; j >= 0; j--)
                {
                    current = current * 256;
                    current = digitalProductId[j + keyOffset] + current;
                    digitalProductId[j + keyOffset] = (byte)(current / 24);
                    current = current % 24;
                    last = current;
                }
                key = digits[current] + key;
            }
            var keypart1 = key.Substring(1, last);
            const string insert = "N";
            key = key.Substring(1).Replace(keypart1, keypart1 + insert);
            if (last == 0)
                key = insert + key;
            for (var i = 5; i < key.Length; i += 6)
            {
                key = key.Insert(i, "-");
            }
            return key;
        }
                
        public static string DecodeProductKey(byte[] digitalProductId)
        {
            // Offset of first byte of encoded product key in 
            //  'DigitalProductIdxxx" REG_BINARY value. Offset = 34H.
            const int keyStartIndex = 52;
            // Offset of last byte of encoded product key in 
            //  'DigitalProductIdxxx" REG_BINARY value. Offset = 43H.
            const int keyEndIndex = keyStartIndex + 15;
            // Possible alpha-numeric characters in product key.
            char[] digits = new char[]
      {
        'B', 'C', 'D', 'F', 'G', 'H', 'J', 'K', 'M', 'P', 'Q', 'R', 
        'T', 'V', 'W', 'X', 'Y', '2', '3', '4', '6', '7', '8', '9',
      };
            // Length of decoded product key
            const int decodeLength = 29;
            // Length of decoded product key in byte-form.
            // Each byte represents 2 chars.
            const int decodeStringLength = 15;
            // Array of containing the decoded product key.
            char[] decodedChars = new char[decodeLength];
            // Extract byte 52 to 67 inclusive.
            ArrayList hexPid = new ArrayList();
            for (int i = keyStartIndex; i <= keyEndIndex; i++)
            {
                hexPid.Add(digitalProductId[i]);
            }
            for (int i = decodeLength - 1; i >= 0; i--)
            {
                // Every sixth char is a separator.
                if ((i + 1) % 6 == 0)
                {
                    decodedChars[i] = '-';
                }
                else
                {
                    // Do the actual decoding.
                    int digitMapIndex = 0;
                    for (int j = decodeStringLength - 1; j >= 0; j--)
                    {
                        int byteValue = (digitMapIndex << 8) | (byte)hexPid[j];
                        hexPid[j] = (byte)(byteValue / 24);
                        digitMapIndex = byteValue % 24;
                        decodedChars[i] = digits[digitMapIndex];
                    }
                }
            }
            return new string(decodedChars);
        }
        #endregion

        //Get Verions 32 BITS OR 64 BITS
        #region
        static bool is64BitProcess = (IntPtr.Size == 8);
        static bool is64BitOperatingSystem = is64BitProcess || InternalCheckIsWow64();

        [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsWow64Process(
            [In] IntPtr hProcess,
            [Out] out bool wow64Process
        );

        private static bool InternalCheckIsWow64()
        {
            if ((Environment.OSVersion.Version.Major == 5 && Environment.OSVersion.Version.Minor >= 1) ||
                Environment.OSVersion.Version.Major >= 6)
            {
                using (Process p = Process.GetCurrentProcess())
                {
                    bool retVal;
                    if (!IsWow64Process(p.Handle, out retVal))
                    {
                        return false;
                    }
                    return retVal;
                }
            }
            else
            {
                return false;
            }
        }
        #endregion

        //pega total de momoria ram
        private static void DisplayTotalRam(Label labelStatus)
        {
            string Query = "SELECT MaxCapacity FROM Win32_PhysicalMemoryArray";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(Query);
            foreach (ManagementObject WniPART in searcher.Get())
            {
                UInt32 SizeinKB = Convert.ToUInt32(WniPART.Properties["MaxCapacity"].Value);
                UInt32 SizeinMB = SizeinKB / 1024;
                UInt32 SizeinGB = SizeinMB / 1024;
                labelStatus.Text += string.Format("TAMANHO EM KB: {0}, TAMANHO EM MB: {1}, TAMANHO EM GB: {2}", SizeinKB, SizeinMB, SizeinGB);
            } 
        }

        //Slots and Speed not implemented
        private string GetSlotsRam()
        {
            //wmic MemPhysical get MemoryDevices, MaxCapacity
            // wmic memorychip get speed, caption
            return "";
        }

        //Get Driver Rom
        private string DetectedDriverRom() {
            System.IO.DriveInfo[] drives = System.IO.DriveInfo.GetDrives();
            string go = "";
            foreach (System.IO.DriveInfo drive in drives)
            {
                if (drive.DriveType == System.IO.DriveType.CDRom)
                  go += "POSSUI DRIVER DE LEITOR : " +  (drive.Name);
            }
            if(go == ""){
              go = "NÃO POSSUI CD/DVD/BLURAY";
            }

            return go;
        }

        //Get HD - Space Disk Free
        private void getHDS() {
            ConnectionOptions opt = new ConnectionOptions();
            ObjectQuery oQuery = new ObjectQuery("SELECT Size, FreeSpace, Name, FileSystem FROM Win32_LogicalDisk WHERE DriveType = 3");
            //ManagementScope scope = new ManagementScope("\\\\<meu servidor>\\root\\cimv2", opt);
            ManagementScope scope = new ManagementScope("\\\\localhost\\root\\cimv2", opt); //Get for IP
            ManagementObjectSearcher moSearcher = new ManagementObjectSearcher(scope, oQuery);
            ManagementObjectCollection collection = moSearcher.Get();
            foreach (ManagementObject res in collection)
            {
                //if (res["Name"].ToString() == "C:")
                //{
                    decimal size = Convert.ToDecimal(res["Size"]) / 1024 / 1024 / 1024;
                    decimal freeSpace = Convert.ToDecimal(res["FreeSpace"]) / 1024 / 1024 / 1024;
                    string unidade = res["Name"].ToString();
                    decimal tamanho = Decimal.Round(size, 2);
                    decimal livre = Decimal.Round(freeSpace, 2);
                    decimal usado = Decimal.Round(size - freeSpace, 2);
                    decimal livrepercent = Decimal.Round(usado / size, 2) * 100;
                    //if (livrepercent > parametro)
                    //{
                    //    unTPC.ForeColor = Color.Red;
                    //    tamTPC.ForeColor = Color.Red;
                    //    liTPC.ForeColor = Color.Red;
                    //    imgTPC.Visible = true;
                    //    SystemSounds.Question.Play();
                    //}
                    lblHds.Text += " UNIDADE : " + unidade + " TAMANHO : " + tamanho.ToString() + " LIVRE : " + livre.ToString() + " USADO : " + usado;
                //}
                //if (res["Name"].ToString() == "D:")
                //{
                //    decimal size = Convert.ToDecimal(res["Size"]) / 1024 / 1024 / 1024;
                //    decimal freeSpace = Convert.ToDecimal(res["FreeSpace"]) / 1024 / 1024 / 1024;
                //    string unidade = res["Name"].ToString();
                //    decimal tamanho = Decimal.Round(size, 2);
                //    decimal livre = Decimal.Round(freeSpace, 2);
                //    decimal usado = Decimal.Round(size - freeSpace, 2);
                //    decimal livrepercent = Decimal.Round(usado / size, 2) * 100;
                //    if (livrepercent > parametro)
                //    {
                //        un2TPC.ForeColor = Color.Red;
                //        tam2TPC.ForeColor = Color.Red;
                //        li2TPC.ForeColor = Color.Red;
                //        imgTPC.Visible = true;
                //        SystemSounds.Question.Play();
                //    }
                //    un2TPC.Text += unidade;
                //    un2TPC.Refresh();
                //    un2TPC.Visible = true;
                //    tam2TPC.Text += tamanho.ToString();
                //    tam2TPC.Refresh();
                //    tam2TPC.Visible = true;
                //    li2TPC.Text += livre.ToString();
                //    li2TPC.Refresh();
                //    li2TPC.Visible = true;
                //}
            }
        
        }

        //Get Type HD NVME or HDD or SSD not implemented
        private void getHDSType() {
            //wmic diskdrive get model,serialNumber,size,mediaType
        }

        //Get MotherBoard and Processor
        private void ProcessorAndMotherBoard() {
            ManagementObjectSearcher s1 = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_ComputerSystem");
            ManagementObjectSearcher s2 = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");

            lblMotherBoardProcessor.Text = "";
            foreach (ManagementObject mo in s1.Get())
                lblMotherBoardProcessor.Text  += " PLACA MÃE : " +  mo["Model"];

            foreach (ManagementObject mo in s2.Get())
                lblMotherBoardProcessor.Text  +=  " PROCESSADOR : " +  mo["Name"];        
        }

        private void FormTiAnalyzer_Load(object sender, EventArgs e)
        {
            btnReload_Click(null, null);
        }
    }

    //Get Serial Office //not implemented
    public class KeyDecoder
    {
        public enum Key { XP, Office10, Office11 };
        public static byte[] GetRegistryDigitalProductId(Key key)
        {
            byte[] digitalProductId = null;
            RegistryKey registry = null;
            switch (key)
            {
                // Open the XP subkey readonly.
                case Key.XP:
                    registry =
                      Registry.LocalMachine.
                        OpenSubKey(
                          @"SOFTWARE\Microsoft\Windows NT\CurrentVersion",
                            false);
                    break;
                // Open the Office 10 subkey readonly.
                case Key.Office10:
                    registry =
                      Registry.LocalMachine.
                        OpenSubKey(
                          @"SOFTWARE\Microsoft\Office\10.0\Registration\" + 
                          @"{90280409-6000-11D3-8CFE-0050048383C9}",
                          false);
                    // TODO: Open the registry key.
                    break;
                // Open the Office 11 subkey readonly.
                case Key.Office11:
                    // TODO: Open the registry key.
                    break;
            }
            if (registry != null)
            {
                // TODO: For other products, key name maybe different.
                digitalProductId = registry.GetValue("DigitalProductId")
                  as byte[];
                registry.Close();
            }
            return digitalProductId;
        }
       
    }


}
