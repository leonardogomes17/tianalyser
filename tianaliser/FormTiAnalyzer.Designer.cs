namespace tianaliser
{
    partial class FormTiAnalyzer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnReload = new System.Windows.Forms.Button();
            this.lblMac = new System.Windows.Forms.Label();
            this.lblSerialWindows = new System.Windows.Forms.Label();
            this.lblWindowsVersion = new System.Windows.Forms.Label();
            this.lblWinVersion = new System.Windows.Forms.Label();
            this.lblBits = new System.Windows.Forms.Label();
            this.lblMemory = new System.Windows.Forms.Label();
            this.lblHds = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblMotherBoardProcessor = new System.Windows.Forms.Label();
            this.lblDriverRom = new System.Windows.Forms.Label();
            this.lblRamSlots = new System.Windows.Forms.Label();
            this.panelSystemInfo = new System.Windows.Forms.Panel();
            this.lblOfficeVersion = new System.Windows.Forms.Label();
            this.lblOfficeSerial = new System.Windows.Forms.Label();
            this.panelHardware = new System.Windows.Forms.Panel();
            this.panelGPU = new System.Windows.Forms.Panel();
            this.lblGPU = new System.Windows.Forms.Label();
            this.panelBIOS = new System.Windows.Forms.Panel();
            this.lblBIOS = new System.Windows.Forms.Label();
            this.panelPowerSupply = new System.Windows.Forms.Panel();
            this.lblPowerSupply = new System.Windows.Forms.Label();
            this.panelStorage = new System.Windows.Forms.Panel();
            this.panelMemory = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.scrollPanel = new System.Windows.Forms.Panel();
            this.panelSystemInfo.SuspendLayout();
            this.panelHardware.SuspendLayout();
            this.panelGPU.SuspendLayout();
            this.panelBIOS.SuspendLayout();
            this.panelPowerSupply.SuspendLayout();
            this.panelStorage.SuspendLayout();
            this.panelMemory.SuspendLayout();
            this.scrollPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnReload
            // 
            this.btnReload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnReload.FlatAppearance.BorderSize = 0;
            this.btnReload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReload.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnReload.ForeColor = System.Drawing.Color.White;
            this.btnReload.Location = new System.Drawing.Point(650, 15);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(120, 35);
            this.btnReload.TabIndex = 1;
            this.btnReload.Text = "🔄 Atualizar";
            this.btnReload.UseVisualStyleBackColor = false;
            this.btnReload.Visible = false;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // lblMac
            // 
            this.lblMac.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMac.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblMac.Location = new System.Drawing.Point(15, 20);
            this.lblMac.Name = "lblMac";
            this.lblMac.Size = new System.Drawing.Size(720, 20);
            this.lblMac.TabIndex = 0;
            this.lblMac.Text = "🌐 MAC Address: ";
            // 
            // lblSerialWindows
            // 
            this.lblSerialWindows.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerialWindows.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblSerialWindows.Location = new System.Drawing.Point(15, 45);
            this.lblSerialWindows.Name = "lblSerialWindows";
            this.lblSerialWindows.Size = new System.Drawing.Size(720, 20);
            this.lblSerialWindows.TabIndex = 1;
            this.lblSerialWindows.Text = "🔑 Serial Windows: ";
            // 
            // lblWindowsVersion
            // 
            this.lblWindowsVersion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWindowsVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblWindowsVersion.Location = new System.Drawing.Point(15, 70);
            this.lblWindowsVersion.Name = "lblWindowsVersion";
            this.lblWindowsVersion.Size = new System.Drawing.Size(720, 20);
            this.lblWindowsVersion.TabIndex = 2;
            this.lblWindowsVersion.Text = "🖥️ Windows Version: ";
            // 
            // lblWinVersion
            // 
            this.lblWinVersion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWinVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblWinVersion.Location = new System.Drawing.Point(15, 95);
            this.lblWinVersion.Name = "lblWinVersion";
            this.lblWinVersion.Size = new System.Drawing.Size(720, 20);
            this.lblWinVersion.TabIndex = 3;
            this.lblWinVersion.Text = "📋 Windows Info: ";
            // 
            // lblBits
            // 
            this.lblBits.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBits.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblBits.Location = new System.Drawing.Point(15, 120);
            this.lblBits.Name = "lblBits";
            this.lblBits.Size = new System.Drawing.Size(720, 20);
            this.lblBits.TabIndex = 4;
            this.lblBits.Text = "⚙️ Architecture: ";
            // 
            // lblMemory
            // 
            this.lblMemory.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblMemory.Location = new System.Drawing.Point(15, 20);
            this.lblMemory.Name = "lblMemory";
            this.lblMemory.Size = new System.Drawing.Size(720, 20);
            this.lblMemory.TabIndex = 0;
            this.lblMemory.Text = "💾 Total Memory: ";
            // 
            // lblHds
            // 
            this.lblHds.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHds.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblHds.Location = new System.Drawing.Point(15, 50);
            this.lblHds.Name = "lblHds";
            this.lblHds.Size = new System.Drawing.Size(720, 60);
            this.lblHds.TabIndex = 1;
            this.lblHds.Text = "💿 Storage Devices: ";
            // 
            // lblUser
            // 
            this.lblUser.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblUser.Location = new System.Drawing.Point(15, 145);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(720, 20);
            this.lblUser.TabIndex = 5;
            this.lblUser.Text = "👤 User Info: ";
            // 
            // lblMotherBoardProcessor
            // 
            this.lblMotherBoardProcessor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMotherBoardProcessor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblMotherBoardProcessor.Location = new System.Drawing.Point(15, 20);
            this.lblMotherBoardProcessor.Name = "lblMotherBoardProcessor";
            this.lblMotherBoardProcessor.Size = new System.Drawing.Size(720, 20);
            this.lblMotherBoardProcessor.TabIndex = 0;
            this.lblMotherBoardProcessor.Text = "🔧 Motherboard & Processor: ";
            // 
            // lblDriverRom
            // 
            this.lblDriverRom.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDriverRom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblDriverRom.Location = new System.Drawing.Point(15, 50);
            this.lblDriverRom.Name = "lblDriverRom";
            this.lblDriverRom.Size = new System.Drawing.Size(720, 20);
            this.lblDriverRom.TabIndex = 1;
            this.lblDriverRom.Text = "💿 Optical Drive: ";
            // 
            // lblRamSlots
            // 
            this.lblRamSlots.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRamSlots.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblRamSlots.Location = new System.Drawing.Point(15, 20);
            this.lblRamSlots.Name = "lblRamSlots";
            this.lblRamSlots.Size = new System.Drawing.Size(720, 120);
            this.lblRamSlots.TabIndex = 0;
            this.lblRamSlots.Text = "🧠 RAM Slots: ";
            // 
            // panelSystemInfo
            // 
            this.panelSystemInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelSystemInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSystemInfo.Controls.Add(this.lblMac);
            this.panelSystemInfo.Controls.Add(this.lblSerialWindows);
            this.panelSystemInfo.Controls.Add(this.lblWindowsVersion);
            this.panelSystemInfo.Controls.Add(this.lblWinVersion);
            this.panelSystemInfo.Controls.Add(this.lblBits);
            this.panelSystemInfo.Controls.Add(this.lblOfficeVersion);
            this.panelSystemInfo.Controls.Add(this.lblOfficeSerial);
            this.panelSystemInfo.Controls.Add(this.lblUser);
            this.panelSystemInfo.Location = new System.Drawing.Point(20, 20);
            this.panelSystemInfo.Name = "panelSystemInfo";
            this.panelSystemInfo.Size = new System.Drawing.Size(750, 194);
            this.panelSystemInfo.TabIndex = 2;
            // 
            // lblOfficeVersion
            // 
            this.lblOfficeVersion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOfficeVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblOfficeVersion.Location = new System.Drawing.Point(15, 145);
            this.lblOfficeVersion.Name = "lblOfficeVersion";
            this.lblOfficeVersion.Size = new System.Drawing.Size(720, 20);
            this.lblOfficeVersion.TabIndex = 5;
            this.lblOfficeVersion.Text = "📊 Office Version: ";
            // 
            // lblOfficeSerial
            // 
            this.lblOfficeSerial.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOfficeSerial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblOfficeSerial.Location = new System.Drawing.Point(15, 170);
            this.lblOfficeSerial.Name = "lblOfficeSerial";
            this.lblOfficeSerial.Size = new System.Drawing.Size(720, 20);
            this.lblOfficeSerial.TabIndex = 6;
            this.lblOfficeSerial.Text = "🔑 Office Serial: ";
            // 
            // panelHardware
            // 
            this.panelHardware.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelHardware.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelHardware.Controls.Add(this.lblMotherBoardProcessor);
            this.panelHardware.Controls.Add(this.lblDriverRom);
            this.panelHardware.Location = new System.Drawing.Point(20, 220);
            this.panelHardware.Name = "panelHardware";
            this.panelHardware.Size = new System.Drawing.Size(750, 100);
            this.panelHardware.TabIndex = 3;
            // 
            // panelGPU
            // 
            this.panelGPU.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelGPU.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGPU.Controls.Add(this.lblGPU);
            this.panelGPU.Location = new System.Drawing.Point(20, 326);
            this.panelGPU.Name = "panelGPU";
            this.panelGPU.Size = new System.Drawing.Size(750, 80);
            this.panelGPU.TabIndex = 4;
            // 
            // lblGPU
            // 
            this.lblGPU.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGPU.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblGPU.Location = new System.Drawing.Point(15, 20);
            this.lblGPU.Name = "lblGPU";
            this.lblGPU.Size = new System.Drawing.Size(720, 50);
            this.lblGPU.TabIndex = 0;
            this.lblGPU.Text = "🎮 Graphics Card: ";
            // 
            // panelBIOS
            // 
            this.panelBIOS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelBIOS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBIOS.Controls.Add(this.lblBIOS);
            this.panelBIOS.Location = new System.Drawing.Point(20, 412);
            this.panelBIOS.Name = "panelBIOS";
            this.panelBIOS.Size = new System.Drawing.Size(750, 80);
            this.panelBIOS.TabIndex = 5;
            // 
            // lblBIOS
            // 
            this.lblBIOS.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBIOS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblBIOS.Location = new System.Drawing.Point(15, 20);
            this.lblBIOS.Name = "lblBIOS";
            this.lblBIOS.Size = new System.Drawing.Size(720, 50);
            this.lblBIOS.TabIndex = 0;
            this.lblBIOS.Text = "🔧 BIOS Information: ";
            // 
            // panelPowerSupply
            // 
            this.panelPowerSupply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelPowerSupply.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPowerSupply.Controls.Add(this.lblPowerSupply);
            this.panelPowerSupply.Location = new System.Drawing.Point(20, 498);
            this.panelPowerSupply.Name = "panelPowerSupply";
            this.panelPowerSupply.Size = new System.Drawing.Size(750, 80);
            this.panelPowerSupply.TabIndex = 6;
            // 
            // lblPowerSupply
            // 
            this.lblPowerSupply.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPowerSupply.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblPowerSupply.Location = new System.Drawing.Point(15, 20);
            this.lblPowerSupply.Name = "lblPowerSupply";
            this.lblPowerSupply.Size = new System.Drawing.Size(720, 50);
            this.lblPowerSupply.TabIndex = 0;
            this.lblPowerSupply.Text = "⚡ Power Supply: ";
            // 
            // panelStorage
            // 
            this.panelStorage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelStorage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelStorage.Controls.Add(this.lblMemory);
            this.panelStorage.Controls.Add(this.lblHds);
            this.panelStorage.Location = new System.Drawing.Point(20, 584);
            this.panelStorage.Name = "panelStorage";
            this.panelStorage.Size = new System.Drawing.Size(750, 120);
            this.panelStorage.TabIndex = 7;
            // 
            // panelMemory
            // 
            this.panelMemory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelMemory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMemory.Controls.Add(this.lblRamSlots);
            this.panelMemory.Location = new System.Drawing.Point(20, 710);
            this.panelMemory.Name = "panelMemory";
            this.panelMemory.Size = new System.Drawing.Size(750, 150);
            this.panelMemory.TabIndex = 8;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(231, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🔍 TI Analyzer Pro";
            // 
            // scrollPanel
            // 
            this.scrollPanel.AutoScroll = true;
            this.scrollPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.scrollPanel.Controls.Add(this.panelMemory);
            this.scrollPanel.Controls.Add(this.panelStorage);
            this.scrollPanel.Controls.Add(this.panelPowerSupply);
            this.scrollPanel.Controls.Add(this.panelBIOS);
            this.scrollPanel.Controls.Add(this.panelGPU);
            this.scrollPanel.Controls.Add(this.panelHardware);
            this.scrollPanel.Controls.Add(this.panelSystemInfo);
            this.scrollPanel.Location = new System.Drawing.Point(0, 60);
            this.scrollPanel.Name = "scrollPanel";
            this.scrollPanel.Size = new System.Drawing.Size(800, 540);
            this.scrollPanel.TabIndex = 0;
            // 
            // FormTiAnalyzer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.scrollPanel);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormTiAnalyzer";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TI Analyzer Pro - System Information Tool";
            this.Load += new System.EventHandler(this.FormTiAnalyzer_Load);
            this.panelSystemInfo.ResumeLayout(false);
            this.panelHardware.ResumeLayout(false);
            this.panelGPU.ResumeLayout(false);
            this.panelBIOS.ResumeLayout(false);
            this.panelPowerSupply.ResumeLayout(false);
            this.panelStorage.ResumeLayout(false);
            this.panelMemory.ResumeLayout(false);
            this.scrollPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Label lblMac;
        private System.Windows.Forms.Label lblSerialWindows;
        private System.Windows.Forms.Label lblWindowsVersion;
        private System.Windows.Forms.Label lblWinVersion;
        private System.Windows.Forms.Label lblBits;
        private System.Windows.Forms.Label lblMemory;
        private System.Windows.Forms.Label lblHds;
        private System.Windows.Forms.Label lblOfficeVersion;
        private System.Windows.Forms.Label lblOfficeSerial;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblMotherBoardProcessor;
        private System.Windows.Forms.Label lblDriverRom;
        private System.Windows.Forms.Label lblRamSlots;
        private System.Windows.Forms.Panel panelSystemInfo;
        private System.Windows.Forms.Panel panelHardware;
        private System.Windows.Forms.Panel panelGPU;
        private System.Windows.Forms.Panel panelBIOS;
        private System.Windows.Forms.Panel panelPowerSupply;
        private System.Windows.Forms.Panel panelStorage;
        private System.Windows.Forms.Panel panelMemory;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblGPU;
        private System.Windows.Forms.Label lblBIOS;
        private System.Windows.Forms.Label lblPowerSupply;
        private System.Windows.Forms.Panel scrollPanel;
    }
}

