namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Wallet
{
    partial class WalletAddressDetails
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WalletAddressDetails));
            this.toolStripAccountActions = new System.Windows.Forms.ToolStrip();
            this.buttonSend = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.separatorSend = new System.Windows.Forms.ToolStripSeparator();
            this.buttonBackupPrivateKey = new System.Windows.Forms.ToolStripButton();
            this.separatorBackup = new System.Windows.Forms.ToolStripSeparator();
            this.buttonRemoveAccount = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.labelTokensValueUsd = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.labelZilValueUsd = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.labelTotalValueUsd = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.labelZilStakedBalance = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelZilLiquidBalance = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelZilTotalBalance = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBoxTokens = new System.Windows.Forms.GroupBox();
            this.gridViewTokenBalances = new Zilliqa.DesktopWallet.Gui.WinForms.Controls.GridView.GridViewControl();
            this.gridViewZilTransactions = new Zilliqa.DesktopWallet.Gui.WinForms.Controls.GridView.GridViewControl();
            this.gridViewTokenTransactions = new Zilliqa.DesktopWallet.Gui.WinForms.Controls.GridView.GridViewControl();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonOpenBlockExplorer = new System.Windows.Forms.Button();
            this.buttonClipboardAddress = new System.Windows.Forms.Button();
            this.textZilAddress = new System.Windows.Forms.Label();
            this.timerButtonPressed = new System.Windows.Forms.Timer(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panelTabs = new System.Windows.Forms.Panel();
            this.panelTabPages = new System.Windows.Forms.Panel();
            this.toolStripTransactions = new System.Windows.Forms.ToolStrip();
            this.tabButtonZilTransactions = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tabButtonTokenTransactions = new System.Windows.Forms.ToolStripButton();
            this.toolStripAccountActions.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBoxTokens.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panelTabs.SuspendLayout();
            this.panelTabPages.SuspendLayout();
            this.toolStripTransactions.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripAccountActions
            // 
            this.toolStripAccountActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonSend,
            this.toolStripButton1,
            this.separatorSend,
            this.buttonBackupPrivateKey,
            this.separatorBackup,
            this.buttonRemoveAccount});
            this.toolStripAccountActions.Location = new System.Drawing.Point(0, 0);
            this.toolStripAccountActions.Name = "toolStripAccountActions";
            this.toolStripAccountActions.Size = new System.Drawing.Size(653, 25);
            this.toolStripAccountActions.TabIndex = 1;
            // 
            // buttonSend
            // 
            this.buttonSend.Image = ((System.Drawing.Image)(resources.GetObject("buttonSend.Image")));
            this.buttonSend.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(72, 22);
            this.buttonSend.Text = "Send ZIL";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(136, 22);
            this.toolStripButton1.Text = "Send Fungible Token";
            // 
            // separatorSend
            // 
            this.separatorSend.Name = "separatorSend";
            this.separatorSend.Size = new System.Drawing.Size(6, 25);
            // 
            // buttonBackupPrivateKey
            // 
            this.buttonBackupPrivateKey.Image = ((System.Drawing.Image)(resources.GetObject("buttonBackupPrivateKey.Image")));
            this.buttonBackupPrivateKey.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonBackupPrivateKey.Name = "buttonBackupPrivateKey";
            this.buttonBackupPrivateKey.Size = new System.Drawing.Size(127, 22);
            this.buttonBackupPrivateKey.Text = "Backup Private Key";
            // 
            // separatorBackup
            // 
            this.separatorBackup.Name = "separatorBackup";
            this.separatorBackup.Size = new System.Drawing.Size(6, 25);
            // 
            // buttonRemoveAccount
            // 
            this.buttonRemoveAccount.Image = ((System.Drawing.Image)(resources.GetObject("buttonRemoveAccount.Image")));
            this.buttonRemoveAccount.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonRemoveAccount.Name = "buttonRemoveAccount";
            this.buttonRemoveAccount.Size = new System.Drawing.Size(118, 22);
            this.buttonRemoveAccount.Text = "Remove Account";
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.panel5);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(0, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(653, 68);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Balance Details";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Controls.Add(this.panel8);
            this.panel5.Controls.Add(this.pictureBox2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(3, 42);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(647, 23);
            this.panel5.TabIndex = 2;
            // 
            // panel6
            // 
            this.panel6.AutoSize = true;
            this.panel6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel6.Controls.Add(this.labelTokensValueUsd);
            this.panel6.Controls.Add(this.label8);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel6.Location = new System.Drawing.Point(335, 0);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.panel6.Size = new System.Drawing.Size(180, 23);
            this.panel6.TabIndex = 3;
            // 
            // labelTokensValueUsd
            // 
            this.labelTokensValueUsd.AutoSize = true;
            this.labelTokensValueUsd.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelTokensValueUsd.Location = new System.Drawing.Point(111, 0);
            this.labelTokensValueUsd.Name = "labelTokensValueUsd";
            this.labelTokensValueUsd.Padding = new System.Windows.Forms.Padding(3);
            this.labelTokensValueUsd.Size = new System.Drawing.Size(59, 21);
            this.labelTokensValueUsd.TabIndex = 2;
            this.labelTokensValueUsd.Text = "0.00 USD";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Left;
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(3);
            this.label8.Size = new System.Drawing.Size(111, 21);
            this.label8.TabIndex = 1;
            this.label8.Text = "Total Tokens Value:";
            // 
            // panel7
            // 
            this.panel7.AutoSize = true;
            this.panel7.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel7.Controls.Add(this.labelZilValueUsd);
            this.panel7.Controls.Add(this.label10);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel7.Location = new System.Drawing.Point(175, 0);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.panel7.Size = new System.Drawing.Size(160, 23);
            this.panel7.TabIndex = 2;
            // 
            // labelZilValueUsd
            // 
            this.labelZilValueUsd.AutoSize = true;
            this.labelZilValueUsd.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelZilValueUsd.Location = new System.Drawing.Point(91, 0);
            this.labelZilValueUsd.Name = "labelZilValueUsd";
            this.labelZilValueUsd.Padding = new System.Windows.Forms.Padding(3);
            this.labelZilValueUsd.Size = new System.Drawing.Size(59, 21);
            this.labelZilValueUsd.TabIndex = 2;
            this.labelZilValueUsd.Text = "0.00 USD";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Left;
            this.label10.Location = new System.Drawing.Point(0, 0);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(3);
            this.label10.Size = new System.Drawing.Size(91, 21);
            this.label10.TabIndex = 1;
            this.label10.Text = "Total ZIL Value:";
            // 
            // panel8
            // 
            this.panel8.AutoSize = true;
            this.panel8.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel8.Controls.Add(this.labelTotalValueUsd);
            this.panel8.Controls.Add(this.label12);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel8.Location = new System.Drawing.Point(24, 0);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.panel8.Size = new System.Drawing.Size(151, 23);
            this.panel8.TabIndex = 1;
            // 
            // labelTotalValueUsd
            // 
            this.labelTotalValueUsd.AutoSize = true;
            this.labelTotalValueUsd.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelTotalValueUsd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTotalValueUsd.Location = new System.Drawing.Point(76, 0);
            this.labelTotalValueUsd.Name = "labelTotalValueUsd";
            this.labelTotalValueUsd.Padding = new System.Windows.Forms.Padding(3);
            this.labelTotalValueUsd.Size = new System.Drawing.Size(65, 21);
            this.labelTotalValueUsd.TabIndex = 2;
            this.labelTotalValueUsd.Text = "0.00 USD";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Left;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(0, 0);
            this.label12.Name = "label12";
            this.label12.Padding = new System.Windows.Forms.Padding(3);
            this.label12.Size = new System.Drawing.Size(76, 21);
            this.label12.TabIndex = 1;
            this.label12.Text = "Total Value:";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(24, 23);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(647, 23);
            this.panel1.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.AutoSize = true;
            this.panel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel4.Controls.Add(this.labelZilStakedBalance);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel4.Location = new System.Drawing.Point(326, 0);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.panel4.Size = new System.Drawing.Size(158, 23);
            this.panel4.TabIndex = 3;
            // 
            // labelZilStakedBalance
            // 
            this.labelZilStakedBalance.AutoSize = true;
            this.labelZilStakedBalance.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelZilStakedBalance.Location = new System.Drawing.Point(105, 0);
            this.labelZilStakedBalance.Name = "labelZilStakedBalance";
            this.labelZilStakedBalance.Padding = new System.Windows.Forms.Padding(3);
            this.labelZilStakedBalance.Size = new System.Drawing.Size(53, 21);
            this.labelZilStakedBalance.TabIndex = 2;
            this.labelZilStakedBalance.Text = "0.00 ZIL";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.Location = new System.Drawing.Point(10, 0);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(3);
            this.label6.Size = new System.Drawing.Size(95, 21);
            this.label6.TabIndex = 1;
            this.label6.Text = "Staked Balance:";
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel3.Controls.Add(this.labelZilLiquidBalance);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel3.Location = new System.Drawing.Point(170, 0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.panel3.Size = new System.Drawing.Size(156, 23);
            this.panel3.TabIndex = 2;
            // 
            // labelZilLiquidBalance
            // 
            this.labelZilLiquidBalance.AutoSize = true;
            this.labelZilLiquidBalance.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelZilLiquidBalance.Location = new System.Drawing.Point(103, 0);
            this.labelZilLiquidBalance.Name = "labelZilLiquidBalance";
            this.labelZilLiquidBalance.Padding = new System.Windows.Forms.Padding(3);
            this.labelZilLiquidBalance.Size = new System.Drawing.Size(53, 21);
            this.labelZilLiquidBalance.TabIndex = 2;
            this.labelZilLiquidBalance.Text = "0.00 ZIL";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Location = new System.Drawing.Point(10, 0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(3);
            this.label4.Size = new System.Drawing.Size(93, 21);
            this.label4.TabIndex = 1;
            this.label4.Text = "Liquid Balance:";
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.Controls.Add(this.labelZilTotalBalance);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.panel2.Location = new System.Drawing.Point(24, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(146, 23);
            this.panel2.TabIndex = 1;
            // 
            // labelZilTotalBalance
            // 
            this.labelZilTotalBalance.AutoSize = true;
            this.labelZilTotalBalance.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelZilTotalBalance.Location = new System.Drawing.Point(89, 0);
            this.labelZilTotalBalance.Name = "labelZilTotalBalance";
            this.labelZilTotalBalance.Padding = new System.Windows.Forms.Padding(3);
            this.labelZilTotalBalance.Size = new System.Drawing.Size(57, 21);
            this.labelZilTotalBalance.TabIndex = 2;
            this.labelZilTotalBalance.Text = "0.00 ZIL";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(3);
            this.label1.Size = new System.Drawing.Size(89, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Total Balance:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 23);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // groupBoxTokens
            // 
            this.groupBoxTokens.Controls.Add(this.gridViewTokenBalances);
            this.groupBoxTokens.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxTokens.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBoxTokens.Location = new System.Drawing.Point(0, 148);
            this.groupBoxTokens.Name = "groupBoxTokens";
            this.groupBoxTokens.Size = new System.Drawing.Size(653, 105);
            this.groupBoxTokens.TabIndex = 1;
            this.groupBoxTokens.TabStop = false;
            this.groupBoxTokens.Text = "ZRC-2 Tokens";
            // 
            // gridViewTokenBalances
            // 
            this.gridViewTokenBalances.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridViewTokenBalances.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gridViewTokenBalances.Location = new System.Drawing.Point(3, 19);
            this.gridViewTokenBalances.Name = "gridViewTokenBalances";
            this.gridViewTokenBalances.Size = new System.Drawing.Size(647, 83);
            this.gridViewTokenBalances.TabIndex = 0;
            // 
            // gridViewZilTransactions
            // 
            this.gridViewZilTransactions.Location = new System.Drawing.Point(16, 16);
            this.gridViewZilTransactions.Name = "gridViewZilTransactions";
            this.gridViewZilTransactions.Size = new System.Drawing.Size(131, 111);
            this.gridViewZilTransactions.TabIndex = 1;
            this.gridViewZilTransactions.Visible = false;
            // 
            // gridViewTokenTransactions
            // 
            this.gridViewTokenTransactions.Location = new System.Drawing.Point(174, 16);
            this.gridViewTokenTransactions.Name = "gridViewTokenTransactions";
            this.gridViewTokenTransactions.Size = new System.Drawing.Size(143, 111);
            this.gridViewTokenTransactions.TabIndex = 1;
            this.gridViewTokenTransactions.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonOpenBlockExplorer);
            this.groupBox3.Controls.Add(this.buttonClipboardAddress);
            this.groupBox3.Controls.Add(this.textZilAddress);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox3.Location = new System.Drawing.Point(0, 25);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox3.Size = new System.Drawing.Size(653, 55);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Recivement Address";
            // 
            // buttonOpenBlockExplorer
            // 
            this.buttonOpenBlockExplorer.AutoSize = true;
            this.buttonOpenBlockExplorer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonOpenBlockExplorer.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonOpenBlockExplorer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonOpenBlockExplorer.Image = ((System.Drawing.Image)(resources.GetObject("buttonOpenBlockExplorer.Image")));
            this.buttonOpenBlockExplorer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonOpenBlockExplorer.Location = new System.Drawing.Point(368, 22);
            this.buttonOpenBlockExplorer.Name = "buttonOpenBlockExplorer";
            this.buttonOpenBlockExplorer.Padding = new System.Windows.Forms.Padding(2);
            this.buttonOpenBlockExplorer.Size = new System.Drawing.Size(157, 27);
            this.buttonOpenBlockExplorer.TabIndex = 2;
            this.buttonOpenBlockExplorer.Text = "Open in Block Explorer";
            this.buttonOpenBlockExplorer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonOpenBlockExplorer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonOpenBlockExplorer.UseVisualStyleBackColor = true;
            this.buttonOpenBlockExplorer.Click += new System.EventHandler(this.buttonOpenBlockExplorer_Click);
            // 
            // buttonClipboardAddress
            // 
            this.buttonClipboardAddress.AutoSize = true;
            this.buttonClipboardAddress.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonClipboardAddress.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonClipboardAddress.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonClipboardAddress.Image = ((System.Drawing.Image)(resources.GetObject("buttonClipboardAddress.Image")));
            this.buttonClipboardAddress.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonClipboardAddress.Location = new System.Drawing.Point(191, 22);
            this.buttonClipboardAddress.Name = "buttonClipboardAddress";
            this.buttonClipboardAddress.Padding = new System.Windows.Forms.Padding(2);
            this.buttonClipboardAddress.Size = new System.Drawing.Size(177, 27);
            this.buttonClipboardAddress.TabIndex = 1;
            this.buttonClipboardAddress.Text = "Copy Address to clipboard";
            this.buttonClipboardAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonClipboardAddress.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonClipboardAddress.UseVisualStyleBackColor = true;
            this.buttonClipboardAddress.Click += new System.EventHandler(this.buttonClipboardAddress_Click);
            // 
            // textZilAddress
            // 
            this.textZilAddress.AutoSize = true;
            this.textZilAddress.Dock = System.Windows.Forms.DockStyle.Left;
            this.textZilAddress.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textZilAddress.Location = new System.Drawing.Point(6, 22);
            this.textZilAddress.Name = "textZilAddress";
            this.textZilAddress.Padding = new System.Windows.Forms.Padding(0, 0, 25, 0);
            this.textZilAddress.Size = new System.Drawing.Size(185, 21);
            this.textZilAddress.TabIndex = 0;
            this.textZilAddress.Text = "zil1xxxxxxxxxxxxxxxxxx";
            // 
            // timerButtonPressed
            // 
            this.timerButtonPressed.Interval = 2000;
            this.timerButtonPressed.Tick += new System.EventHandler(this.timerButtonPressed_Tick);
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.Gainsboro;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 253);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(653, 4);
            this.splitter1.TabIndex = 7;
            this.splitter1.TabStop = false;
            // 
            // panelTabs
            // 
            this.panelTabs.Controls.Add(this.panelTabPages);
            this.panelTabs.Controls.Add(this.toolStripTransactions);
            this.panelTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTabs.Location = new System.Drawing.Point(0, 257);
            this.panelTabs.Name = "panelTabs";
            this.panelTabs.Size = new System.Drawing.Size(653, 279);
            this.panelTabs.TabIndex = 8;
            // 
            // panelTabPages
            // 
            this.panelTabPages.Controls.Add(this.gridViewZilTransactions);
            this.panelTabPages.Controls.Add(this.gridViewTokenTransactions);
            this.panelTabPages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTabPages.Location = new System.Drawing.Point(0, 25);
            this.panelTabPages.Name = "panelTabPages";
            this.panelTabPages.Size = new System.Drawing.Size(653, 254);
            this.panelTabPages.TabIndex = 2;
            // 
            // toolStripTransactions
            // 
            this.toolStripTransactions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tabButtonZilTransactions,
            this.toolStripSeparator1,
            this.tabButtonTokenTransactions});
            this.toolStripTransactions.Location = new System.Drawing.Point(0, 0);
            this.toolStripTransactions.Name = "toolStripTransactions";
            this.toolStripTransactions.Size = new System.Drawing.Size(653, 25);
            this.toolStripTransactions.TabIndex = 0;
            // 
            // tabButtonZilTransactions
            // 
            this.tabButtonZilTransactions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tabButtonZilTransactions.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabButtonZilTransactions.Image = ((System.Drawing.Image)(resources.GetObject("tabButtonZilTransactions.Image")));
            this.tabButtonZilTransactions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tabButtonZilTransactions.Name = "tabButtonZilTransactions";
            this.tabButtonZilTransactions.Size = new System.Drawing.Size(95, 22);
            this.tabButtonZilTransactions.Text = "ZIL Transactions";
            this.tabButtonZilTransactions.Click += new System.EventHandler(this.tabButtonZilTransactions_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tabButtonTokenTransactions
            // 
            this.tabButtonTokenTransactions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tabButtonTokenTransactions.Image = ((System.Drawing.Image)(resources.GetObject("tabButtonTokenTransactions.Image")));
            this.tabButtonTokenTransactions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tabButtonTokenTransactions.Name = "tabButtonTokenTransactions";
            this.tabButtonTokenTransactions.Size = new System.Drawing.Size(146, 22);
            this.tabButtonTokenTransactions.Text = "ZRC-2 Token Transactions";
            this.tabButtonTokenTransactions.Click += new System.EventHandler(this.tabButtonTokenTransactions_Click);
            // 
            // WalletAddressDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelTabs);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.groupBoxTokens);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.toolStripAccountActions);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "WalletAddressDetails";
            this.Size = new System.Drawing.Size(653, 536);
            this.Load += new System.EventHandler(this.WalletAddressDetails_Load);
            this.toolStripAccountActions.ResumeLayout(false);
            this.toolStripAccountActions.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBoxTokens.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panelTabs.ResumeLayout(false);
            this.panelTabs.PerformLayout();
            this.panelTabPages.ResumeLayout(false);
            this.toolStripTransactions.ResumeLayout(false);
            this.toolStripTransactions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ToolStrip toolStripAccountActions;
        private ToolStripButton buttonSend;
        private ToolStripSeparator separatorSend;
        private ToolStripButton buttonBackupPrivateKey;
        private GroupBox groupBox1;
        private Panel panel1;
        private Panel panel4;
        private Label labelZilStakedBalance;
        private Label label6;
        private Panel panel3;
        private Label labelZilLiquidBalance;
        private Label label4;
        private Panel panel2;
        private Label labelZilTotalBalance;
        private Label label1;
        private PictureBox pictureBox1;
        private Panel panel5;
        private Panel panel6;
        private Label labelTokensValueUsd;
        private Label label8;
        private Panel panel7;
        private Label labelZilValueUsd;
        private Label label10;
        private Panel panel8;
        private Label labelTotalValueUsd;
        private Label label12;
        private PictureBox pictureBox2;
        private GridView.GridViewControl gridViewTokenBalances;
        private GridView.GridViewControl gridViewZilTransactions;
        private GroupBox groupBoxTokens;
        private GridView.GridViewControl gridViewTokenTransactions;
        private GroupBox groupBox3;
        private Button buttonClipboardAddress;
        private Label textZilAddress;
        private Button buttonOpenBlockExplorer;
        private System.Windows.Forms.Timer timerButtonPressed;
        private ToolStripSeparator separatorBackup;
        private ToolStripButton buttonRemoveAccount;
        private ToolStripButton toolStripButton1;
        private Splitter splitter1;
        private Panel panelTabs;
        private ToolStrip toolStripTransactions;
        private ToolStripButton tabButtonZilTransactions;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton tabButtonTokenTransactions;
        private Panel panelTabPages;
    }
}
