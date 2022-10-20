namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    partial class AddressBookAddForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelPage1 = new System.Windows.Forms.Panel();
            this.textAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panelPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Enabled = false;
            this.buttonOk.Location = new System.Drawing.Point(348, 6);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(456, 6);
            // 
            // panelPage1
            // 
            this.panelPage1.Controls.Add(this.textAddress);
            this.panelPage1.Controls.Add(this.label4);
            this.panelPage1.Controls.Add(this.textName);
            this.panelPage1.Controls.Add(this.label5);
            this.panelPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPage1.Location = new System.Drawing.Point(8, 8);
            this.panelPage1.Name = "panelPage1";
            this.panelPage1.Size = new System.Drawing.Size(562, 116);
            this.panelPage1.TabIndex = 0;
            // 
            // textAddress
            // 
            this.textAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textAddress.Location = new System.Drawing.Point(3, 73);
            this.textAddress.Name = "textAddress";
            this.textAddress.Size = new System.Drawing.Size(553, 23);
            this.textAddress.TabIndex = 1;
            this.textAddress.TextChanged += new System.EventHandler(this.textAddress_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "Address";
            // 
            // textName
            // 
            this.textName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textName.Location = new System.Drawing.Point(3, 18);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(553, 23);
            this.textName.TabIndex = 0;
            this.textName.TextChanged += new System.EventHandler(this.textName_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "Name";
            // 
            // AddressBookAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 169);
            this.Controls.Add(this.panelPage1);
            this.Name = "AddressBookAddForm";
            this.Text = "Add to Address Book";
            this.Controls.SetChildIndex(this.panelPage1, 0);
            this.panelPage1.ResumeLayout(false);
            this.panelPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelPage1;
        private TextBox textAddress;
        private Label label4;
        private TextBox textName;
        private Label label5;
    }
}