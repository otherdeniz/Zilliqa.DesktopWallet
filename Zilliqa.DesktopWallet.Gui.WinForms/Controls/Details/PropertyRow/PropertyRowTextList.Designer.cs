namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Details.PropertyRow
{
    partial class PropertyRowTextList
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
            this.SuspendLayout();
            // 
            // panelValue
            // 
            this.panelValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelValue.Location = new System.Drawing.Point(103, 0);
            this.panelValue.Name = "panelValue";
            this.panelValue.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.panelValue.Size = new System.Drawing.Size(353, 24);
            this.panelValue.TabIndex = 1;
            // 
            // PropertyRowTextList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelValue);
            this.Name = "PropertyRowTextList";
            this.Controls.SetChildIndex(this.panelValue, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panelValue;
    }
}
