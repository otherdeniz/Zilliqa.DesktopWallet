namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Values.Arguments
{
    partial class ArgumentEditAddressControl
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
            this.addressTextBox = new Zilliqa.DesktopWallet.Gui.WinForms.Controls.Values.AddressTextBox();
            this.SuspendLayout();
            // 
            // addressTextBox
            // 
            this.addressTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addressTextBox.Location = new System.Drawing.Point(162, 0);
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(450, 24);
            this.addressTextBox.TabIndex = 4;
            this.addressTextBox.AddressChanged += new System.EventHandler<System.EventArgs>(this.addressTextBox_AddressChanged);
            // 
            // ArgumentEditAddressControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.addressTextBox);
            this.Name = "ArgumentEditAddressControl";
            this.Size = new System.Drawing.Size(636, 24);
            this.Controls.SetChildIndex(this.addressTextBox, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AddressTextBox addressTextBox;
    }
}
