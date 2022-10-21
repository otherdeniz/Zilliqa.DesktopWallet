namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Values.Arguments
{
    partial class ArgumentEditStringControl
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
            this.textValue = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textValue
            // 
            this.textValue.BackColor = System.Drawing.Color.White;
            this.textValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textValue.Location = new System.Drawing.Point(162, 0);
            this.textValue.Name = "textValue";
            this.textValue.Size = new System.Drawing.Size(300, 23);
            this.textValue.TabIndex = 1;
            this.textValue.TextChanged += new System.EventHandler(this.textValue_TextChanged);
            // 
            // ArgumentEditStringControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textValue);
            this.Name = "ArgumentEditStringControl";
            this.Controls.SetChildIndex(this.textValue, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TextBox textValue;
    }
}
