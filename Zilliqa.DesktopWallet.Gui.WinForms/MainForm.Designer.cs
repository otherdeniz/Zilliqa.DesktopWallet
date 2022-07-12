namespace Zilliqa.DesktopWallet.Gui.WinForms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.buttonWallet = new System.Windows.Forms.ToolStripButton();
            this.buttonBlockchain = new System.Windows.Forms.ToolStripButton();
            this.buttonExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonSettings = new System.Windows.Forms.ToolStripButton();
            this.panelMain = new System.Windows.Forms.Panel();
            this.mainBlockchainBrowserControl = new Zilliqa.DesktopWallet.Gui.WinForms.Controls.Main.MainBlockchainBrowserControl();
            this.mainWalletControl = new Zilliqa.DesktopWallet.Gui.WinForms.Controls.Main.MainWalletControl();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripMain.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMain
            // 
            this.toolStripMain.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonBlockchain,
            this.toolStripButton1,
            this.buttonWallet,
            this.buttonExit,
            this.toolStripSeparator2,
            this.buttonSettings});
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(1093, 31);
            this.toolStripMain.TabIndex = 0;
            this.toolStripMain.Text = "toolStrip1";
            // 
            // buttonWallet
            // 
            this.buttonWallet.Image = ((System.Drawing.Image)(resources.GetObject("buttonWallet.Image")));
            this.buttonWallet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonWallet.Name = "buttonWallet";
            this.buttonWallet.Size = new System.Drawing.Size(68, 28);
            this.buttonWallet.Text = "Wallet";
            this.buttonWallet.Click += new System.EventHandler(this.buttonWallet_Click);
            // 
            // buttonBlockchain
            // 
            this.buttonBlockchain.Image = ((System.Drawing.Image)(resources.GetObject("buttonBlockchain.Image")));
            this.buttonBlockchain.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonBlockchain.Name = "buttonBlockchain";
            this.buttonBlockchain.Size = new System.Drawing.Size(138, 28);
            this.buttonBlockchain.Text = "Blockchain Browser";
            this.buttonBlockchain.Click += new System.EventHandler(this.buttonBlockchain_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.buttonExit.Image = ((System.Drawing.Image)(resources.GetObject("buttonExit.Image")));
            this.buttonExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(54, 28);
            this.buttonExit.Text = "Exit";
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // buttonSettings
            // 
            this.buttonSettings.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.buttonSettings.Image = ((System.Drawing.Image)(resources.GetObject("buttonSettings.Image")));
            this.buttonSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(77, 28);
            this.buttonSettings.Text = "Settings";
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelMain.Controls.Add(this.mainBlockchainBrowserControl);
            this.panelMain.Controls.Add(this.mainWalletControl);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 31);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(2);
            this.panelMain.Size = new System.Drawing.Size(1093, 652);
            this.panelMain.TabIndex = 1;
            // 
            // mainBlockchainBrowserControl
            // 
            this.mainBlockchainBrowserControl.BackColor = System.Drawing.SystemColors.Control;
            this.mainBlockchainBrowserControl.Location = new System.Drawing.Point(94, 174);
            this.mainBlockchainBrowserControl.Name = "mainBlockchainBrowserControl";
            this.mainBlockchainBrowserControl.Size = new System.Drawing.Size(412, 236);
            this.mainBlockchainBrowserControl.TabIndex = 1;
            this.mainBlockchainBrowserControl.Visible = false;
            // 
            // mainWalletControl
            // 
            this.mainWalletControl.BackColor = System.Drawing.SystemColors.Control;
            this.mainWalletControl.Location = new System.Drawing.Point(25, 30);
            this.mainWalletControl.Name = "mainWalletControl";
            this.mainWalletControl.Size = new System.Drawing.Size(328, 194);
            this.mainWalletControl.TabIndex = 0;
            this.mainWalletControl.Visible = false;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(122, 28);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 683);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.toolStripMain);
            this.Name = "MainForm";
            this.Text = "Zilliqa - Other Desktop Wallet";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ToolStrip toolStripMain;
        private ToolStripButton buttonWallet;
        private ToolStripButton buttonBlockchain;
        private ToolStripButton buttonExit;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton buttonSettings;
        private Panel panelMain;
        private Controls.Main.MainBlockchainBrowserControl mainBlockchainBrowserControl;
        private Controls.Main.MainWalletControl mainWalletControl;
        private ToolStripButton toolStripButton1;
    }
}