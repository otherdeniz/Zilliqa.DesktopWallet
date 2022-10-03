namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Details.PropertyRow
{
    partial class PropertyRowAddress
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
            this.bech32Address = new Zilliqa.DesktopWallet.Gui.WinForms.Controls.Values.Bech32AddressLabel();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.Padding = new System.Windows.Forms.Padding(4);
            this.labelName.Size = new System.Drawing.Size(100, 23);
            // 
            // bech32Address
            // 
            this.bech32Address.AutoSize = true;
            this.bech32Address.Dock = System.Windows.Forms.DockStyle.Top;
            this.bech32Address.Location = new System.Drawing.Point(103, 0);
            this.bech32Address.Name = "bech32Address";
            this.bech32Address.Size = new System.Drawing.Size(430, 23);
            this.bech32Address.TabIndex = 1;
            // 
            // PropertyRowAddress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bech32Address);
            this.Name = "PropertyRowAddress";
            this.Size = new System.Drawing.Size(533, 26);
            this.Controls.SetChildIndex(this.bech32Address, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Values.Bech32AddressLabel bech32Address;
    }
}
