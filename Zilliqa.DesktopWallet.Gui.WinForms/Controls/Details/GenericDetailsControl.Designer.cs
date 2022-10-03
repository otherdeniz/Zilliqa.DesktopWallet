namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Details
{
    partial class GenericDetailsControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenericDetailsControl));
            this.panelProperties = new System.Windows.Forms.Panel();
            this.panelGrids = new System.Windows.Forms.Panel();
            this.panelTabPages = new System.Windows.Forms.Panel();
            this.gridViewZilTransactions = new Zilliqa.DesktopWallet.Gui.WinForms.Controls.GridView.GridViewControl();
            this.toolStripGrids = new System.Windows.Forms.ToolStrip();
            this.tabButtonZilTransactions = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panelGrids.SuspendLayout();
            this.panelTabPages.SuspendLayout();
            this.toolStripGrids.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelProperties
            // 
            this.panelProperties.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelProperties.Location = new System.Drawing.Point(2, 2);
            this.panelProperties.Name = "panelProperties";
            this.panelProperties.Size = new System.Drawing.Size(550, 195);
            this.panelProperties.TabIndex = 0;
            // 
            // panelGrids
            // 
            this.panelGrids.Controls.Add(this.panelTabPages);
            this.panelGrids.Controls.Add(this.toolStripGrids);
            this.panelGrids.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGrids.Location = new System.Drawing.Point(2, 201);
            this.panelGrids.Name = "panelGrids";
            this.panelGrids.Size = new System.Drawing.Size(550, 240);
            this.panelGrids.TabIndex = 9;
            // 
            // panelTabPages
            // 
            this.panelTabPages.Controls.Add(this.gridViewZilTransactions);
            this.panelTabPages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTabPages.Location = new System.Drawing.Point(0, 25);
            this.panelTabPages.Name = "panelTabPages";
            this.panelTabPages.Size = new System.Drawing.Size(550, 215);
            this.panelTabPages.TabIndex = 2;
            // 
            // gridViewZilTransactions
            // 
            this.gridViewZilTransactions.Location = new System.Drawing.Point(16, 15);
            this.gridViewZilTransactions.Name = "gridViewZilTransactions";
            this.gridViewZilTransactions.Size = new System.Drawing.Size(131, 111);
            this.gridViewZilTransactions.TabIndex = 1;
            this.gridViewZilTransactions.Visible = false;
            // 
            // toolStripGrids
            // 
            this.toolStripGrids.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tabButtonZilTransactions,
            this.toolStripSeparator1});
            this.toolStripGrids.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStripGrids.Location = new System.Drawing.Point(0, 0);
            this.toolStripGrids.Name = "toolStripGrids";
            this.toolStripGrids.Padding = new System.Windows.Forms.Padding(4, 2, 1, 0);
            this.toolStripGrids.Size = new System.Drawing.Size(550, 25);
            this.toolStripGrids.TabIndex = 0;
            // 
            // tabButtonZilTransactions
            // 
            this.tabButtonZilTransactions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tabButtonZilTransactions.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabButtonZilTransactions.Image = ((System.Drawing.Image)(resources.GetObject("tabButtonZilTransactions.Image")));
            this.tabButtonZilTransactions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tabButtonZilTransactions.Name = "tabButtonZilTransactions";
            this.tabButtonZilTransactions.Size = new System.Drawing.Size(76, 19);
            this.tabButtonZilTransactions.Text = "ZIL Transfers";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.Gainsboro;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(2, 197);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(550, 4);
            this.splitter1.TabIndex = 10;
            this.splitter1.TabStop = false;
            // 
            // GenericDetailsControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panelGrids);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panelProperties);
            this.Name = "GenericDetailsControl";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(554, 443);
            this.panelGrids.ResumeLayout(false);
            this.panelGrids.PerformLayout();
            this.panelTabPages.ResumeLayout(false);
            this.toolStripGrids.ResumeLayout(false);
            this.toolStripGrids.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelProperties;
        private Panel panelGrids;
        private Panel panelTabPages;
        private GridView.GridViewControl gridViewZilTransactions;
        private ToolStrip toolStripGrids;
        private ToolStripButton tabButtonZilTransactions;
        private ToolStripSeparator toolStripSeparator1;
        private Splitter splitter1;
    }
}
