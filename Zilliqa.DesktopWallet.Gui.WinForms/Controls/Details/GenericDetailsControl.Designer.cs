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
            this.panelProperties = new System.Windows.Forms.Panel();
            this.panelTabs = new System.Windows.Forms.Panel();
            this.panelTabPages = new System.Windows.Forms.Panel();
            this.toolStripTabs = new System.Windows.Forms.ToolStrip();
            this.splitterTabs = new System.Windows.Forms.Splitter();
            this.panelTabs.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelProperties
            // 
            this.panelProperties.AutoScroll = true;
            this.panelProperties.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelProperties.Location = new System.Drawing.Point(2, 2);
            this.panelProperties.Name = "panelProperties";
            this.panelProperties.Size = new System.Drawing.Size(550, 195);
            this.panelProperties.TabIndex = 0;
            // 
            // panelTabs
            // 
            this.panelTabs.Controls.Add(this.panelTabPages);
            this.panelTabs.Controls.Add(this.toolStripTabs);
            this.panelTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTabs.Location = new System.Drawing.Point(2, 201);
            this.panelTabs.Name = "panelTabs";
            this.panelTabs.Size = new System.Drawing.Size(550, 417);
            this.panelTabs.TabIndex = 9;
            this.panelTabs.Visible = false;
            // 
            // panelTabPages
            // 
            this.panelTabPages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTabPages.Location = new System.Drawing.Point(0, 2);
            this.panelTabPages.Name = "panelTabPages";
            this.panelTabPages.Size = new System.Drawing.Size(550, 415);
            this.panelTabPages.TabIndex = 2;
            // 
            // toolStripTabs
            // 
            this.toolStripTabs.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStripTabs.Location = new System.Drawing.Point(0, 0);
            this.toolStripTabs.Name = "toolStripTabs";
            this.toolStripTabs.Padding = new System.Windows.Forms.Padding(4, 2, 1, 0);
            this.toolStripTabs.Size = new System.Drawing.Size(550, 2);
            this.toolStripTabs.TabIndex = 0;
            // 
            // splitterTabs
            // 
            this.splitterTabs.BackColor = System.Drawing.Color.Gainsboro;
            this.splitterTabs.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterTabs.Location = new System.Drawing.Point(2, 197);
            this.splitterTabs.Name = "splitterTabs";
            this.splitterTabs.Size = new System.Drawing.Size(550, 4);
            this.splitterTabs.TabIndex = 10;
            this.splitterTabs.TabStop = false;
            this.splitterTabs.Visible = false;
            // 
            // GenericDetailsControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panelTabs);
            this.Controls.Add(this.splitterTabs);
            this.Controls.Add(this.panelProperties);
            this.Name = "GenericDetailsControl";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(554, 620);
            this.Load += new System.EventHandler(this.GenericDetailsControl_Load);
            this.panelTabs.ResumeLayout(false);
            this.panelTabs.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelProperties;
        private Panel panelTabs;
        private Panel panelTabPages;
        private ToolStrip toolStripTabs;
        private Splitter splitterTabs;
    }
}
