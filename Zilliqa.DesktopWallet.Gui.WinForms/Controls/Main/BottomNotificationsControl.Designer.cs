namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Main
{
    partial class BottomNotificationsControl
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
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.panelLevel1 = new System.Windows.Forms.Panel();
            this.panelLevel2 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // timerRefresh
            // 
            this.timerRefresh.Interval = 500;
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // panelLevel1
            // 
            this.panelLevel1.AutoSize = true;
            this.panelLevel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelLevel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLevel1.Location = new System.Drawing.Point(0, 0);
            this.panelLevel1.Name = "panelLevel1";
            this.panelLevel1.Size = new System.Drawing.Size(0, 138);
            this.panelLevel1.TabIndex = 0;
            // 
            // panelLevel2
            // 
            this.panelLevel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLevel2.Location = new System.Drawing.Point(0, 0);
            this.panelLevel2.Name = "panelLevel2";
            this.panelLevel2.Size = new System.Drawing.Size(533, 138);
            this.panelLevel2.TabIndex = 1;
            // 
            // BottomNotificationsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelLevel2);
            this.Controls.Add(this.panelLevel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "BottomNotificationsControl";
            this.Size = new System.Drawing.Size(533, 138);
            this.Load += new System.EventHandler(this.BottomNotificationsControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timerRefresh;
        private Panel panelLevel1;
        private Panel panelLevel2;
    }
}
