namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Details.PropertyRow
{
    partial class PropertyRowText
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
            this.panelValue = new System.Windows.Forms.Panel();
            this.panelValue.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.Padding = new System.Windows.Forms.Padding(4);
            this.labelName.Size = new System.Drawing.Size(100, 23);
            // 
            // textValue
            // 
            this.textValue.BackColor = System.Drawing.Color.White;
            this.textValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textValue.Location = new System.Drawing.Point(4, 4);
            this.textValue.Name = "textValue";
            this.textValue.ReadOnly = true;
            this.textValue.Size = new System.Drawing.Size(345, 16);
            this.textValue.TabIndex = 1;
            // 
            // panelValue
            // 
            this.panelValue.Controls.Add(this.textValue);
            this.panelValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelValue.Location = new System.Drawing.Point(103, 0);
            this.panelValue.Name = "panelValue";
            this.panelValue.Padding = new System.Windows.Forms.Padding(4);
            this.panelValue.Size = new System.Drawing.Size(353, 24);
            this.panelValue.TabIndex = 2;
            // 
            // PropertyRowText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelValue);
            this.Name = "PropertyRowText";
            this.Size = new System.Drawing.Size(456, 24);
            this.Controls.SetChildIndex(this.panelValue, 0);
            this.panelValue.ResumeLayout(false);
            this.panelValue.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textValue;
        private Panel panelValue;
    }
}
