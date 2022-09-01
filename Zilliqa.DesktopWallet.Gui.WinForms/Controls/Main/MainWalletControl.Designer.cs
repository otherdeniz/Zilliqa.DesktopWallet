namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Main
{
    partial class MainWalletControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWalletControl));
            this.panelWalletList = new System.Windows.Forms.Panel();
            this.groupWatched = new System.Windows.Forms.GroupBox();
            this.panelWatchedAccounts = new System.Windows.Forms.Panel();
            this.walletListItemControl2 = new Zilliqa.DesktopWallet.Gui.WinForms.Controls.Wallet.WalletListItemControl();
            this.toolStripWatchedAccounts = new System.Windows.Forms.ToolStrip();
            this.buttonAddWatched = new System.Windows.Forms.ToolStripButton();
            this.groupMyAccounts = new System.Windows.Forms.GroupBox();
            this.panelMyAccounts = new System.Windows.Forms.Panel();
            this.walletListItemControl1 = new Zilliqa.DesktopWallet.Gui.WinForms.Controls.Wallet.WalletListItemControl();
            this.toolStripWalletList = new System.Windows.Forms.ToolStrip();
            this.buttonCreate = new System.Windows.Forms.ToolStripButton();
            this.toolImport = new System.Windows.Forms.ToolStripButton();
            this.groupAccountDetails = new System.Windows.Forms.GroupBox();
            this.panelAccountDetails = new System.Windows.Forms.Panel();
            this.accountContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeButton = new System.Windows.Forms.ToolStripMenuItem();
            this.splitterLeft = new System.Windows.Forms.Splitter();
            this.panelWalletList.SuspendLayout();
            this.groupWatched.SuspendLayout();
            this.panelWatchedAccounts.SuspendLayout();
            this.toolStripWatchedAccounts.SuspendLayout();
            this.groupMyAccounts.SuspendLayout();
            this.panelMyAccounts.SuspendLayout();
            this.toolStripWalletList.SuspendLayout();
            this.groupAccountDetails.SuspendLayout();
            this.accountContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelWalletList
            // 
            this.panelWalletList.AutoScroll = true;
            this.panelWalletList.Controls.Add(this.groupWatched);
            this.panelWalletList.Controls.Add(this.groupMyAccounts);
            this.panelWalletList.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelWalletList.Location = new System.Drawing.Point(0, 0);
            this.panelWalletList.Name = "panelWalletList";
            this.panelWalletList.Size = new System.Drawing.Size(264, 494);
            this.panelWalletList.TabIndex = 1;
            // 
            // groupWatched
            // 
            this.groupWatched.AutoSize = true;
            this.groupWatched.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupWatched.BackColor = System.Drawing.Color.White;
            this.groupWatched.Controls.Add(this.panelWatchedAccounts);
            this.groupWatched.Controls.Add(this.toolStripWatchedAccounts);
            this.groupWatched.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupWatched.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupWatched.Location = new System.Drawing.Point(0, 111);
            this.groupWatched.Name = "groupWatched";
            this.groupWatched.Size = new System.Drawing.Size(264, 111);
            this.groupWatched.TabIndex = 4;
            this.groupWatched.TabStop = false;
            this.groupWatched.Text = "Watched Accounts";
            // 
            // panelWatchedAccounts
            // 
            this.panelWatchedAccounts.AutoSize = true;
            this.panelWatchedAccounts.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelWatchedAccounts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(204)))));
            this.panelWatchedAccounts.Controls.Add(this.walletListItemControl2);
            this.panelWatchedAccounts.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelWatchedAccounts.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panelWatchedAccounts.Location = new System.Drawing.Point(3, 52);
            this.panelWatchedAccounts.Name = "panelWatchedAccounts";
            this.panelWatchedAccounts.Size = new System.Drawing.Size(258, 56);
            this.panelWatchedAccounts.TabIndex = 2;
            // 
            // walletListItemControl2
            // 
            this.walletListItemControl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.walletListItemControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.walletListItemControl2.IsSelected = false;
            this.walletListItemControl2.Location = new System.Drawing.Point(0, 0);
            this.walletListItemControl2.Name = "walletListItemControl2";
            this.walletListItemControl2.Size = new System.Drawing.Size(258, 56);
            this.walletListItemControl2.TabIndex = 1;
            // 
            // toolStripWatchedAccounts
            // 
            this.toolStripWatchedAccounts.CanOverflow = false;
            this.toolStripWatchedAccounts.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripWatchedAccounts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonAddWatched});
            this.toolStripWatchedAccounts.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStripWatchedAccounts.Location = new System.Drawing.Point(3, 21);
            this.toolStripWatchedAccounts.Name = "toolStripWatchedAccounts";
            this.toolStripWatchedAccounts.Size = new System.Drawing.Size(258, 31);
            this.toolStripWatchedAccounts.TabIndex = 3;
            // 
            // buttonAddWatched
            // 
            this.buttonAddWatched.Image = ((System.Drawing.Image)(resources.GetObject("buttonAddWatched.Image")));
            this.buttonAddWatched.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonAddWatched.Name = "buttonAddWatched";
            this.buttonAddWatched.Size = new System.Drawing.Size(168, 28);
            this.buttonAddWatched.Text = "Add Address to Watchlist";
            this.buttonAddWatched.Click += new System.EventHandler(this.buttonAddWatched_Click);
            // 
            // groupMyAccounts
            // 
            this.groupMyAccounts.AutoSize = true;
            this.groupMyAccounts.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupMyAccounts.BackColor = System.Drawing.Color.White;
            this.groupMyAccounts.Controls.Add(this.panelMyAccounts);
            this.groupMyAccounts.Controls.Add(this.toolStripWalletList);
            this.groupMyAccounts.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupMyAccounts.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupMyAccounts.Location = new System.Drawing.Point(0, 0);
            this.groupMyAccounts.Name = "groupMyAccounts";
            this.groupMyAccounts.Size = new System.Drawing.Size(264, 111);
            this.groupMyAccounts.TabIndex = 3;
            this.groupMyAccounts.TabStop = false;
            this.groupMyAccounts.Text = "My Accounts";
            // 
            // panelMyAccounts
            // 
            this.panelMyAccounts.AutoSize = true;
            this.panelMyAccounts.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelMyAccounts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(255)))), ((int)(((byte)(240)))));
            this.panelMyAccounts.Controls.Add(this.walletListItemControl1);
            this.panelMyAccounts.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMyAccounts.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panelMyAccounts.Location = new System.Drawing.Point(3, 52);
            this.panelMyAccounts.Name = "panelMyAccounts";
            this.panelMyAccounts.Size = new System.Drawing.Size(258, 56);
            this.panelMyAccounts.TabIndex = 1;
            // 
            // walletListItemControl1
            // 
            this.walletListItemControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.walletListItemControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.walletListItemControl1.IsSelected = false;
            this.walletListItemControl1.Location = new System.Drawing.Point(0, 0);
            this.walletListItemControl1.Name = "walletListItemControl1";
            this.walletListItemControl1.Size = new System.Drawing.Size(258, 56);
            this.walletListItemControl1.TabIndex = 1;
            // 
            // toolStripWalletList
            // 
            this.toolStripWalletList.CanOverflow = false;
            this.toolStripWalletList.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripWalletList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonCreate,
            this.toolImport});
            this.toolStripWalletList.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStripWalletList.Location = new System.Drawing.Point(3, 21);
            this.toolStripWalletList.Name = "toolStripWalletList";
            this.toolStripWalletList.Size = new System.Drawing.Size(258, 31);
            this.toolStripWalletList.TabIndex = 0;
            // 
            // buttonCreate
            // 
            this.buttonCreate.Image = ((System.Drawing.Image)(resources.GetObject("buttonCreate.Image")));
            this.buttonCreate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(96, 28);
            this.buttonCreate.Text = "Create New";
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // toolImport
            // 
            this.toolImport.Image = ((System.Drawing.Image)(resources.GetObject("toolImport.Image")));
            this.toolImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolImport.Name = "toolImport";
            this.toolImport.Size = new System.Drawing.Size(121, 28);
            this.toolImport.Text = "Import / Restore";
            this.toolImport.Click += new System.EventHandler(this.toolImport_Click);
            // 
            // groupAccountDetails
            // 
            this.groupAccountDetails.Controls.Add(this.panelAccountDetails);
            this.groupAccountDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupAccountDetails.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupAccountDetails.Location = new System.Drawing.Point(268, 0);
            this.groupAccountDetails.Name = "groupAccountDetails";
            this.groupAccountDetails.Size = new System.Drawing.Size(615, 494);
            this.groupAccountDetails.TabIndex = 1;
            this.groupAccountDetails.TabStop = false;
            this.groupAccountDetails.Text = "Details";
            this.groupAccountDetails.Visible = false;
            // 
            // panelAccountDetails
            // 
            this.panelAccountDetails.AutoScroll = true;
            this.panelAccountDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAccountDetails.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panelAccountDetails.Location = new System.Drawing.Point(3, 21);
            this.panelAccountDetails.Name = "panelAccountDetails";
            this.panelAccountDetails.Size = new System.Drawing.Size(609, 470);
            this.panelAccountDetails.TabIndex = 0;
            // 
            // accountContextMenu
            // 
            this.accountContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeButton});
            this.accountContextMenu.Name = "accountContextMenu";
            this.accountContextMenu.Size = new System.Drawing.Size(118, 26);
            // 
            // removeButton
            // 
            this.removeButton.Image = ((System.Drawing.Image)(resources.GetObject("removeButton.Image")));
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(117, 22);
            this.removeButton.Text = "Remove";
            // 
            // splitterLeft
            // 
            this.splitterLeft.BackColor = System.Drawing.SystemColors.Control;
            this.splitterLeft.Location = new System.Drawing.Point(264, 0);
            this.splitterLeft.Name = "splitterLeft";
            this.splitterLeft.Size = new System.Drawing.Size(4, 494);
            this.splitterLeft.TabIndex = 2;
            this.splitterLeft.TabStop = false;
            // 
            // MainWalletControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupAccountDetails);
            this.Controls.Add(this.splitterLeft);
            this.Controls.Add(this.panelWalletList);
            this.Name = "MainWalletControl";
            this.Size = new System.Drawing.Size(883, 494);
            this.panelWalletList.ResumeLayout(false);
            this.panelWalletList.PerformLayout();
            this.groupWatched.ResumeLayout(false);
            this.groupWatched.PerformLayout();
            this.panelWatchedAccounts.ResumeLayout(false);
            this.toolStripWatchedAccounts.ResumeLayout(false);
            this.toolStripWatchedAccounts.PerformLayout();
            this.groupMyAccounts.ResumeLayout(false);
            this.groupMyAccounts.PerformLayout();
            this.panelMyAccounts.ResumeLayout(false);
            this.toolStripWalletList.ResumeLayout(false);
            this.toolStripWalletList.PerformLayout();
            this.groupAccountDetails.ResumeLayout(false);
            this.accountContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Panel panelWalletList;
        private ToolStrip toolStripWalletList;
        private ToolStripButton buttonCreate;
        private ToolStripButton toolImport;
        private Panel panelWatchedAccounts;
        private Wallet.WalletListItemControl walletListItemControl2;
        private Panel panelMyAccounts;
        private Wallet.WalletListItemControl walletListItemControl1;
        private Panel panelAccountDetails;
        private GroupBox groupWatched;
        private GroupBox groupMyAccounts;
        private GroupBox groupAccountDetails;
        private ContextMenuStrip accountContextMenu;
        private ToolStripMenuItem removeButton;
        private ToolStrip toolStripWatchedAccounts;
        private ToolStripButton buttonAddWatched;
        private Splitter splitterLeft;
    }
}
