namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Main
{
    partial class MainWalletControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWalletControl));
            this.splitContainerWallet = new System.Windows.Forms.SplitContainer();
            this.panelWalletList = new System.Windows.Forms.Panel();
            this.panelWatchedAccounts = new System.Windows.Forms.Panel();
            this.walletListItemControl2 = new Zilliqa.DesktopWallet.Gui.WinForms.Controls.Wallet.WalletListItemControl();
            this.panelMyAccounts = new System.Windows.Forms.Panel();
            this.walletListItemControl1 = new Zilliqa.DesktopWallet.Gui.WinForms.Controls.Wallet.WalletListItemControl();
            this.toolStripWalletList = new System.Windows.Forms.ToolStrip();
            this.buttonCreate = new System.Windows.Forms.ToolStripButton();
            this.toolImport = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerWallet)).BeginInit();
            this.splitContainerWallet.Panel1.SuspendLayout();
            this.splitContainerWallet.SuspendLayout();
            this.panelWalletList.SuspendLayout();
            this.panelWatchedAccounts.SuspendLayout();
            this.panelMyAccounts.SuspendLayout();
            this.toolStripWalletList.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerWallet
            // 
            this.splitContainerWallet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerWallet.Location = new System.Drawing.Point(0, 0);
            this.splitContainerWallet.Name = "splitContainerWallet";
            // 
            // splitContainerWallet.Panel1
            // 
            this.splitContainerWallet.Panel1.Controls.Add(this.panelWalletList);
            this.splitContainerWallet.Panel1.Controls.Add(this.toolStripWalletList);
            this.splitContainerWallet.Panel1MinSize = 200;
            this.splitContainerWallet.Size = new System.Drawing.Size(797, 491);
            this.splitContainerWallet.SplitterDistance = 200;
            this.splitContainerWallet.TabIndex = 0;
            // 
            // panelWalletList
            // 
            this.panelWalletList.AutoScroll = true;
            this.panelWalletList.Controls.Add(this.panelWatchedAccounts);
            this.panelWalletList.Controls.Add(this.panelMyAccounts);
            this.panelWalletList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWalletList.Location = new System.Drawing.Point(0, 31);
            this.panelWalletList.Name = "panelWalletList";
            this.panelWalletList.Size = new System.Drawing.Size(200, 460);
            this.panelWalletList.TabIndex = 1;
            // 
            // panelWatchedAccounts
            // 
            this.panelWatchedAccounts.AutoSize = true;
            this.panelWatchedAccounts.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelWatchedAccounts.Controls.Add(this.walletListItemControl2);
            this.panelWatchedAccounts.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelWatchedAccounts.Location = new System.Drawing.Point(0, 56);
            this.panelWatchedAccounts.Name = "panelWatchedAccounts";
            this.panelWatchedAccounts.Size = new System.Drawing.Size(200, 56);
            this.panelWatchedAccounts.TabIndex = 2;
            // 
            // walletListItemControl2
            // 
            this.walletListItemControl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.walletListItemControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.walletListItemControl2.IsSelected = false;
            this.walletListItemControl2.Location = new System.Drawing.Point(0, 0);
            this.walletListItemControl2.Name = "walletListItemControl2";
            this.walletListItemControl2.Size = new System.Drawing.Size(200, 56);
            this.walletListItemControl2.TabIndex = 1;
            // 
            // panelMyAccounts
            // 
            this.panelMyAccounts.AutoSize = true;
            this.panelMyAccounts.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelMyAccounts.Controls.Add(this.walletListItemControl1);
            this.panelMyAccounts.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMyAccounts.Location = new System.Drawing.Point(0, 0);
            this.panelMyAccounts.Name = "panelMyAccounts";
            this.panelMyAccounts.Size = new System.Drawing.Size(200, 56);
            this.panelMyAccounts.TabIndex = 1;
            // 
            // walletListItemControl1
            // 
            this.walletListItemControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.walletListItemControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.walletListItemControl1.IsSelected = false;
            this.walletListItemControl1.Location = new System.Drawing.Point(0, 0);
            this.walletListItemControl1.Name = "walletListItemControl1";
            this.walletListItemControl1.Size = new System.Drawing.Size(200, 56);
            this.walletListItemControl1.TabIndex = 1;
            // 
            // toolStripWalletList
            // 
            this.toolStripWalletList.CanOverflow = false;
            this.toolStripWalletList.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripWalletList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonCreate,
            this.toolImport});
            this.toolStripWalletList.Location = new System.Drawing.Point(0, 0);
            this.toolStripWalletList.Name = "toolStripWalletList";
            this.toolStripWalletList.Size = new System.Drawing.Size(200, 31);
            this.toolStripWalletList.TabIndex = 0;
            this.toolStripWalletList.Text = "toolStrip1";
            // 
            // buttonCreate
            // 
            this.buttonCreate.Image = ((System.Drawing.Image)(resources.GetObject("buttonCreate.Image")));
            this.buttonCreate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(69, 28);
            this.buttonCreate.Text = "Create";
            // 
            // toolImport
            // 
            this.toolImport.Image = ((System.Drawing.Image)(resources.GetObject("toolImport.Image")));
            this.toolImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolImport.Name = "toolImport";
            this.toolImport.Size = new System.Drawing.Size(71, 28);
            this.toolImport.Text = "Import";
            // 
            // MainWalletControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerWallet);
            this.Name = "MainWalletControl";
            this.Size = new System.Drawing.Size(797, 491);
            this.splitContainerWallet.Panel1.ResumeLayout(false);
            this.splitContainerWallet.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerWallet)).EndInit();
            this.splitContainerWallet.ResumeLayout(false);
            this.panelWalletList.ResumeLayout(false);
            this.panelWalletList.PerformLayout();
            this.panelWatchedAccounts.ResumeLayout(false);
            this.panelMyAccounts.ResumeLayout(false);
            this.toolStripWalletList.ResumeLayout(false);
            this.toolStripWalletList.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainer splitContainerWallet;
        private Panel panelWalletList;
        private ToolStrip toolStripWalletList;
        private ToolStripButton buttonCreate;
        private ToolStripButton toolImport;
        private Panel panelWatchedAccounts;
        private Wallet.WalletListItemControl walletListItemControl2;
        private Panel panelMyAccounts;
        private Wallet.WalletListItemControl walletListItemControl1;
    }
}
