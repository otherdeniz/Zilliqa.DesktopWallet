namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Main
{
    partial class MainContractsControl
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBoxGrid = new System.Windows.Forms.GroupBox();
            this.gridViewContracts = new Zilliqa.DesktopWallet.Gui.WinForms.Controls.GridView.GridViewControl();
            this.timerLoading = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBoxGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBoxGrid);
            this.splitContainer1.Size = new System.Drawing.Size(592, 460);
            this.splitContainer1.SplitterDistance = 273;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBoxGrid
            // 
            this.groupBoxGrid.Controls.Add(this.gridViewContracts);
            this.groupBoxGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxGrid.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBoxGrid.Location = new System.Drawing.Point(0, 0);
            this.groupBoxGrid.Name = "groupBoxGrid";
            this.groupBoxGrid.Size = new System.Drawing.Size(273, 460);
            this.groupBoxGrid.TabIndex = 0;
            this.groupBoxGrid.TabStop = false;
            this.groupBoxGrid.Text = "Smart Contracts";
            // 
            // gridViewContracts
            // 
            this.gridViewContracts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridViewContracts.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gridViewContracts.Location = new System.Drawing.Point(3, 19);
            this.gridViewContracts.Name = "gridViewContracts";
            this.gridViewContracts.Size = new System.Drawing.Size(267, 438);
            this.gridViewContracts.TabIndex = 2;
            // 
            // timerLoading
            // 
            this.timerLoading.Interval = 10;
            this.timerLoading.Tick += new System.EventHandler(this.timerLoading_Tick);
            // 
            // MainContractsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainContractsControl";
            this.Size = new System.Drawing.Size(592, 460);
            this.Load += new System.EventHandler(this.MainContractsControl_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBoxGrid.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainer splitContainer1;
        private GroupBox groupBoxGrid;
        private GridView.GridViewControl gridViewContracts;
        private System.Windows.Forms.Timer timerLoading;
    }
}
