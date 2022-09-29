namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Main
{
    partial class MainEcosystemControl
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
            this.gridViewEcosystem = new Zilliqa.DesktopWallet.Gui.WinForms.Controls.GridView.GridViewControl();
            this.timerLoading = new System.Windows.Forms.Timer(this.components);
            this.groupBoxGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxGrid
            // 
            this.groupBoxGrid.Controls.Add(this.gridViewEcosystem);
            this.groupBoxGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxGrid.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBoxGrid.Location = new System.Drawing.Point(0, 0);
            this.groupBoxGrid.Name = "groupBoxGrid";
            this.groupBoxGrid.Size = new System.Drawing.Size(454, 429);
            this.groupBoxGrid.TabIndex = 2;
            this.groupBoxGrid.TabStop = false;
            this.groupBoxGrid.Text = "Zilliqa Ecosystem";
            // 
            // gridViewEcosystem
            // 
            this.gridViewEcosystem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridViewEcosystem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gridViewEcosystem.FrozenColumns = 2;
            this.gridViewEcosystem.Location = new System.Drawing.Point(3, 19);
            this.gridViewEcosystem.Name = "gridViewEcosystem";
            this.gridViewEcosystem.Size = new System.Drawing.Size(448, 407);
            this.gridViewEcosystem.TabIndex = 2;
            // 
            // timerLoading
            // 
            this.timerLoading.Interval = 10;
            this.timerLoading.Tick += new System.EventHandler(this.timerLoading_Tick);
            // 
            // MainEcosystemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupBoxGrid);
            this.Name = "MainEcosystemControl";
            this.Size = new System.Drawing.Size(798, 429);
            this.Load += new System.EventHandler(this.MainEcosystemControl_Load);
            this.Controls.SetChildIndex(this.groupBoxGrid, 0);
            this.groupBoxGrid.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBoxGrid;
        private GridView.GridViewControl gridViewEcosystem;
        private System.Windows.Forms.Timer timerLoading;
    }
}
