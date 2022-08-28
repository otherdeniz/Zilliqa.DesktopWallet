namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Main
{
    partial class RightDrillDownPanelControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RightDrillDownPanelControl));
            this.panelRight = new System.Windows.Forms.Panel();
            this.splitterRight = new System.Windows.Forms.Splitter();
            this.toolStripRight = new System.Windows.Forms.ToolStrip();
            this.toolStripLabelTitle = new System.Windows.Forms.ToolStripLabel();
            this.toolStripDropDownTitle = new System.Windows.Forms.ToolStripDropDownButton();
            this.addressZToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelRightControl = new System.Windows.Forms.Panel();
            this.buttonCloseRight = new System.Windows.Forms.ToolStripButton();
            this.panelRight.SuspendLayout();
            this.toolStripRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.panelRightControl);
            this.panelRight.Controls.Add(this.toolStripRight);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(806, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(340, 752);
            this.panelRight.TabIndex = 0;
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
            // 
            // toolStripRight
            // 
            this.toolStripRight.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabelTitle,
            this.toolStripDropDownTitle,
            this.buttonCloseRight});
            this.toolStripRight.Location = new System.Drawing.Point(0, 0);
            this.toolStripRight.Name = "toolStripRight";
            this.toolStripRight.Size = new System.Drawing.Size(340, 25);
            this.toolStripRight.TabIndex = 1;
            this.toolStripRight.Text = "toolStrip1";
            // 
            // toolStripLabelTitle
            // 
            this.toolStripLabelTitle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripLabelTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.toolStripLabelTitle.Name = "toolStripLabelTitle";
            this.toolStripLabelTitle.Size = new System.Drawing.Size(39, 22);
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
            this.toolStripDropDownTitle.Size = new System.Drawing.Size(52, 22);
            this.toolStripDropDownTitle.Text = "Title2";
            this.toolStripDropDownTitle.Visible = false;
            // 
            // addressZToolStripMenuItem
            // 
            this.addressZToolStripMenuItem.Name = "addressZToolStripMenuItem";
            this.addressZToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.addressZToolStripMenuItem.Text = "Address Z";
            // 
            // panelRightControl
            // 
            this.panelRightControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRightControl.Location = new System.Drawing.Point(0, 25);
            this.panelRightControl.Name = "panelRightControl";
            this.panelRightControl.Size = new System.Drawing.Size(340, 727);
            this.panelRightControl.TabIndex = 2;
            // 
            // buttonCloseRight
            // 
            this.buttonCloseRight.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.buttonCloseRight.Image = ((System.Drawing.Image)(resources.GetObject("buttonCloseRight.Image")));
            this.buttonCloseRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonCloseRight.Name = "buttonCloseRight";
            this.buttonCloseRight.Size = new System.Drawing.Size(56, 22);
            this.buttonCloseRight.Text = "Close";
            this.buttonCloseRight.Click += new System.EventHandler(this.buttonCloseRight_Click);
            // 
            // RightDrillDownPanelControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitterRight);
            this.Controls.Add(this.panelRight);
            this.Name = "RightDrillDownPanelControl";
            this.Size = new System.Drawing.Size(1146, 752);
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            this.toolStripRight.ResumeLayout(false);
            this.toolStripRight.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelRight;
        private Panel panelRightControl;
        private ToolStrip toolStripRight;
        private ToolStripLabel toolStripLabelTitle;
        private ToolStripDropDownButton toolStripDropDownTitle;
        private ToolStripMenuItem addressZToolStripMenuItem;
        private ToolStripButton buttonCloseRight;
        private Splitter splitterRight;
    }
}
