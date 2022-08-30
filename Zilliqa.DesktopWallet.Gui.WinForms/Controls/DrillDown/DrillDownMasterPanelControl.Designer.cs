namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.DrillDown
{
    partial class DrillDownMasterPanelControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DrillDownMasterPanelControl));
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelRightControl = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonCloseRight = new System.Windows.Forms.Button();
            this.toolStripRight = new System.Windows.Forms.ToolStrip();
            this.toolStripLabelTitle = new System.Windows.Forms.ToolStripLabel();
            this.toolStripDropDownTitle = new System.Windows.Forms.ToolStripDropDownButton();
            this.addressZToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitterRight = new System.Windows.Forms.Splitter();
            this.panelRight.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStripRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.panelRightControl);
            this.panelRight.Controls.Add(this.panel1);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(806, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(340, 752);
            this.panelRight.TabIndex = 0;
            this.panelRight.Visible = false;
            // 
            // panelRightControl
            // 
            this.panelRightControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRightControl.Location = new System.Drawing.Point(0, 24);
            this.panelRightControl.Name = "panelRightControl";
            this.panelRightControl.Size = new System.Drawing.Size(340, 728);
            this.panelRightControl.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonCloseRight);
            this.panel1.Controls.Add(this.toolStripRight);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(340, 24);
            this.panel1.TabIndex = 3;
            // 
            // buttonCloseRight
            // 
            this.buttonCloseRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonCloseRight.Image = ((System.Drawing.Image)(resources.GetObject("buttonCloseRight.Image")));
            this.buttonCloseRight.Location = new System.Drawing.Point(265, 0);
            this.buttonCloseRight.Name = "buttonCloseRight";
            this.buttonCloseRight.Size = new System.Drawing.Size(75, 24);
            this.buttonCloseRight.TabIndex = 0;
            this.buttonCloseRight.Text = "Close";
            this.buttonCloseRight.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonCloseRight.UseVisualStyleBackColor = true;
            this.buttonCloseRight.Click += new System.EventHandler(this.buttonCloseRight_Click);
            // 
            // toolStripRight
            // 
            this.toolStripRight.CanOverflow = false;
            this.toolStripRight.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStripRight.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabelTitle,
            this.toolStripDropDownTitle});
            this.toolStripRight.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStripRight.Location = new System.Drawing.Point(0, 0);
            this.toolStripRight.Name = "toolStripRight";
            this.toolStripRight.Size = new System.Drawing.Size(40, 24);
            this.toolStripRight.TabIndex = 2;
            this.toolStripRight.Text = "toolStrip1";
            // 
            // toolStripLabelTitle
            // 
            this.toolStripLabelTitle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripLabelTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.toolStripLabelTitle.Name = "toolStripLabelTitle";
            this.toolStripLabelTitle.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.toolStripLabelTitle.Size = new System.Drawing.Size(39, 19);
            this.toolStripLabelTitle.Text = "Title1";
            // 
            // toolStripDropDownTitle
            // 
            this.toolStripDropDownTitle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownTitle.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addressZToolStripMenuItem});
            this.toolStripDropDownTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.toolStripDropDownTitle.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownTitle.Image")));
            this.toolStripDropDownTitle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownTitle.Name = "toolStripDropDownTitle";
            this.toolStripDropDownTitle.Size = new System.Drawing.Size(52, 19);
            this.toolStripDropDownTitle.Text = "Title2";
            this.toolStripDropDownTitle.Visible = false;
            // 
            // addressZToolStripMenuItem
            // 
            this.addressZToolStripMenuItem.Name = "addressZToolStripMenuItem";
            this.addressZToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.addressZToolStripMenuItem.Text = "Address Z";
            // 
            // splitterRight
            // 
            this.splitterRight.BackColor = System.Drawing.SystemColors.ControlLight;
            this.splitterRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitterRight.Location = new System.Drawing.Point(802, 0);
            this.splitterRight.Name = "splitterRight";
            this.splitterRight.Size = new System.Drawing.Size(4, 752);
            this.splitterRight.TabIndex = 1;
            this.splitterRight.TabStop = false;
            this.splitterRight.Visible = false;
            // 
            // DrillDownMasterPanelControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitterRight);
            this.Controls.Add(this.panelRight);
            this.Name = "DrillDownMasterPanelControl";
            this.Size = new System.Drawing.Size(1146, 752);
            this.panelRight.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStripRight.ResumeLayout(false);
            this.toolStripRight.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelRight;
        private Panel panelRightControl;
        private Splitter splitterRight;
        private Panel panel1;
        private Button buttonCloseRight;
        private ToolStrip toolStripRight;
        private ToolStripLabel toolStripLabelTitle;
        private ToolStripDropDownButton toolStripDropDownTitle;
        private ToolStripMenuItem addressZToolStripMenuItem;
    }
}
