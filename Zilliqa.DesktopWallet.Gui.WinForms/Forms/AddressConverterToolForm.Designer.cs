namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    partial class AddressConverterToolForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddressConverterToolForm));
            this.textInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBech32 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textHex = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labelNotValid = new System.Windows.Forms.Label();
            this.bech32AddressLabel = new Zilliqa.DesktopWallet.Gui.WinForms.Controls.Values.Bech32AddressLabel();
            this.SuspendLayout();
            // 
            // textInput
            // 
            this.textInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textInput.Location = new System.Drawing.Point(129, 12);
            this.textInput.Name = "textInput";
            this.textInput.Size = new System.Drawing.Size(483, 23);
            this.textInput.TabIndex = 0;
            this.textInput.TextChanged += new System.EventHandler(this.textInput_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Input Address:";
            // 
            // textBech32
            // 
            this.textBech32.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBech32.Location = new System.Drawing.Point(129, 78);
            this.textBech32.Name = "textBech32";
            this.textBech32.ReadOnly = true;
            this.textBech32.Size = new System.Drawing.Size(483, 23);
            this.textBech32.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Bech32 Format:";
            // 
            // textHex
            // 
            this.textHex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textHex.Location = new System.Drawing.Point(129, 107);
            this.textHex.Name = "textHex";
            this.textHex.ReadOnly = true;
            this.textHex.Size = new System.Drawing.Size(483, 23);
            this.textHex.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "HEX Format:";
            // 
            // labelNotValid
            // 
            this.labelNotValid.AutoSize = true;
            this.labelNotValid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelNotValid.Location = new System.Drawing.Point(129, 45);
            this.labelNotValid.Name = "labelNotValid";
            this.labelNotValid.Size = new System.Drawing.Size(128, 15);
            this.labelNotValid.TabIndex = 1;
            this.labelNotValid.Text = "Invalid Address Format";
            this.labelNotValid.Visible = false;
            // 
            // bech32AddressLabel
            // 
            this.bech32AddressLabel.AutoSize = true;
            this.bech32AddressLabel.Location = new System.Drawing.Point(129, 41);
            this.bech32AddressLabel.Name = "bech32AddressLabel";
            this.bech32AddressLabel.Size = new System.Drawing.Size(483, 23);
            this.bech32AddressLabel.TabIndex = 1;
            this.bech32AddressLabel.Visible = false;
            // 
            // AddressConverterToolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 150);
            this.Controls.Add(this.bech32AddressLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelNotValid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textHex);
            this.Controls.Add(this.textBech32);
            this.Controls.Add(this.textInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddressConverterToolForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zilliqa Address Format Converter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textInput;
        private Label label1;
        private TextBox textBech32;
        private Label label2;
        private TextBox textHex;
        private Label label3;
        private Label labelNotValid;
        private Controls.Values.Bech32AddressLabel bech32AddressLabel;
    }
}