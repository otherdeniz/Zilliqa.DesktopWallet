namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.GridView
{
    partial class GridViewControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GridViewControl));
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.labelLoading = new System.Windows.Forms.Label();
            this.toolStripPaging = new System.Windows.Forms.ToolStrip();
            this.buttonPageFirst = new System.Windows.Forms.ToolStripButton();
            this.buttonPageBack = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.labelPageNumber = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.labelRecordRange = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonPageNext = new System.Windows.Forms.ToolStripButton();
            this.buttonPageLast = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.toolStripPaging.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView.Location = new System.Drawing.Point(0, 38);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowTemplate.Height = 25;
            this.dataGridView.RowTemplate.ReadOnly = true;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView.ShowEditingIcon = false;
            this.dataGridView.Size = new System.Drawing.Size(400, 254);
            this.dataGridView.TabIndex = 1;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            this.dataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView_CellFormatting);
            this.dataGridView.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellMouseEnter);
            this.dataGridView.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);
            this.dataGridView.MouseLeave += new System.EventHandler(this.dataGridView_MouseLeave);
            // 
            // labelLoading
            // 
            this.labelLoading.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelLoading.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelLoading.Location = new System.Drawing.Point(0, 0);
            this.labelLoading.Name = "labelLoading";
            this.labelLoading.Size = new System.Drawing.Size(400, 38);
            this.labelLoading.TabIndex = 2;
            this.labelLoading.Text = "Loading, please wait...";
            this.labelLoading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelLoading.Visible = false;
            // 
            // toolStripPaging
            // 
            this.toolStripPaging.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStripPaging.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelRecordRange,
            this.toolStripSeparator1,
            this.buttonPageFirst,
            this.buttonPageBack,
            this.toolStripSeparator3,
            this.labelPageNumber,
            this.toolStripSeparator2,
            this.buttonPageNext,
            this.buttonPageLast});
            this.toolStripPaging.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStripPaging.Location = new System.Drawing.Point(0, 292);
            this.toolStripPaging.Name = "toolStripPaging";
            this.toolStripPaging.Size = new System.Drawing.Size(400, 23);
            this.toolStripPaging.TabIndex = 3;
            this.toolStripPaging.Text = "toolStrip1";
            // 
            // buttonPageFirst
            // 
            this.buttonPageFirst.Image = ((System.Drawing.Image)(resources.GetObject("buttonPageFirst.Image")));
            this.buttonPageFirst.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonPageFirst.Name = "buttonPageFirst";
            this.buttonPageFirst.Size = new System.Drawing.Size(49, 20);
            this.buttonPageFirst.Text = "First";
            this.buttonPageFirst.Click += new System.EventHandler(this.buttonPageFirst_Click);
            // 
            // buttonPageBack
            // 
            this.buttonPageBack.Image = ((System.Drawing.Image)(resources.GetObject("buttonPageBack.Image")));
            this.buttonPageBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonPageBack.Name = "buttonPageBack";
            this.buttonPageBack.Size = new System.Drawing.Size(52, 20);
            this.buttonPageBack.Text = "Back";
            this.buttonPageBack.Click += new System.EventHandler(this.buttonPageBack_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 23);
            // 
            // labelPageNumber
            // 
            this.labelPageNumber.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelPageNumber.Name = "labelPageNumber";
            this.labelPageNumber.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.labelPageNumber.Size = new System.Drawing.Size(69, 19);
            this.labelPageNumber.Text = "Page 1 of 1";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 23);
            // 
            // labelRecordRange
            // 
            this.labelRecordRange.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelRecordRange.Name = "labelRecordRange";
            this.labelRecordRange.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.labelRecordRange.Size = new System.Drawing.Size(67, 19);
            this.labelRecordRange.Text = "# 1 - 2\'000";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // buttonPageNext
            // 
            this.buttonPageNext.Image = ((System.Drawing.Image)(resources.GetObject("buttonPageNext.Image")));
            this.buttonPageNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonPageNext.Name = "buttonPageNext";
            this.buttonPageNext.Size = new System.Drawing.Size(52, 20);
            this.buttonPageNext.Text = "Next";
            this.buttonPageNext.Click += new System.EventHandler(this.buttonPageNext_Click);
            // 
            // buttonPageLast
            // 
            this.buttonPageLast.Image = ((System.Drawing.Image)(resources.GetObject("buttonPageLast.Image")));
            this.buttonPageLast.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonPageLast.Name = "buttonPageLast";
            this.buttonPageLast.Size = new System.Drawing.Size(48, 20);
            this.buttonPageLast.Text = "Last";
            this.buttonPageLast.Click += new System.EventHandler(this.buttonPageLast_Click);
            // 
            // GridViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.toolStripPaging);
            this.Controls.Add(this.labelLoading);
            this.Name = "GridViewControl";
            this.Size = new System.Drawing.Size(400, 315);
            this.Load += new System.EventHandler(this.GridViewControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.toolStripPaging.ResumeLayout(false);
            this.toolStripPaging.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dataGridView;
        private Label labelLoading;
        private ToolStrip toolStripPaging;
        private ToolStripLabel labelPageNumber;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripLabel labelRecordRange;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton buttonPageFirst;
        private ToolStripButton buttonPageBack;
        private ToolStripButton buttonPageNext;
        private ToolStripButton buttonPageLast;
        private ToolStripSeparator toolStripSeparator3;
    }
}
