namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Main
{
    partial class MainNftsControl
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
            this.timerStartLoading = new System.Windows.Forms.Timer(this.components);
            this.groupBoxTokensList = new System.Windows.Forms.GroupBox();
            this.gridViewTokens = new Zilliqa.DesktopWallet.Gui.WinForms.Controls.GridView.GridViewControl();
            this.groupBoxTokensList.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerStartLoading
            // 
            this.timerStartLoading.Interval = 10;
            this.timerStartLoading.Tick += new System.EventHandler(this.timerStartLoading_Tick);
            // 
            // groupBoxTokensList
            // 
            this.groupBoxTokensList.Controls.Add(this.gridViewTokens);
            this.groupBoxTokensList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxTokensList.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBoxTokensList.Location = new System.Drawing.Point(0, 0);
            this.groupBoxTokensList.Name = "groupBoxTokensList";
            this.groupBoxTokensList.Size = new System.Drawing.Size(319, 513);
            this.groupBoxTokensList.TabIndex = 3;
            this.groupBoxTokensList.TabStop = false;
            this.groupBoxTokensList.Text = "Nonfungible Tokens";
            // 
            // gridViewTokens
            // 
            this.gridViewTokens.DisplayDynamicColumns = true;
            this.gridViewTokens.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridViewTokens.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gridViewTokens.Location = new System.Drawing.Point(3, 19);
            this.gridViewTokens.Name = "gridViewTokens";
            this.gridViewTokens.Size = new System.Drawing.Size(313, 491);
            this.gridViewTokens.TabIndex = 1;
            // 
            // MainNftsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupBoxTokensList);
            this.Name = "MainNftsControl";
            this.Size = new System.Drawing.Size(689, 513);
            this.Load += new System.EventHandler(this.MainNftsControl_Load);
            this.Controls.SetChildIndex(this.groupBoxTokensList, 0);
            this.groupBoxTokensList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerStartLoading;
        private GroupBox groupBoxTokensList;
        private GridView.GridViewControl gridViewTokens;
    }
}
