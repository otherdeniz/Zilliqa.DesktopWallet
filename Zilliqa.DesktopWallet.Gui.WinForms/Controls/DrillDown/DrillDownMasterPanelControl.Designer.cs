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
            this.panelButtons = new System.Windows.Forms.Panel();
            this.buttonCloseRight = new System.Windows.Forms.Button();
            this.toolStripRight = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownBack = new System.Windows.Forms.ToolStripDropDownButton();
            this.splitterRight = new System.Windows.Forms.Splitter();
            this.labelTitle = new System.Windows.Forms.ToolStripLabel();
            this.panelRight.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.toolStripRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.panelRightControl);
            this.panelRight.Controls.Add(this.panelButtons);
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
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.buttonCloseRight);
            this.panelButtons.Controls.Add(this.toolStripRight);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelButtons.Location = new System.Drawing.Point(0, 0);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(340, 24);
            this.panelButtons.TabIndex = 3;
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
            this.toolStripRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripRight.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownBack,
            this.labelTitle});
            this.toolStripRight.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStripRight.Location = new System.Drawing.Point(0, 0);
            this.toolStripRight.Name = "toolStripRight";
            this.toolStripRight.Size = new System.Drawing.Size(340, 24);
            this.toolStripRight.TabIndex = 2;
            this.toolStripRight.Text = "toolStrip1";
            // 
            // toolStripDropDownBack
            // 
            this.toolStripDropDownBack.Enabled = false;
            this.toolStripDropDownBack.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.toolStripDropDownBack.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownBack.Image")));
            this.toolStripDropDownBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownBack.Name = "toolStripDropDownBack";
            this.toolStripDropDownBack.Size = new System.Drawing.Size(61, 20);
            this.toolStripDropDownBack.Text = "Back";
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
            // labelTitle
            // 
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Padding = new System.Windows.Forms.Padding(8, 4, 0, 0);
            this.labelTitle.Size = new System.Drawing.Size(63, 19);
            this.labelTitle.Text = "(loading)";
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
            this.panelButtons.ResumeLayout(false);
            this.panelButtons.PerformLayout();
            this.toolStripRight.ResumeLayout(false);
            this.toolStripRight.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelRight;
        private Panel panelRightControl;
        private Splitter splitterRight;
        private Panel panelButtons;
        private Button buttonCloseRight;
        private ToolStrip toolStripRight;
        private ToolStripDropDownButton toolStripDropDownBack;
        private ToolStripLabel labelTitle;
    }
}
