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
            this.buttonSmartContracts = new System.Windows.Forms.ToolStripButton();
            this.buttonEcosystem = new System.Windows.Forms.ToolStripButton();
            this.buttonStakingNodes = new System.Windows.Forms.ToolStripButton();
            this.buttonBlockchain = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonSettings = new System.Windows.Forms.ToolStripDropDownButton();
            this.settingMenuDisplayCurrencies = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuFiat = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDisplayCurrencyEur = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDisplayCurrencyChf = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDisplayCurrencyGbp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuCrypto = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDisplayCurrencyBtc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDisplayCurrencyEth = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDisplayCurrencyLtc = new System.Windows.Forms.ToolStripMenuItem();
            this.settingMenuIncomingSound = new System.Windows.Forms.ToolStripMenuItem();
            this.menuIncomingSoundNone = new System.Windows.Forms.ToolStripMenuItem();
            this.menuIncomingSoundMoneyCounter = new System.Windows.Forms.ToolStripMenuItem();
            this.menuIncomingSoundKaChing = new System.Windows.Forms.ToolStripMenuItem();
            this.menuIncomingSoundCoinDrop = new System.Windows.Forms.ToolStripMenuItem();
            this.settingMenuWhale = new System.Windows.Forms.ToolStripMenuItem();
            this.settingMenuWhaleNone = new System.Windows.Forms.ToolStripMenuItem();
            this.settingMenuWhale10K = new System.Windows.Forms.ToolStripMenuItem();
            this.settingMenuWhale50K = new System.Windows.Forms.ToolStripMenuItem();
            this.settingMenuWhale100K = new System.Windows.Forms.ToolStripMenuItem();
            this.settingMenuWhale500K = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonAbout = new System.Windows.Forms.ToolStripDropDownButton();
            this.menuApplicationInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonMenuTools = new System.Windows.Forms.ToolStripDropDownButton();
            this.buttonToolsAddressConverter = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonToolsSearchWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonToolsOpenWalletFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonToolsOpenDbFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.panelMain = new System.Windows.Forms.Panel();
            this.mainWalletControl = new Zilliqa.DesktopWallet.Gui.WinForms.Controls.Main.MainWalletControl();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.groupBoxNotifications = new System.Windows.Forms.GroupBox();
            this.bottomNotifications = new Zilliqa.DesktopWallet.Gui.WinForms.Controls.Main.BottomNotificationsControl();
            this.groupBoxStatus = new System.Windows.Forms.GroupBox();
            this.bottomStatus = new Zilliqa.DesktopWallet.Gui.WinForms.Controls.Main.BottomStatusControl();
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
            this.buttonSmartContracts,
            this.buttonEcosystem,
            this.buttonStakingNodes,
            this.buttonBlockchain,
            this.toolStripSeparator1,
            this.buttonSettings,
            this.buttonAbout,
            this.buttonMenuTools});
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(1239, 31);
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
            this.buttonTokens.Size = new System.Drawing.Size(71, 28);
            this.buttonTokens.Text = "Tokens";
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
            // buttonSmartContracts
            // 
            this.buttonSmartContracts.Image = ((System.Drawing.Image)(resources.GetObject("buttonSmartContracts.Image")));
            this.buttonSmartContracts.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonSmartContracts.Name = "buttonSmartContracts";
            this.buttonSmartContracts.Size = new System.Drawing.Size(120, 28);
            this.buttonSmartContracts.Text = "Smart Contracts";
            this.buttonSmartContracts.Click += new System.EventHandler(this.buttonSmartContracts_Click);
            // 
            // buttonEcosystem
            // 
            this.buttonEcosystem.Image = ((System.Drawing.Image)(resources.GetObject("buttonEcosystem.Image")));
            this.buttonEcosystem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonEcosystem.Name = "buttonEcosystem";
            this.buttonEcosystem.Size = new System.Drawing.Size(91, 28);
            this.buttonEcosystem.Text = "Ecosystem";
            this.buttonEcosystem.Click += new System.EventHandler(this.buttonEcosystem_Click);
            // 
            // buttonStakingNodes
            // 
            this.buttonStakingNodes.Image = ((System.Drawing.Image)(resources.GetObject("buttonStakingNodes.Image")));
            this.buttonStakingNodes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonStakingNodes.Name = "buttonStakingNodes";
            this.buttonStakingNodes.Size = new System.Drawing.Size(111, 28);
            this.buttonStakingNodes.Text = "Staking Nodes";
            this.buttonStakingNodes.Click += new System.EventHandler(this.buttonStakingNodes_Click);
            // 
            // buttonBlockchain
            // 
            this.buttonBlockchain.Image = ((System.Drawing.Image)(resources.GetObject("buttonBlockchain.Image")));
            this.buttonBlockchain.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonBlockchain.Name = "buttonBlockchain";
            this.buttonBlockchain.Size = new System.Drawing.Size(131, 28);
            this.buttonBlockchain.Text = "Blockchain Search";
            this.buttonBlockchain.Click += new System.EventHandler(this.buttonBlockchain_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // buttonSettings
            // 
            this.buttonSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingMenuDisplayCurrencies,
            this.settingMenuIncomingSound,
            this.settingMenuWhale});
            this.buttonSettings.Image = ((System.Drawing.Image)(resources.GetObject("buttonSettings.Image")));
            this.buttonSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(86, 28);
            this.buttonSettings.Text = "Settings";
            // 
            // settingMenuDisplayCurrencies
            // 
            this.settingMenuDisplayCurrencies.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuFiat,
            this.menuDisplayCurrencyEur,
            this.menuDisplayCurrencyChf,
            this.menuDisplayCurrencyGbp,
            this.toolStripMenuCrypto,
            this.menuDisplayCurrencyBtc,
            this.menuDisplayCurrencyEth,
            this.menuDisplayCurrencyLtc});
            this.settingMenuDisplayCurrencies.Name = "settingMenuDisplayCurrencies";
            this.settingMenuDisplayCurrencies.Size = new System.Drawing.Size(233, 22);
            this.settingMenuDisplayCurrencies.Text = "Display additional Currencies";
            // 
            // toolStripMenuFiat
            // 
            this.toolStripMenuFiat.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripMenuFiat.Enabled = false;
            this.toolStripMenuFiat.Name = "toolStripMenuFiat";
            this.toolStripMenuFiat.Size = new System.Drawing.Size(178, 22);
            this.toolStripMenuFiat.Text = "Fiat";
            // 
            // menuDisplayCurrencyEur
            // 
            this.menuDisplayCurrencyEur.Name = "menuDisplayCurrencyEur";
            this.menuDisplayCurrencyEur.Size = new System.Drawing.Size(178, 22);
            this.menuDisplayCurrencyEur.Text = "Euro (EUR)";
            this.menuDisplayCurrencyEur.Click += new System.EventHandler(this.menuDisplayCurrencyEur_Click);
            // 
            // menuDisplayCurrencyChf
            // 
            this.menuDisplayCurrencyChf.Name = "menuDisplayCurrencyChf";
            this.menuDisplayCurrencyChf.Size = new System.Drawing.Size(178, 22);
            this.menuDisplayCurrencyChf.Text = "Swiss Franc (CHF)";
            this.menuDisplayCurrencyChf.Click += new System.EventHandler(this.menuDisplayCurrencyChf_Click);
            // 
            // menuDisplayCurrencyGbp
            // 
            this.menuDisplayCurrencyGbp.Name = "menuDisplayCurrencyGbp";
            this.menuDisplayCurrencyGbp.Size = new System.Drawing.Size(178, 22);
            this.menuDisplayCurrencyGbp.Text = "British Pound (GBP)";
            this.menuDisplayCurrencyGbp.Click += new System.EventHandler(this.menuDisplayCurrencyGbp_Click);
            // 
            // toolStripMenuCrypto
            // 
            this.toolStripMenuCrypto.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripMenuCrypto.Enabled = false;
            this.toolStripMenuCrypto.Name = "toolStripMenuCrypto";
            this.toolStripMenuCrypto.Size = new System.Drawing.Size(178, 22);
            this.toolStripMenuCrypto.Text = "Crypto";
            // 
            // menuDisplayCurrencyBtc
            // 
            this.menuDisplayCurrencyBtc.Name = "menuDisplayCurrencyBtc";
            this.menuDisplayCurrencyBtc.Size = new System.Drawing.Size(178, 22);
            this.menuDisplayCurrencyBtc.Text = "Bitcoin (BTC)";
            this.menuDisplayCurrencyBtc.Click += new System.EventHandler(this.menuDisplayCurrencyBtc_Click);
            // 
            // menuDisplayCurrencyEth
            // 
            this.menuDisplayCurrencyEth.Name = "menuDisplayCurrencyEth";
            this.menuDisplayCurrencyEth.Size = new System.Drawing.Size(178, 22);
            this.menuDisplayCurrencyEth.Text = "Ethereum (ETH)";
            this.menuDisplayCurrencyEth.Click += new System.EventHandler(this.menuDisplayCurrencyEth_Click);
            // 
            // menuDisplayCurrencyLtc
            // 
            this.menuDisplayCurrencyLtc.Name = "menuDisplayCurrencyLtc";
            this.menuDisplayCurrencyLtc.Size = new System.Drawing.Size(178, 22);
            this.menuDisplayCurrencyLtc.Text = "Litecoin (LTC)";
            this.menuDisplayCurrencyLtc.Click += new System.EventHandler(this.menuDisplayCurrencyLtc_Click);
            // 
            // settingMenuIncomingSound
            // 
            this.settingMenuIncomingSound.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuIncomingSoundNone,
            this.menuIncomingSoundMoneyCounter,
            this.menuIncomingSoundKaChing,
            this.menuIncomingSoundCoinDrop});
            this.settingMenuIncomingSound.Name = "settingMenuIncomingSound";
            this.settingMenuIncomingSound.Size = new System.Drawing.Size(233, 22);
            this.settingMenuIncomingSound.Text = "Incoming transaction sound";
            // 
            // menuIncomingSoundNone
            // 
            this.menuIncomingSoundNone.Name = "menuIncomingSoundNone";
            this.menuIncomingSoundNone.Size = new System.Drawing.Size(180, 22);
            this.menuIncomingSoundNone.Text = "None";
            this.menuIncomingSoundNone.Click += new System.EventHandler(this.menuIncomingSoundNone_Click);
            // 
            // menuIncomingSoundMoneyCounter
            // 
            this.menuIncomingSoundMoneyCounter.Name = "menuIncomingSoundMoneyCounter";
            this.menuIncomingSoundMoneyCounter.Size = new System.Drawing.Size(180, 22);
            this.menuIncomingSoundMoneyCounter.Text = "Money counter";
            this.menuIncomingSoundMoneyCounter.Click += new System.EventHandler(this.menuIncomingSoundMoneyCounter_Click);
            // 
            // menuIncomingSoundKaChing
            // 
            this.menuIncomingSoundKaChing.Name = "menuIncomingSoundKaChing";
            this.menuIncomingSoundKaChing.Size = new System.Drawing.Size(180, 22);
            this.menuIncomingSoundKaChing.Text = "Cashier (ka-ching)";
            this.menuIncomingSoundKaChing.Click += new System.EventHandler(this.menuIncomingSoundKaChing_Click);
            // 
            // menuIncomingSoundCoinDrop
            // 
            this.menuIncomingSoundCoinDrop.Name = "menuIncomingSoundCoinDrop";
            this.menuIncomingSoundCoinDrop.Size = new System.Drawing.Size(180, 22);
            this.menuIncomingSoundCoinDrop.Text = "Coin drop";
            this.menuIncomingSoundCoinDrop.Click += new System.EventHandler(this.menuIncomingSoundCoinDrop_Click);
            // 
            // settingMenuWhale
            // 
            this.settingMenuWhale.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingMenuWhaleNone,
            this.settingMenuWhale10K,
            this.settingMenuWhale50K,
            this.settingMenuWhale100K,
            this.settingMenuWhale500K});
            this.settingMenuWhale.Name = "settingMenuWhale";
            this.settingMenuWhale.Size = new System.Drawing.Size(233, 22);
            this.settingMenuWhale.Text = "Whale transaction notification";
            // 
            // settingMenuWhaleNone
            // 
            this.settingMenuWhaleNone.Name = "settingMenuWhaleNone";
            this.settingMenuWhaleNone.Size = new System.Drawing.Size(180, 22);
            this.settingMenuWhaleNone.Text = "None";
            this.settingMenuWhaleNone.Click += new System.EventHandler(this.settingMenuWhaleNone_Click);
            // 
            // settingMenuWhale10K
            // 
            this.settingMenuWhale10K.Name = "settingMenuWhale10K";
            this.settingMenuWhale10K.Size = new System.Drawing.Size(180, 22);
            this.settingMenuWhale10K.Text = "Above 10\'000 $";
            this.settingMenuWhale10K.Click += new System.EventHandler(this.settingMenuWhale10K_Click);
            // 
            // settingMenuWhale50K
            // 
            this.settingMenuWhale50K.Name = "settingMenuWhale50K";
            this.settingMenuWhale50K.Size = new System.Drawing.Size(180, 22);
            this.settingMenuWhale50K.Text = "Above 50\'000 $";
            this.settingMenuWhale50K.Click += new System.EventHandler(this.settingMenuWhale50K_Click);
            // 
            // settingMenuWhale100K
            // 
            this.settingMenuWhale100K.Name = "settingMenuWhale100K";
            this.settingMenuWhale100K.Size = new System.Drawing.Size(180, 22);
            this.settingMenuWhale100K.Text = "Above 100\'000 $";
            this.settingMenuWhale100K.Click += new System.EventHandler(this.settingMenuWhale100K_Click);
            // 
            // settingMenuWhale500K
            // 
            this.settingMenuWhale500K.Name = "settingMenuWhale500K";
            this.settingMenuWhale500K.Size = new System.Drawing.Size(180, 22);
            this.settingMenuWhale500K.Text = "Above 500\'000 $";
            this.settingMenuWhale500K.Click += new System.EventHandler(this.settingMenuWhale500K_Click);
            // 
            // buttonAbout
            // 
            this.buttonAbout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.buttonAbout.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuApplicationInfo});
            this.buttonAbout.Image = ((System.Drawing.Image)(resources.GetObject("buttonAbout.Image")));
            this.buttonAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonAbout.Name = "buttonAbout";
            this.buttonAbout.Size = new System.Drawing.Size(77, 28);
            this.buttonAbout.Text = "About";
            this.buttonAbout.Visible = false;
            // 
            // menuApplicationInfo
            // 
            this.menuApplicationInfo.Name = "menuApplicationInfo";
            this.menuApplicationInfo.Size = new System.Drawing.Size(159, 22);
            this.menuApplicationInfo.Text = "Application Info";
            // 
            // buttonMenuTools
            // 
            this.buttonMenuTools.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.buttonMenuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonToolsAddressConverter,
            this.buttonToolsSearchWindow,
            this.toolStripSeparator3,
            this.buttonToolsOpenWalletFolder,
            this.buttonToolsOpenDbFolder});
            this.buttonMenuTools.Image = ((System.Drawing.Image)(resources.GetObject("buttonMenuTools.Image")));
            this.buttonMenuTools.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonMenuTools.Name = "buttonMenuTools";
            this.buttonMenuTools.Size = new System.Drawing.Size(71, 28);
            this.buttonMenuTools.Text = "Tools";
            // 
            // buttonToolsAddressConverter
            // 
            this.buttonToolsAddressConverter.Image = ((System.Drawing.Image)(resources.GetObject("buttonToolsAddressConverter.Image")));
            this.buttonToolsAddressConverter.Name = "buttonToolsAddressConverter";
            this.buttonToolsAddressConverter.Size = new System.Drawing.Size(255, 30);
            this.buttonToolsAddressConverter.Text = "Zilliqa Address Format Converter";
            this.buttonToolsAddressConverter.Click += new System.EventHandler(this.buttonToolsAddressConverter_Click);
            // 
            // buttonToolsSearchWindow
            // 
            this.buttonToolsSearchWindow.Image = ((System.Drawing.Image)(resources.GetObject("buttonToolsSearchWindow.Image")));
            this.buttonToolsSearchWindow.Name = "buttonToolsSearchWindow";
            this.buttonToolsSearchWindow.Size = new System.Drawing.Size(255, 30);
            this.buttonToolsSearchWindow.Text = "Blockchain Search Window";
            this.buttonToolsSearchWindow.Click += new System.EventHandler(this.buttonToolsSearchWindow_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(252, 6);
            // 
            // buttonToolsOpenWalletFolder
            // 
            this.buttonToolsOpenWalletFolder.Image = ((System.Drawing.Image)(resources.GetObject("buttonToolsOpenWalletFolder.Image")));
            this.buttonToolsOpenWalletFolder.Name = "buttonToolsOpenWalletFolder";
            this.buttonToolsOpenWalletFolder.Size = new System.Drawing.Size(255, 30);
            this.buttonToolsOpenWalletFolder.Text = "Open Users Wallet Folder";
            this.buttonToolsOpenWalletFolder.Click += new System.EventHandler(this.buttonToolsOpenWalletFolder_Click);
            // 
            // buttonToolsOpenDbFolder
            // 
            this.buttonToolsOpenDbFolder.Image = ((System.Drawing.Image)(resources.GetObject("buttonToolsOpenDbFolder.Image")));
            this.buttonToolsOpenDbFolder.Name = "buttonToolsOpenDbFolder";
            this.buttonToolsOpenDbFolder.Size = new System.Drawing.Size(255, 30);
            this.buttonToolsOpenDbFolder.Text = "Open Program Database Folder";
            this.buttonToolsOpenDbFolder.Click += new System.EventHandler(this.buttonToolsOpenDbFolder_Click);
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.SystemColors.Control;
            this.panelMain.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelMain.BackgroundImage")));
            this.panelMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelMain.Controls.Add(this.mainWalletControl);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 31);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(2);
            this.panelMain.Size = new System.Drawing.Size(1239, 570);
            this.panelMain.TabIndex = 1;
            // 
            // mainWalletControl
            // 
            this.mainWalletControl.BackColor = System.Drawing.Color.White;
            this.mainWalletControl.Location = new System.Drawing.Point(45, 50);
            this.mainWalletControl.Name = "mainWalletControl";
            this.mainWalletControl.Size = new System.Drawing.Size(475, 299);
            this.mainWalletControl.TabIndex = 1;
            this.mainWalletControl.Visible = false;
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.White;
            this.panelBottom.Controls.Add(this.groupBoxNotifications);
            this.panelBottom.Controls.Add(this.groupBoxStatus);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 601);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1239, 160);
            this.panelBottom.TabIndex = 2;
            this.panelBottom.Visible = false;
            // 
            // groupBoxNotifications
            // 
            this.groupBoxNotifications.Controls.Add(this.bottomNotifications);
            this.groupBoxNotifications.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxNotifications.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBoxNotifications.Location = new System.Drawing.Point(302, 0);
            this.groupBoxNotifications.Name = "groupBoxNotifications";
            this.groupBoxNotifications.Size = new System.Drawing.Size(937, 160);
            this.groupBoxNotifications.TabIndex = 0;
            this.groupBoxNotifications.TabStop = false;
            this.groupBoxNotifications.Text = "Notifications";
            // 
            // bottomNotifications
            // 
            this.bottomNotifications.BackColor = System.Drawing.Color.White;
            this.bottomNotifications.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bottomNotifications.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bottomNotifications.Location = new System.Drawing.Point(3, 19);
            this.bottomNotifications.Name = "bottomNotifications";
            this.bottomNotifications.Size = new System.Drawing.Size(931, 138);
            this.bottomNotifications.TabIndex = 0;
            // 
            // groupBoxStatus
            // 
            this.groupBoxStatus.Controls.Add(this.bottomStatus);
            this.groupBoxStatus.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBoxStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBoxStatus.Location = new System.Drawing.Point(0, 0);
            this.groupBoxStatus.Name = "groupBoxStatus";
            this.groupBoxStatus.Size = new System.Drawing.Size(302, 160);
            this.groupBoxStatus.TabIndex = 1;
            this.groupBoxStatus.TabStop = false;
            this.groupBoxStatus.Text = "Blockchain Status";
            // 
            // bottomStatus
            // 
            this.bottomStatus.BackColor = System.Drawing.Color.White;
            this.bottomStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bottomStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bottomStatus.Location = new System.Drawing.Point(3, 19);
            this.bottomStatus.Name = "bottomStatus";
            this.bottomStatus.Size = new System.Drawing.Size(296, 138);
            this.bottomStatus.TabIndex = 0;
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
            this.ClientSize = new System.Drawing.Size(1239, 761);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.toolStripMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
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
        private Panel panelMain;
        private ToolStripButton buttonTokens;
        private Controls.Main.MainWalletControl mainWalletControl;
        private Panel panelBottom;
        private GroupBox groupBoxNotifications;
        private GroupBox groupBoxStatus;
        private System.Windows.Forms.Timer timerInit;
        private Controls.Main.BottomStatusControl bottomStatus;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem menuDisplayCurrencyEur;
        private ToolStripMenuItem menuDisplayCurrencyChf;
        private ToolStripMenuItem menuDisplayCurrencyGbp;
        private ToolStripMenuItem menuDisplayCurrencyBtc;
        private ToolStripMenuItem menuDisplayCurrencyEth;
        private ToolStripMenuItem menuDisplayCurrencyLtc;
        private ToolStripMenuItem toolStripMenuFiat;
        private ToolStripMenuItem toolStripMenuCrypto;
        private ToolStripButton buttonSmartContracts;
        private ToolStripButton buttonEcosystem;
        private ToolStripButton buttonStakingNodes;
        private ToolStripDropDownButton buttonMenuTools;
        private ToolStripMenuItem buttonToolsOpenWalletFolder;
        private ToolStripMenuItem buttonToolsOpenDbFolder;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem buttonToolsAddressConverter;
        private ToolStripDropDownButton buttonSettings;
        private ToolStripMenuItem settingMenuDisplayCurrencies;
        private ToolStripMenuItem settingMenuIncomingSound;
        private ToolStripMenuItem menuIncomingSoundNone;
        private ToolStripMenuItem menuIncomingSoundMoneyCounter;
        private ToolStripMenuItem menuIncomingSoundKaChing;
        private ToolStripMenuItem menuIncomingSoundCoinDrop;
        private ToolStripDropDownButton buttonAbout;
        private ToolStripMenuItem menuApplicationInfo;
        private Controls.Main.BottomNotificationsControl bottomNotifications;
        private ToolStripMenuItem settingMenuWhale;
        private ToolStripMenuItem settingMenuWhaleNone;
        private ToolStripMenuItem settingMenuWhale10K;
        private ToolStripMenuItem settingMenuWhale50K;
        private ToolStripMenuItem settingMenuWhale100K;
        private ToolStripMenuItem settingMenuWhale500K;
        private ToolStripMenuItem buttonToolsSearchWindow;
    }
}