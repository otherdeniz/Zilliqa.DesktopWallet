namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls
{
    partial class HighlitableBaseControl
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
            this.SuspendLayout();
            // 
            // HighlitableBaseControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "HighlitableBaseControl";
            this.Size = new System.Drawing.Size(392, 211);
            this.Load += new System.EventHandler(this.HighlitableBaseControl_Load);
            this.Click += new System.EventHandler(this.Control_Click);
            this.MouseEnter += new System.EventHandler(this.Control_MouseMovement);
            this.MouseLeave += new System.EventHandler(this.Control_MouseMovement);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
