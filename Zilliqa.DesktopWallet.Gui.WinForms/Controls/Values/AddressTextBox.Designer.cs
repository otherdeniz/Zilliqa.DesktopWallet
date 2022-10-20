namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Values
{
    partial class AddressTextBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddressTextBox));
            this.labelValid = new System.Windows.Forms.Label();
            this.labelInvalid = new System.Windows.Forms.Label();
            this.textAddress = new System.Windows.Forms.TextBox();
            this.labelHint = new System.Windows.Forms.Label();
            this.buttonAddressBook = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelValid
            // 
            this.labelValid.AutoSize = true;
            this.labelValid.ForeColor = System.Drawing.Color.Green;
            this.labelValid.Location = new System.Drawing.Point(0, 29);
            this.labelValid.Name = "labelValid";
            this.labelValid.Size = new System.Drawing.Size(77, 15);
            this.labelValid.TabIndex = 111;
            this.labelValid.Text = "Valid Address";
            this.labelValid.Visible = false;
            // 
            // labelInvalid
            // 
            this.labelInvalid.AutoSize = true;
            this.labelInvalid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelInvalid.Location = new System.Drawing.Point(0, 29);
            this.labelInvalid.Name = "labelInvalid";
            this.labelInvalid.Size = new System.Drawing.Size(87, 15);
            this.labelInvalid.TabIndex = 110;
            this.labelInvalid.Text = "Invalid Address";
            this.labelInvalid.Visible = false;
            // 
            // textAddress
            // 
            this.textAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textAddress.Location = new System.Drawing.Point(0, 0);
            this.textAddress.Name = "textAddress";
            this.textAddress.Size = new System.Drawing.Size(506, 23);
            this.textAddress.TabIndex = 0;
            this.textAddress.TextChanged += new System.EventHandler(this.textAddress_TextChanged);
            // 
            // labelHint
            // 
            this.labelHint.AutoSize = true;
            this.labelHint.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelHint.Location = new System.Drawing.Point(0, 29);
            this.labelHint.Name = "labelHint";
            this.labelHint.Size = new System.Drawing.Size(151, 15);
            this.labelHint.TabIndex = 109;
            this.labelHint.Text = "Enter Zilliqa Address (zil1...)";
            // 
            // buttonAddressBook
            // 
            this.buttonAddressBook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddressBook.Image = ((System.Drawing.Image)(resources.GetObject("buttonAddressBook.Image")));
            this.buttonAddressBook.Location = new System.Drawing.Point(507, 0);
            this.buttonAddressBook.Name = "buttonAddressBook";
            this.buttonAddressBook.Size = new System.Drawing.Size(123, 24);
            this.buttonAddressBook.TabIndex = 1;
            this.buttonAddressBook.TabStop = false;
            this.buttonAddressBook.Text = "Addressbook";
            this.buttonAddressBook.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonAddressBook.UseVisualStyleBackColor = true;
            this.buttonAddressBook.Click += new System.EventHandler(this.buttonAddressBook_Click);
            // 
            // AddressTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonAddressBook);
            this.Controls.Add(this.labelValid);
            this.Controls.Add(this.labelInvalid);
            this.Controls.Add(this.textAddress);
            this.Controls.Add(this.labelHint);
            this.Name = "AddressTextBox";
            this.Size = new System.Drawing.Size(630, 54);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelValid;
        private Label labelInvalid;
        private TextBox textAddress;
        private Label labelHint;
        private Button buttonAddressBook;
    }
}
