namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Main
{
    partial class MainStakingNodesControl
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
            this.groupBoxGrid = new System.Windows.Forms.GroupBox();
            this.gridViewStakingNodes = new Zilliqa.DesktopWallet.Gui.WinForms.Controls.GridView.GridViewControl();
            this.timerLoading = new System.Windows.Forms.Timer(this.components);
            this.groupBoxGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxGrid
            // 
            this.groupBoxGrid.Controls.Add(this.gridViewStakingNodes);
            this.groupBoxGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxGrid.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBoxGrid.Location = new System.Drawing.Point(0, 0);
            this.groupBoxGrid.Name = "groupBoxGrid";
            this.groupBoxGrid.Size = new System.Drawing.Size(509, 439);
            this.groupBoxGrid.TabIndex = 3;
            this.groupBoxGrid.TabStop = false;
            this.groupBoxGrid.Text = "Staking Seed Nodes";
            // 
            // gridViewStakingNodes
            // 
            this.gridViewStakingNodes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridViewStakingNodes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gridViewStakingNodes.FrozenColumns = 2;
            this.gridViewStakingNodes.Location = new System.Drawing.Point(3, 19);
            this.gridViewStakingNodes.Name = "gridViewStakingNodes";
            this.gridViewStakingNodes.Size = new System.Drawing.Size(503, 417);
            this.gridViewStakingNodes.TabIndex = 2;
            // 
            // timerLoading
            // 
            this.timerLoading.Interval = 10;
            this.timerLoading.Tick += new System.EventHandler(this.timerLoading_Tick);
            // 
            // MainStakingNodesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupBoxGrid);
            this.Name = "MainStakingNodesControl";
            this.Size = new System.Drawing.Size(853, 439);
            this.Load += new System.EventHandler(this.MainStakingNodesControl_Load);
            this.Controls.SetChildIndex(this.groupBoxGrid, 0);
            this.groupBoxGrid.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBoxGrid;
        private GridView.GridViewControl gridViewStakingNodes;
        private System.Windows.Forms.Timer timerLoading;
    }
}
