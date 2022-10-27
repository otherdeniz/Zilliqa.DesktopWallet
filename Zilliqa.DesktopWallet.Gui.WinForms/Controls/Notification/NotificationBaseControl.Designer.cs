namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Notification
{
    partial class NotificationBaseControl
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
            this.timerColorChange = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timerColorChange
            // 
            this.timerColorChange.Interval = 500;
            // 
            // NotificationBaseControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "NotificationBaseControl";
            this.Size = new System.Drawing.Size(150, 138);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerColorChange;
    }
}
