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
using System.Collections.Generic;

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
            this.Text += " v" + Application.ProductVersion;
            lblMac.Text += getMacAddress();
            lblSerialWindows.Text += GetWindowsProductKey();
            lblWindowsVersion.Text += Environment.OSVersion.ToString();
            lblWinVersion.Text += getOSInfo();
            if (InternalCheckIsWow64())
            {
                lblBits.Text += "64-bit";
            }
            else { lblBits.Text += "32-bit"; }
            DisplayTotalRam(lblMemory);
            getHDS();
            lblUser.Text = "👤 User: " + Environment.UserName + " | 🖥️ Machine: " + Environment.MachineName + " | 🌐 Domain: " + Environment.UserDomainName;
            ProcessorAndMotherBoard();
            lblMotherBoardProcessor.Text += " | ⚙️ Cores: " + Environment.ProcessorCount;
            lblDriverRom.Text += DetectedDriverRom();
            lblGPU.Text += GetGPUInfo();
            lblBIOS.Text += GetBIOSInfo();
            lblPowerSupply.Text += GetPowerSupplyInfo();
            lblRamSlots.Text += GetSlotsRam();
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
                labelStatus.Text += string.Format("💾 Total: {0}GB ({1}MB) | Max Capacity: {2}KB", SizeinGB, SizeinMB, SizeinKB);
            } 
        }

        //Slots and Speed - Implemented to get RAM slots information with DDR type detection
        private string GetSlotsRam()
        {
            try
            {
                // Obter informações sobre slots de memória física
                string queryPhysicalMemory = "SELECT MemoryDevices FROM Win32_PhysicalMemoryArray";
                ManagementObjectSearcher searcherPhysical = new ManagementObjectSearcher(queryPhysicalMemory);
                
                int totalSlots = 0;
                foreach (ManagementObject obj in searcherPhysical.Get())
                {
                    if (obj["MemoryDevices"] != null)
                    {
                        totalSlots = Convert.ToInt32(obj["MemoryDevices"]);
                    }
                }

                // Obter informações sobre módulos de memória instalados
                string queryMemoryChips = "SELECT Capacity, Speed, Manufacturer, PartNumber, MemoryType, SMBIOSMemoryType FROM Win32_PhysicalMemory";
                ManagementObjectSearcher searcherChips = new ManagementObjectSearcher(queryMemoryChips);
                
                int usedSlots = 0;
                string memoryInfo = "";
                
                foreach (ManagementObject obj in searcherChips.Get())
                {
                    usedSlots++;
                    
                    // Converter capacidade de bytes para GB
                    ulong capacityBytes = Convert.ToUInt64(obj["Capacity"]);
                    double capacityGB = capacityBytes / (1024.0 * 1024.0 * 1024.0);
                    
                    string manufacturer = obj["Manufacturer"]?.ToString() ?? "Desconhecido";
                    string partNumber = obj["PartNumber"]?.ToString() ?? "Desconhecido";
                    string speed = obj["Speed"]?.ToString() ?? "Desconhecido";
                    
                    // Identificar tipo de memória DDR
                    string ddrType = GetDDRType(obj);
                    
                    memoryInfo += $"Slot {usedSlots}: {capacityGB:F2}GB - {manufacturer} {partNumber} - {ddrType} - {speed}MHz\n";
                }

                int freeSlots = totalSlots - usedSlots;
                
                string result = $"SLOTS TOTAIS: {totalSlots}\n";
                result += $"SLOTS USADOS: {usedSlots}\n";
                result += $"SLOTS LIVRES: {freeSlots}\n\n";
                result += "DETALHES DOS MÓDULOS:\n" + memoryInfo;
                
                return result;
            }
            catch (Exception ex)
            {
                return $"Erro ao obter informações dos slots de RAM: {ex.Message}";
            }
        }

        // Método auxiliar para identificar o tipo de DDR
        private string GetDDRType(ManagementObject memoryObj)
        {
            try
            {
                // Tentar obter o tipo de memória do SMBIOS
                if (memoryObj["SMBIOSMemoryType"] != null)
                {
                    int smbiosType = Convert.ToInt32(memoryObj["SMBIOSMemoryType"]);
                    return GetDDRTypeFromSMBIOS(smbiosType);
                }
                
                // Tentar obter o tipo de memória padrão
                if (memoryObj["MemoryType"] != null)
                {
                    int memoryType = Convert.ToInt32(memoryObj["MemoryType"]);
                    return GetDDRTypeFromMemoryType(memoryType);
                }
                
                // Se não conseguir identificar pelo WMI, tentar pela velocidade
                if (memoryObj["Speed"] != null)
                {
                    int speed = Convert.ToInt32(memoryObj["Speed"]);
                    return GetDDRTypeFromSpeed(speed);
                }
                
                return "DDR Desconhecido";
            }
            catch
            {
                return "DDR Desconhecido";
            }
        }

        // Identificar DDR pelo tipo SMBIOS
        private string GetDDRTypeFromSMBIOS(int smbiosType)
        {
            switch (smbiosType)
            {
                case 20: return "DDR";
                case 21: return "DDR2";
                case 22: return "DDR2 FB-DIMM";
                case 24: return "DDR3";
                case 26: return "DDR4";
                case 28: return "DDR5";
                case 30: return "DDR5";
                default: return $"DDR (SMBIOS: {smbiosType})";
            }
        }

        // Identificar DDR pelo tipo de memória padrão
        private string GetDDRTypeFromMemoryType(int memoryType)
        {
            switch (memoryType)
            {
                case 20: return "DDR";
                case 21: return "DDR2";
                case 22: return "DDR2 FB-DIMM";
                case 24: return "DDR3";
                case 26: return "DDR4";
                case 28: return "DDR5";
                case 30: return "DDR5";
                default: return $"DDR (Tipo: {memoryType})";
            }
        }

        // Identificar DDR pela velocidade (fallback)
        private string GetDDRTypeFromSpeed(int speed)
        {
            if (speed <= 400) return "DDR";
            if (speed <= 800) return "DDR2";
            if (speed <= 1600) return "DDR3";
            if (speed <= 3200) return "DDR4";
            if (speed <= 6400) return "DDR5";
            return "DDR5+";
        }

        //Get Driver Rom
        private string DetectedDriverRom() {
            System.IO.DriveInfo[] drives = System.IO.DriveInfo.GetDrives();
            string go = "";
            foreach (System.IO.DriveInfo drive in drives)
            {
                if (drive.DriveType == System.IO.DriveType.CDRom)
                  go += "💿 Optical Drive: " +  (drive.Name);
            }
            if(go == ""){
              go = "❌ No optical drive detected";
            }

            return go;
        }

        //Get HD - Space Disk Free with Storage Type Detection
        private void getHDS() {
            try
            {
                // Obter informações dos discos físicos
                string queryDiskDrive = "SELECT Model, MediaType, InterfaceType, Size, SerialNumber FROM Win32_DiskDrive";
                ManagementObjectSearcher searcherDiskDrive = new ManagementObjectSearcher(queryDiskDrive);
                
                // Obter informações dos discos lógicos
            ConnectionOptions opt = new ConnectionOptions();
            ObjectQuery oQuery = new ObjectQuery("SELECT Size, FreeSpace, Name, FileSystem FROM Win32_LogicalDisk WHERE DriveType = 3");
                ManagementScope scope = new ManagementScope("\\\\localhost\\root\\cimv2", opt);
            ManagementObjectSearcher moSearcher = new ManagementObjectSearcher(scope, oQuery);
            ManagementObjectCollection collection = moSearcher.Get();
                
                // Criar dicionário para mapear discos físicos
                Dictionary<string, string> diskTypes = new Dictionary<string, string>();
                Dictionary<string, string> diskModels = new Dictionary<string, string>();
                
                foreach (ManagementObject disk in searcherDiskDrive.Get())
                {
                    string model = disk["Model"]?.ToString() ?? "Desconhecido";
                    string mediaType = disk["MediaType"]?.ToString() ?? "";
                    string interfaceType = disk["InterfaceType"]?.ToString() ?? "";
                    string serialNumber = disk["SerialNumber"]?.ToString() ?? "";
                    
                    string storageType = GetStorageType(model, mediaType, interfaceType);
                    string diskKey = $"{model}_{serialNumber}";
                    
                    diskTypes[diskKey] = storageType;
                    diskModels[diskKey] = model;
                }
                
            foreach (ManagementObject res in collection)
            {
                    decimal size = Convert.ToDecimal(res["Size"]) / 1024 / 1024 / 1024;
                    decimal freeSpace = Convert.ToDecimal(res["FreeSpace"]) / 1024 / 1024 / 1024;
                    string unidade = res["Name"].ToString();
                    decimal tamanho = Decimal.Round(size, 2);
                    decimal livre = Decimal.Round(freeSpace, 2);
                    decimal usado = Decimal.Round(size - freeSpace, 2);
                    decimal livrepercent = Decimal.Round(usado / size, 2) * 100;
                    
                    // Tentar identificar o tipo de armazenamento
                    string storageType = "Desconhecido";
                    foreach (var kvp in diskTypes)
                    {
                        if (kvp.Value != "Desconhecido")
                        {
                            storageType = kvp.Value;
                            break;
                        }
                    }
                    
                    lblHds.Text += $" UNIDADE: {unidade} TAMANHO: {tamanho}GB LIVRE: {livre}GB USADO: {usado}GB TIPO: {storageType}\n";
                }
            }
            catch (Exception ex)
            {
                lblHds.Text += $" Erro ao obter informações dos discos: {ex.Message}";
            }
        }

        // Método auxiliar para identificar o tipo de armazenamento
        private string GetStorageType(string model, string mediaType, string interfaceType)
        {
            try
            {
                // Converter para minúsculas para comparação
                string modelLower = model.ToLower();
                string mediaTypeLower = mediaType.ToLower();
                string interfaceTypeLower = interfaceType.ToLower();
                
                // Verificar por NVMe
                if (modelLower.Contains("nvme") || interfaceTypeLower.Contains("nvme"))
                {
                    return "NVMe SSD";
                }
                
                // Verificar por SSD
                if (modelLower.Contains("ssd") || 
                    modelLower.Contains("solid state") || 
                    mediaTypeLower.Contains("ssd") ||
                    modelLower.Contains("m.2") ||
                    modelLower.Contains("m2"))
                {
                    return "SSD";
                }
                
                // Verificar por HDD
                if (modelLower.Contains("hdd") || 
                    modelLower.Contains("hard disk") || 
                    mediaTypeLower.Contains("hdd") ||
                    mediaTypeLower.Contains("fixed hard disk") ||
                    interfaceTypeLower.Contains("ide") ||
                    interfaceTypeLower.Contains("sata"))
                {
                    return "HDD";
                }
                
                // Verificar por interface específica
                if (interfaceTypeLower.Contains("nvme"))
                {
                    return "NVMe SSD";
                }
                else if (interfaceTypeLower.Contains("sata"))
                {
                    // SATA pode ser HDD ou SSD, verificar pelo modelo
                    if (modelLower.Contains("ssd") || modelLower.Contains("solid state"))
                    {
                        return "SATA SSD";
                    }
                    else
                    {
                        return "SATA HDD";
                    }
                }
                else if (interfaceTypeLower.Contains("ide"))
                {
                    return "IDE HDD";
                }
                else if (interfaceTypeLower.Contains("scsi"))
                {
                    return "SCSI HDD";
                }
                
                // Verificar por tipo de mídia específico
                if (mediaTypeLower.Contains("ssd"))
                {
                    return "SSD";
                }
                else if (mediaTypeLower.Contains("hdd") || mediaTypeLower.Contains("fixed hard disk"))
                {
                    return "HDD";
                }
                
                // Fallback baseado no modelo
                if (modelLower.Contains("intel") || modelLower.Contains("samsung") || modelLower.Contains("crucial"))
                {
                    if (modelLower.Contains("nvme") || modelLower.Contains("m.2"))
                    {
                        return "NVMe SSD";
                    }
                    else if (modelLower.Contains("ssd"))
                    {
                        return "SSD";
                    }
                }
                
                return "Desconhecido";
            }
            catch
            {
                return "Desconhecido";
            }
        }

        //Get GPU Information
        private string GetGPUInfo()
        {
            try
            {
                string queryGPU = "SELECT Name, DriverVersion, DriverDate, VideoMemoryType, AdapterRAM FROM Win32_VideoController WHERE VideoMemoryType IS NOT NULL";
                ManagementObjectSearcher searcherGPU = new ManagementObjectSearcher(queryGPU);
                
                string gpuInfo = "";
                int gpuCount = 0;
                
                foreach (ManagementObject gpu in searcherGPU.Get())
                {
                    gpuCount++;
                    string name = gpu["Name"]?.ToString() ?? "Unknown";
                    string driverVersion = gpu["DriverVersion"]?.ToString() ?? "Unknown";
                    string driverDate = gpu["DriverDate"]?.ToString() ?? "Unknown";
                    string memoryType = gpu["VideoMemoryType"]?.ToString() ?? "Unknown";
                    string adapterRAM = gpu["AdapterRAM"]?.ToString() ?? "Unknown";
                    
                    // Converter memória de bytes para MB/GB
                    string memorySize = "Unknown";
                    if (adapterRAM != "Unknown" && adapterRAM != "")
                    {
                        try
                        {
                            long ramBytes = Convert.ToInt64(adapterRAM);
                            if (ramBytes > 0)
                            {
                                double ramMB = ramBytes / (1024.0 * 1024.0);
                                double ramGB = ramMB / 1024.0;
                                
                                if (ramGB >= 1)
                                {
                                    memorySize = $"{ramGB:F1}GB";
                                }
                                else
                                {
                                    memorySize = $"{ramMB:F0}MB";
                                }
                            }
                        }
                        catch
                        {
                            memorySize = "Unknown";
                        }
                    }
                    
                    // Determinar tipo de memória
                    string memoryTypeText = GetVideoMemoryType(memoryType);
                    
                    if (gpuCount == 1)
                    {
                        gpuInfo += $"🎮 GPU {gpuCount}: {name} | 💾 VRAM: {memorySize} ({memoryTypeText}) | 🔧 Driver: {driverVersion}";
                    }
                    else
                    {
                        gpuInfo += $"\n🎮 GPU {gpuCount}: {name} | 💾 VRAM: {memorySize} ({memoryTypeText}) | 🔧 Driver: {driverVersion}";
                    }
                }
                
                if (gpuCount == 0)
                {
                    gpuInfo = "❌ No dedicated graphics card detected (using integrated graphics)";
                }
                
                return gpuInfo;
            }
            catch (Exception ex)
            {
                return $"❌ Error detecting GPU: {ex.Message}";
            }
        }

        // Método auxiliar para identificar o tipo de memória de vídeo
        private string GetVideoMemoryType(string memoryType)
        {
            switch (memoryType)
            {
                case "1": return "Other";
                case "2": return "Unknown";
                case "3": return "VRAM";
                case "4": return "DRAM";
                case "5": return "SRAM";
                case "6": return "WRAM";
                case "7": return "EDO RAM";
                case "8": return "Burst Synchronous DRAM";
                case "9": return "Pipelined Burst SRAM";
                case "10": return "CDRAM";
                case "11": return "3DRAM";
                case "12": return "SDRAM";
                case "13": return "SGRAM";
                case "14": return "RDRAM";
                case "15": return "DDR";
                case "16": return "DDR2";
                case "17": return "DDR2 FB-DIMM";
                case "18": return "DDR3";
                case "19": return "FBD2";
                case "20": return "DDR4";
                case "21": return "DDR5";
                default: return "Unknown";
            }
        }

        //Get BIOS Information including Serial Number
        private string GetBIOSInfo()
        {
            try
            {
                string queryBIOS = "SELECT SerialNumber, Manufacturer, Version, ReleaseDate, SMBIOSBIOSVersion FROM Win32_BIOS";
                ManagementObjectSearcher searcherBIOS = new ManagementObjectSearcher(queryBIOS);
                
                string biosInfo = "";
                
                foreach (ManagementObject bios in searcherBIOS.Get())
                {
                    string serialNumber = bios["SerialNumber"]?.ToString() ?? "Unknown";
                    string manufacturer = bios["Manufacturer"]?.ToString() ?? "Unknown";
                    string version = bios["Version"]?.ToString() ?? "Unknown";
                    string releaseDate = bios["ReleaseDate"]?.ToString() ?? "Unknown";
                    string smbiosVersion = bios["SMBIOSBIOSVersion"]?.ToString() ?? "Unknown";
                    
                    // Converter data de release se disponível
                    string formattedDate = "Unknown";
                    if (releaseDate != "Unknown" && releaseDate.Length >= 8)
                    {
                        try
                        {
                            string year = releaseDate.Substring(0, 4);
                            string month = releaseDate.Substring(4, 2);
                            string day = releaseDate.Substring(6, 2);
                            formattedDate = $"{day}/{month}/{year}";
                        }
                        catch
                        {
                            formattedDate = releaseDate;
                        }
                    }
                    
                    biosInfo = $"🔧 Manufacturer: {manufacturer} | 📋 Version: {version} | 🔢 Serial: {serialNumber} | 📅 Release: {formattedDate} | 🏷️ SMBIOS: {smbiosVersion}";
                }
                
                if (string.IsNullOrEmpty(biosInfo))
                {
                    biosInfo = "❌ BIOS information not available";
                }
                
                return biosInfo;
            }
            catch (Exception ex)
            {
                return $"❌ Error detecting BIOS: {ex.Message}";
            }
        }

        //Get Power Supply Information
        private string GetPowerSupplyInfo()
        {
            try
            {
                string queryPowerSupply = "SELECT Name, Description, Status, PowerSupplyType, MaxPowerCapacityWatt FROM Win32_SystemEnclosure";
                ManagementObjectSearcher searcherPowerSupply = new ManagementObjectSearcher(queryPowerSupply);
                
                string powerInfo = "";
                
                foreach (ManagementObject power in searcherPowerSupply.Get())
                {
                    string name = power["Name"]?.ToString() ?? "Unknown";
                    string description = power["Description"]?.ToString() ?? "Unknown";
                    string status = power["Status"]?.ToString() ?? "Unknown";
                    string powerSupplyType = power["PowerSupplyType"]?.ToString() ?? "Unknown";
                    string maxPower = power["MaxPowerCapacityWatt"]?.ToString() ?? "Unknown";
                    
                    // Determinar tipo de fonte
                    string powerTypeText = GetPowerSupplyType(powerSupplyType);
                    
                    powerInfo = $"⚡ Type: {powerTypeText} | 🔋 Max Power: {maxPower}W | 📊 Status: {status} | 📝 Description: {description}";
                }
                
                // Tentar obter informações adicionais via WMI alternativo
                if (string.IsNullOrEmpty(powerInfo) || powerInfo.Contains("Unknown"))
                {
                    string queryBattery = "SELECT Name, Description, Status, EstimatedChargeRemaining FROM Win32_Battery";
                    ManagementObjectSearcher searcherBattery = new ManagementObjectSearcher(queryBattery);
                    
                    string batteryInfo = "";
                    int batteryCount = 0;
                    
                    foreach (ManagementObject battery in searcherBattery.Get())
                    {
                        batteryCount++;
                        string batteryName = battery["Name"]?.ToString() ?? "Unknown";
                        string batteryStatus = battery["Status"]?.ToString() ?? "Unknown";
                        string chargeRemaining = battery["EstimatedChargeRemaining"]?.ToString() ?? "Unknown";
                        
                        if (batteryCount == 1)
                        {
                            batteryInfo = $"🔋 Battery: {batteryName} | 📊 Status: {batteryStatus} | 🔋 Charge: {chargeRemaining}%";
                        }
                        else
                        {
                            batteryInfo += $"\n🔋 Battery {batteryCount}: {batteryName} | 📊 Status: {batteryStatus} | 🔋 Charge: {chargeRemaining}%";
                        }
                    }
                    
                    if (batteryCount > 0)
                    {
                        powerInfo = batteryInfo;
                    }
                    else if (string.IsNullOrEmpty(powerInfo))
                    {
                        powerInfo = "❌ Power supply information not available";
                    }
                }
                
                return powerInfo;
            }
            catch (Exception ex)
            {
                return $"❌ Error detecting power supply: {ex.Message}";
            }
        }

        // Método auxiliar para identificar o tipo de fonte de energia
        private string GetPowerSupplyType(string powerSupplyType)
        {
            switch (powerSupplyType)
            {
                case "1": return "Other";
                case "2": return "Unknown";
                case "3": return "Linear";
                case "4": return "Switching";
                case "5": return "Battery";
                case "6": return "UPS";
                case "7": return "Converter";
                case "8": return "Regulator";
                default: return "Unknown";
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
                lblMotherBoardProcessor.Text  += "🔧 Motherboard: " +  mo["Model"];

            foreach (ManagementObject mo in s2.Get())
                lblMotherBoardProcessor.Text  +=  " | 🖥️ Processor: " +  mo["Name"];        
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
