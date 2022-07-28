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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.buttonWallet = new System.Windows.Forms.ToolStripButton();
            this.buttonTokens = new System.Windows.Forms.ToolStripButton();
            this.buttonExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonSettings = new System.Windows.Forms.ToolStripButton();
            this.buttonBlockchain = new System.Windows.Forms.ToolStripButton();
            this.panelMain = new System.Windows.Forms.Panel();
            this.mainWalletControl = new Zilliqa.DesktopWallet.Gui.WinForms.Controls.Main.MainWalletControl();
            this.mainBlockchainBrowserControl = new Zilliqa.DesktopWallet.Gui.WinForms.Controls.Main.MainBlockchainBrowserControl();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.groupBoxNotifications = new System.Windows.Forms.GroupBox();
            this.panelNotifications = new System.Windows.Forms.Panel();
            this.groupBoxStatus = new System.Windows.Forms.GroupBox();
            this.bottomStatusControl1 = new Zilliqa.DesktopWallet.Gui.WinForms.Controls.Main.BottomStatusControl();
            this.timerInit = new System.Windows.Forms.Timer(this.components);
            this.toolStripMain.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.groupBoxNotifications.SuspendLayout();
            this.groupBoxStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMain
            // 
            this.toolStripMain.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonWallet,
            this.buttonTokens,
            this.buttonExit,
            this.toolStripSeparator2,
            this.buttonSettings,
            this.buttonBlockchain});
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
            // buttonTokens
            // 
            this.buttonTokens.Image = ((System.Drawing.Image)(resources.GetObject("buttonTokens.Image")));
            this.buttonTokens.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonTokens.Name = "buttonTokens";
            this.buttonTokens.Size = new System.Drawing.Size(107, 28);
            this.buttonTokens.Text = "ZRC-2 Tokens";
            this.buttonTokens.Click += new System.EventHandler(this.buttonTokens_Click);
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
            // buttonBlockchain
            // 
            this.buttonBlockchain.Image = ((System.Drawing.Image)(resources.GetObject("buttonBlockchain.Image")));
            this.buttonBlockchain.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonBlockchain.Name = "buttonBlockchain";
            this.buttonBlockchain.Size = new System.Drawing.Size(138, 28);
            this.buttonBlockchain.Text = "Blockchain Browser";
            this.buttonBlockchain.Click += new System.EventHandler(this.buttonBlockchain_Click);
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.SystemColors.Control;
            this.panelMain.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelMain.BackgroundImage")));
            this.panelMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelMain.Controls.Add(this.mainWalletControl);
            this.panelMain.Controls.Add(this.mainBlockchainBrowserControl);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 31);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(2);
            this.panelMain.Size = new System.Drawing.Size(1093, 538);
            this.panelMain.TabIndex = 1;
            // 
            // mainWalletControl
            // 
            this.mainWalletControl.BackColor = System.Drawing.Color.White;
            this.mainWalletControl.Location = new System.Drawing.Point(498, 91);
            this.mainWalletControl.Name = "mainWalletControl";
            this.mainWalletControl.Size = new System.Drawing.Size(475, 299);
            this.mainWalletControl.TabIndex = 1;
            this.mainWalletControl.Visible = false;
            // 
            // mainBlockchainBrowserControl
            // 
            this.mainBlockchainBrowserControl.BackColor = System.Drawing.Color.White;
            this.mainBlockchainBrowserControl.Location = new System.Drawing.Point(21, 38);
            this.mainBlockchainBrowserControl.Name = "mainBlockchainBrowserControl";
            this.mainBlockchainBrowserControl.Size = new System.Drawing.Size(449, 214);
            this.mainBlockchainBrowserControl.TabIndex = 0;
            this.mainBlockchainBrowserControl.Visible = false;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.groupBoxNotifications);
            this.panelBottom.Controls.Add(this.groupBoxStatus);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 569);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1093, 112);
            this.panelBottom.TabIndex = 2;
            // 
            // groupBoxNotifications
            // 
            this.groupBoxNotifications.Controls.Add(this.panelNotifications);
            this.groupBoxNotifications.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxNotifications.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBoxNotifications.Location = new System.Drawing.Point(253, 0);
            this.groupBoxNotifications.Name = "groupBoxNotifications";
            this.groupBoxNotifications.Size = new System.Drawing.Size(840, 112);
            this.groupBoxNotifications.TabIndex = 0;
            this.groupBoxNotifications.TabStop = false;
            this.groupBoxNotifications.Text = "Notifications";
            // 
            // panelNotifications
            // 
            this.panelNotifications.AutoScroll = true;
            this.panelNotifications.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelNotifications.Location = new System.Drawing.Point(3, 19);
            this.panelNotifications.Name = "panelNotifications";
            this.panelNotifications.Size = new System.Drawing.Size(834, 90);
            this.panelNotifications.TabIndex = 0;
            // 
            // groupBoxStatus
            // 
            this.groupBoxStatus.Controls.Add(this.bottomStatusControl1);
            this.groupBoxStatus.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBoxStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBoxStatus.Location = new System.Drawing.Point(0, 0);
            this.groupBoxStatus.Name = "groupBoxStatus";
            this.groupBoxStatus.Size = new System.Drawing.Size(253, 112);
            this.groupBoxStatus.TabIndex = 1;
            this.groupBoxStatus.TabStop = false;
            this.groupBoxStatus.Text = "Blockchain Status";
            // 
            // bottomStatusControl1
            // 
            this.bottomStatusControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bottomStatusControl1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bottomStatusControl1.Location = new System.Drawing.Point(3, 19);
            this.bottomStatusControl1.Name = "bottomStatusControl1";
            this.bottomStatusControl1.Size = new System.Drawing.Size(247, 90);
            this.bottomStatusControl1.TabIndex = 0;
            // 
            // timerInit
            // 
            this.timerInit.Enabled = true;
            this.timerInit.Interval = 10;
            this.timerInit.Tick += new System.EventHandler(this.timerInit_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 681);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.toolStripMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zilliqa Desktop Wallet";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            this.groupBoxNotifications.ResumeLayout(false);
            this.groupBoxStatus.ResumeLayout(false);
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
        private ToolStripButton buttonTokens;
        private Controls.Main.MainWalletControl mainWalletControl;
        private Controls.Main.MainBlockchainBrowserControl mainBlockchainBrowserControl;
        private Panel panelBottom;
        private GroupBox groupBoxNotifications;
        private Panel panelNotifications;
        private GroupBox groupBoxStatus;
        private System.Windows.Forms.Timer timerInit;
        private Controls.Main.BottomStatusControl bottomStatusControl1;
    }
}