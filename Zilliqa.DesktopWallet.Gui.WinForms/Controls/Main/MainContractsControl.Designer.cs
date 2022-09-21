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
            this.groupBoxGrid = new System.Windows.Forms.GroupBox();
            this.gridViewContracts = new Zilliqa.DesktopWallet.Gui.WinForms.Controls.GridView.GridViewControl();
            this.timerLoading = new System.Windows.Forms.Timer(this.components);
            this.groupBoxGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxGrid
            // 
            this.groupBoxGrid.Controls.Add(this.gridViewContracts);
            this.groupBoxGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxGrid.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBoxGrid.Location = new System.Drawing.Point(0, 0);
            this.groupBoxGrid.Name = "groupBoxGrid";
            this.groupBoxGrid.Size = new System.Drawing.Size(474, 460);
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
            this.gridViewContracts.Size = new System.Drawing.Size(468, 438);
            this.gridViewContracts.TabIndex = 2;
            this.gridViewContracts.SelectionChanged += new System.EventHandler<Zilliqa.DesktopWallet.Gui.WinForms.Controls.GridView.GridViewControl.SelectedItemEventArgs>(this.gridViewContracts_SelectionChanged);
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
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupBoxGrid);
            this.Name = "MainContractsControl";
            this.Size = new System.Drawing.Size(818, 460);
            this.Load += new System.EventHandler(this.MainContractsControl_Load);
            this.Controls.SetChildIndex(this.groupBoxGrid, 0);
            this.groupBoxGrid.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private GroupBox groupBoxGrid;
        private GridView.GridViewControl gridViewContracts;
        private System.Windows.Forms.Timer timerLoading;
    }
}
