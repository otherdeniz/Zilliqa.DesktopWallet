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
            this.panelValue = new System.Windows.Forms.Panel();
            this.textValue = new System.Windows.Forms.TextBox();
            this.panelValue.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelValue
            // 
            this.panelValue.Controls.Add(this.textValue);
            this.panelValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelValue.Location = new System.Drawing.Point(162, 0);
            this.panelValue.Name = "panelValue";
            this.panelValue.Padding = new System.Windows.Forms.Padding(4);
            this.panelValue.Size = new System.Drawing.Size(300, 24);
            this.panelValue.TabIndex = 4;
            // 
            // textValue
            // 
            this.textValue.BackColor = System.Drawing.Color.White;
            this.textValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textValue.Location = new System.Drawing.Point(4, 4);
            this.textValue.Name = "textValue";
            this.textValue.ReadOnly = true;
            this.textValue.Size = new System.Drawing.Size(292, 16);
            this.textValue.TabIndex = 1;
            // 
            // ArgumentEditStringControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelValue);
            this.Name = "ArgumentEditStringControl";
            this.Controls.SetChildIndex(this.panelValue, 0);
            this.panelValue.ResumeLayout(false);
            this.panelValue.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panelValue;
        private TextBox textValue;
    }
}
