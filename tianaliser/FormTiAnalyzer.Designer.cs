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
            this.SuspendLayout();
            // 
            // btnReload
            // 
            this.btnReload.Enabled = false;
            this.btnReload.Location = new System.Drawing.Point(463, 12);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(124, 50);
            this.btnReload.TabIndex = 0;
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Visible = false;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // lblMac
            // 
            this.lblMac.AutoSize = true;
            this.lblMac.Location = new System.Drawing.Point(12, 13);
            this.lblMac.Name = "lblMac";
            this.lblMac.Size = new System.Drawing.Size(39, 13);
            this.lblMac.TabIndex = 1;
            this.lblMac.Text = "MAC : ";
            // 
            // lblSerialWindows
            // 
            this.lblSerialWindows.AutoSize = true;
            this.lblSerialWindows.Location = new System.Drawing.Point(12, 50);
            this.lblSerialWindows.Name = "lblSerialWindows";
            this.lblSerialWindows.Size = new System.Drawing.Size(110, 13);
            this.lblSerialWindows.TabIndex = 2;
            this.lblSerialWindows.Text = "SERIAL WINDOWS: ";
            // 
            // lblWindowsVersion
            // 
            this.lblWindowsVersion.AutoSize = true;
            this.lblWindowsVersion.Location = new System.Drawing.Point(12, 85);
            this.lblWindowsVersion.Name = "lblWindowsVersion";
            this.lblWindowsVersion.Size = new System.Drawing.Size(82, 13);
            this.lblWindowsVersion.TabIndex = 3;
            this.lblWindowsVersion.Text = "WIN VERSÃO: ";
            // 
            // lblWinVersion
            // 
            this.lblWinVersion.AutoSize = true;
            this.lblWinVersion.Location = new System.Drawing.Point(12, 119);
            this.lblWinVersion.Name = "lblWinVersion";
            this.lblWinVersion.Size = new System.Drawing.Size(82, 13);
            this.lblWinVersion.TabIndex = 4;
            this.lblWinVersion.Text = "WIN VERSÃO: ";
            // 
            // lblBits
            // 
            this.lblBits.AutoSize = true;
            this.lblBits.Location = new System.Drawing.Point(12, 149);
            this.lblBits.Name = "lblBits";
            this.lblBits.Size = new System.Drawing.Size(40, 13);
            this.lblBits.TabIndex = 5;
            this.lblBits.Text = "BITS : ";
            // 
            // lblMemory
            // 
            this.lblMemory.AutoSize = true;
            this.lblMemory.Location = new System.Drawing.Point(12, 180);
            this.lblMemory.Name = "lblMemory";
            this.lblMemory.Size = new System.Drawing.Size(67, 13);
            this.lblMemory.TabIndex = 6;
            this.lblMemory.Text = "MEMORIA : ";
            // 
            // lblHds
            // 
            this.lblHds.Location = new System.Drawing.Point(12, 211);
            this.lblHds.Name = "lblHds";
            this.lblHds.Size = new System.Drawing.Size(412, 33);
            this.lblHds.TabIndex = 7;
            this.lblHds.Text = "HDS : ";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(12, 271);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(65, 13);
            this.lblUser.TabIndex = 8;
            this.lblUser.Text = "USUARIO : ";
            // 
            // lblMotherBoardProcessor
            // 
            this.lblMotherBoardProcessor.AutoSize = true;
            this.lblMotherBoardProcessor.Location = new System.Drawing.Point(12, 307);
            this.lblMotherBoardProcessor.Name = "lblMotherBoardProcessor";
            this.lblMotherBoardProcessor.Size = new System.Drawing.Size(171, 13);
            this.lblMotherBoardProcessor.TabIndex = 9;
            this.lblMotherBoardProcessor.Text = "PLACA MÃE E PROCESSADOR : ";
            // 
            // lblDriverRom
            // 
            this.lblDriverRom.AutoSize = true;
            this.lblDriverRom.Location = new System.Drawing.Point(12, 339);
            this.lblDriverRom.Name = "lblDriverRom";
            this.lblDriverRom.Size = new System.Drawing.Size(111, 13);
            this.lblDriverRom.TabIndex = 10;
            this.lblDriverRom.Text = "DRIVER DE DISCO : ";
            // 
            // FormTiAnalyzer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 397);
            this.Controls.Add(this.lblDriverRom);
            this.Controls.Add(this.lblMotherBoardProcessor);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.lblHds);
            this.Controls.Add(this.lblMemory);
            this.Controls.Add(this.lblBits);
            this.Controls.Add(this.lblWinVersion);
            this.Controls.Add(this.lblWindowsVersion);
            this.Controls.Add(this.lblSerialWindows);
            this.Controls.Add(this.lblMac);
            this.Controls.Add(this.btnReload);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormTiAnalyzer";
            this.ShowIcon = false;
            this.Text = "TI Analyzer";
            this.Load += new System.EventHandler(this.FormTiAnalyzer_Load);
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
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblMotherBoardProcessor;
        private System.Windows.Forms.Label lblDriverRom;
    }
}

