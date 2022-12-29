namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Main
{
    partial class MainContractsControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainContractsControl));
            this.gridViewContracts = new Zilliqa.DesktopWallet.Gui.WinForms.Controls.GridView.GridViewControl();
            this.timerLoading = new System.Windows.Forms.Timer(this.components);
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelTabs = new System.Windows.Forms.Panel();
            this.gridViewNfts = new Zilliqa.DesktopWallet.Gui.WinForms.Controls.GridView.GridViewControl();
            this.gridViewFungibleTokens = new Zilliqa.DesktopWallet.Gui.WinForms.Controls.GridView.GridViewControl();
            this.toolStripTabs = new System.Windows.Forms.ToolStrip();
            this.tabButtonSmartContracts = new System.Windows.Forms.ToolStripButton();
            this.tabSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tabButtonFungibleTokens = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tabButtonNfts = new System.Windows.Forms.ToolStripButton();
            this.panelMain.SuspendLayout();
            this.panelTabs.SuspendLayout();
            this.toolStripTabs.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridViewContracts
            // 
            this.gridViewContracts.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gridViewContracts.Location = new System.Drawing.Point(136, 71);
            this.gridViewContracts.Name = "gridViewContracts";
            this.gridViewContracts.Size = new System.Drawing.Size(155, 63);
            this.gridViewContracts.TabIndex = 2;
            this.gridViewContracts.Visible = false;
            // 
            // timerLoading
            // 
            this.timerLoading.Interval = 10;
            this.timerLoading.Tick += new System.EventHandler(this.timerLoading_Tick);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.panelTabs);
            this.panelMain.Controls.Add(this.toolStripTabs);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(448, 460);
            this.panelMain.TabIndex = 2;
            // 
            // panelTabs
            // 
            this.panelTabs.Controls.Add(this.gridViewNfts);
            this.panelTabs.Controls.Add(this.gridViewFungibleTokens);
            this.panelTabs.Controls.Add(this.gridViewContracts);
            this.panelTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTabs.Location = new System.Drawing.Point(0, 25);
            this.panelTabs.Name = "panelTabs";
            this.panelTabs.Size = new System.Drawing.Size(448, 435);
            this.panelTabs.TabIndex = 0;
            // 
            // gridViewNfts
            // 
            this.gridViewNfts.DisplayDynamicColumns = true;
            this.gridViewNfts.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gridViewNfts.Location = new System.Drawing.Point(136, 210);
            this.gridViewNfts.Name = "gridViewNfts";
            this.gridViewNfts.Size = new System.Drawing.Size(155, 69);
            this.gridViewNfts.TabIndex = 4;
            this.gridViewNfts.Visible = false;
            // 
            // gridViewFungibleTokens
            // 
            this.gridViewFungibleTokens.DisplayDynamicColumns = true;
            this.gridViewFungibleTokens.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gridViewFungibleTokens.Location = new System.Drawing.Point(136, 140);
            this.gridViewFungibleTokens.Name = "gridViewFungibleTokens";
            this.gridViewFungibleTokens.Size = new System.Drawing.Size(155, 64);
            this.gridViewFungibleTokens.TabIndex = 3;
            this.gridViewFungibleTokens.Visible = false;
            // 
            // toolStripTabs
            // 
            this.toolStripTabs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tabButtonSmartContracts,
            this.tabSeparator1,
            this.tabButtonFungibleTokens,
            this.toolStripSeparator3,
            this.tabButtonNfts});
            this.toolStripTabs.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStripTabs.Location = new System.Drawing.Point(0, 0);
            this.toolStripTabs.Name = "toolStripTabs";
            this.toolStripTabs.Padding = new System.Windows.Forms.Padding(4, 2, 1, 0);
            this.toolStripTabs.Size = new System.Drawing.Size(448, 25);
            this.toolStripTabs.TabIndex = 1;
            // 
            // tabButtonSmartContracts
            // 
            this.tabButtonSmartContracts.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tabButtonSmartContracts.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tabButtonSmartContracts.Name = "tabButtonSmartContracts";
            this.tabButtonSmartContracts.Size = new System.Drawing.Size(113, 19);
            this.tabButtonSmartContracts.Text = "All Smart Contracts";
            this.tabButtonSmartContracts.Click += new System.EventHandler(this.tabButtonSmartContracts_Click);
            // 
            // tabSeparator1
            // 
            this.tabSeparator1.Name = "tabSeparator1";
            this.tabSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // tabButtonFungibleTokens
            // 
            this.tabButtonFungibleTokens.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tabButtonFungibleTokens.Image = ((System.Drawing.Image)(resources.GetObject("tabButtonFungibleTokens.Image")));
            this.tabButtonFungibleTokens.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tabButtonFungibleTokens.Name = "tabButtonFungibleTokens";
            this.tabButtonFungibleTokens.Size = new System.Drawing.Size(96, 19);
            this.tabButtonFungibleTokens.Text = "Fungible Tokens";
            this.tabButtonFungibleTokens.Click += new System.EventHandler(this.tabButtonFungibleTokens_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 23);
            // 
            // tabButtonNfts
            // 
            this.tabButtonNfts.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tabButtonNfts.Image = ((System.Drawing.Image)(resources.GetObject("tabButtonNfts.Image")));
            this.tabButtonNfts.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tabButtonNfts.Name = "tabButtonNfts";
            this.tabButtonNfts.Size = new System.Drawing.Size(36, 19);
            this.tabButtonNfts.Text = "NFTs";
            this.tabButtonNfts.Click += new System.EventHandler(this.tabButtonNfts_Click);
            // 
            // MainContractsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelMain);
            this.Name = "MainContractsControl";
            this.Size = new System.Drawing.Size(818, 460);
            this.Load += new System.EventHandler(this.MainContractsControl_Load);
            this.Controls.SetChildIndex(this.panelMain, 0);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelTabs.ResumeLayout(false);
            this.toolStripTabs.ResumeLayout(false);
            this.toolStripTabs.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private GridView.GridViewControl gridViewContracts;
        private System.Windows.Forms.Timer timerLoading;
        private Panel panelMain;
        private Panel panelTabs;
        private ToolStrip toolStripTabs;
        private ToolStripButton tabButtonSmartContracts;
        private ToolStripSeparator tabSeparator1;
        private ToolStripButton tabButtonFungibleTokens;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton tabButtonNfts;
        private GridView.GridViewControl gridViewFungibleTokens;
        private GridView.GridViewControl gridViewNfts;
    }
}
