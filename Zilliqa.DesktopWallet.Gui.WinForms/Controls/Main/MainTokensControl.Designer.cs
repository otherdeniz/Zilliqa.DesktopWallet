namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Main
{
    partial class MainTokensControl
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
            this.dataGridViewTokens = new System.Windows.Forms.DataGridView();
            this.panelLoading = new System.Windows.Forms.Panel();
            this.labelLoading = new System.Windows.Forms.Label();
            this.panelLoaded = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBoxTokenDetails = new System.Windows.Forms.GroupBox();
            this.timerStartLoading = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTokens)).BeginInit();
            this.panelLoading.SuspendLayout();
            this.panelLoaded.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewTokens
            // 
            this.dataGridViewTokens.AllowUserToAddRows = false;
            this.dataGridViewTokens.AllowUserToDeleteRows = false;
            this.dataGridViewTokens.AllowUserToResizeRows = false;
            this.dataGridViewTokens.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridViewTokens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTokens.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTokens.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewTokens.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewTokens.MultiSelect = false;
            this.dataGridViewTokens.Name = "dataGridViewTokens";
            this.dataGridViewTokens.ReadOnly = true;
            this.dataGridViewTokens.RowTemplate.Height = 25;
            this.dataGridViewTokens.RowTemplate.ReadOnly = true;
            this.dataGridViewTokens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTokens.ShowEditingIcon = false;
            this.dataGridViewTokens.Size = new System.Drawing.Size(284, 377);
            this.dataGridViewTokens.TabIndex = 0;
            // 
            // panelLoading
            // 
            this.panelLoading.Controls.Add(this.labelLoading);
            this.panelLoading.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLoading.Location = new System.Drawing.Point(0, 0);
            this.panelLoading.Name = "panelLoading";
            this.panelLoading.Size = new System.Drawing.Size(535, 45);
            this.panelLoading.TabIndex = 1;
            // 
            // labelLoading
            // 
            this.labelLoading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelLoading.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelLoading.Location = new System.Drawing.Point(0, 0);
            this.labelLoading.Name = "labelLoading";
            this.labelLoading.Size = new System.Drawing.Size(535, 45);
            this.labelLoading.TabIndex = 0;
            this.labelLoading.Text = "Loading, please wait...";
            this.labelLoading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelLoaded
            // 
            this.panelLoaded.Controls.Add(this.splitContainer1);
            this.panelLoaded.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLoaded.Location = new System.Drawing.Point(0, 45);
            this.panelLoaded.Name = "panelLoaded";
            this.panelLoaded.Size = new System.Drawing.Size(535, 377);
            this.panelLoaded.TabIndex = 2;
            this.panelLoaded.Visible = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridViewTokens);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBoxTokenDetails);
            this.splitContainer1.Size = new System.Drawing.Size(535, 377);
            this.splitContainer1.SplitterDistance = 284;
            this.splitContainer1.TabIndex = 1;
            // 
            // groupBoxTokenDetails
            // 
            this.groupBoxTokenDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxTokenDetails.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBoxTokenDetails.Location = new System.Drawing.Point(0, 0);
            this.groupBoxTokenDetails.Name = "groupBoxTokenDetails";
            this.groupBoxTokenDetails.Size = new System.Drawing.Size(247, 377);
            this.groupBoxTokenDetails.TabIndex = 0;
            this.groupBoxTokenDetails.TabStop = false;
            this.groupBoxTokenDetails.Text = "Token Details";
            // 
            // timerStartLoading
            // 
            this.timerStartLoading.Interval = 10;
            this.timerStartLoading.Tick += new System.EventHandler(this.timerStartLoading_Tick);
            // 
            // MainTokensControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelLoaded);
            this.Controls.Add(this.panelLoading);
            this.Name = "MainTokensControl";
            this.Size = new System.Drawing.Size(535, 422);
            this.Load += new System.EventHandler(this.MainTokensControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTokens)).EndInit();
            this.panelLoading.ResumeLayout(false);
            this.panelLoaded.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dataGridViewTokens;
        private Panel panelLoading;
        private Label labelLoading;
        private Panel panelLoaded;
        private System.Windows.Forms.Timer timerStartLoading;
        private SplitContainer splitContainer1;
        private GroupBox groupBoxTokenDetails;
    }
}
