namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    partial class SendTokenForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonSendMax = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textFee = new System.Windows.Forms.TextBox();
            this.textAvailableFunds = new System.Windows.Forms.TextBox();
            this.textGasPrice = new System.Windows.Forms.TextBox();
            this.textAmount = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textToAddress = new System.Windows.Forms.TextBox();
            this.labelSymbol2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelSymbol1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxToken = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(456, 6);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(564, 6);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonSendMax);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.textFee);
            this.panel1.Controls.Add(this.textAvailableFunds);
            this.panel1.Controls.Add(this.textGasPrice);
            this.panel1.Controls.Add(this.textAmount);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.textToAddress);
            this.panel1.Controls.Add(this.labelSymbol2);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.labelSymbol1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.comboBoxToken);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(8, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(670, 206);
            this.panel1.TabIndex = 101;
            // 
            // buttonSendMax
            // 
            this.buttonSendMax.Enabled = false;
            this.buttonSendMax.Location = new System.Drawing.Point(188, 120);
            this.buttonSendMax.Name = "buttonSendMax";
            this.buttonSendMax.Size = new System.Drawing.Size(75, 23);
            this.buttonSendMax.TabIndex = 26;
            this.buttonSendMax.TabStop = false;
            this.buttonSendMax.Text = "Send max.";
            this.buttonSendMax.UseVisualStyleBackColor = true;
            this.buttonSendMax.Click += new System.EventHandler(this.buttonSendMax_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(279, 151);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 15);
            this.label9.TabIndex = 24;
            this.label9.Text = "Expected Fee";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(279, 103);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 15);
            this.label8.TabIndex = 25;
            this.label8.Text = "Available Funds";
            // 
            // textFee
            // 
            this.textFee.Location = new System.Drawing.Point(279, 169);
            this.textFee.Name = "textFee";
            this.textFee.ReadOnly = true;
            this.textFee.Size = new System.Drawing.Size(90, 23);
            this.textFee.TabIndex = 13;
            this.textFee.TabStop = false;
            // 
            // textAvailableFunds
            // 
            this.textAvailableFunds.Location = new System.Drawing.Point(279, 121);
            this.textAvailableFunds.Name = "textAvailableFunds";
            this.textAvailableFunds.ReadOnly = true;
            this.textAvailableFunds.Size = new System.Drawing.Size(163, 23);
            this.textAvailableFunds.TabIndex = 14;
            this.textAvailableFunds.TabStop = false;
            // 
            // textGasPrice
            // 
            this.textGasPrice.Location = new System.Drawing.Point(3, 169);
            this.textGasPrice.Name = "textGasPrice";
            this.textGasPrice.ReadOnly = true;
            this.textGasPrice.Size = new System.Drawing.Size(90, 23);
            this.textGasPrice.TabIndex = 15;
            this.textGasPrice.TabStop = false;
            // 
            // textAmount
            // 
            this.textAmount.Location = new System.Drawing.Point(3, 121);
            this.textAmount.Name = "textAmount";
            this.textAmount.Size = new System.Drawing.Size(135, 23);
            this.textAmount.TabIndex = 16;
            this.textAmount.TextChanged += new System.EventHandler(this.textAmount_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(375, 172);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(23, 15);
            this.label11.TabIndex = 17;
            this.label11.Text = "ZIL";
            // 
            // textToAddress
            // 
            this.textToAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textToAddress.Location = new System.Drawing.Point(3, 72);
            this.textToAddress.Name = "textToAddress";
            this.textToAddress.Size = new System.Drawing.Size(661, 23);
            this.textToAddress.TabIndex = 12;
            this.textToAddress.TextChanged += new System.EventHandler(this.textToAddress_TextChanged);
            // 
            // labelSymbol2
            // 
            this.labelSymbol2.AutoSize = true;
            this.labelSymbol2.Location = new System.Drawing.Point(448, 124);
            this.labelSymbol2.Name = "labelSymbol2";
            this.labelSymbol2.Size = new System.Drawing.Size(0, 15);
            this.labelSymbol2.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 151);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 15);
            this.label7.TabIndex = 21;
            this.label7.Text = "Current GAS Price";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(99, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 15);
            this.label6.TabIndex = 19;
            this.label6.Text = "ZIL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 15);
            this.label2.TabIndex = 22;
            this.label2.Text = "Amount";
            // 
            // labelSymbol1
            // 
            this.labelSymbol1.AutoSize = true;
            this.labelSymbol1.Location = new System.Drawing.Point(144, 124);
            this.labelSymbol1.Name = "labelSymbol1";
            this.labelSymbol1.Size = new System.Drawing.Size(0, 15);
            this.labelSymbol1.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 15);
            this.label5.TabIndex = 23;
            this.label5.Text = "To Address";
            // 
            // comboBoxToken
            // 
            this.comboBoxToken.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxToken.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxToken.FormattingEnabled = true;
            this.comboBoxToken.Location = new System.Drawing.Point(3, 21);
            this.comboBoxToken.Name = "comboBoxToken";
            this.comboBoxToken.Size = new System.Drawing.Size(661, 23);
            this.comboBoxToken.TabIndex = 10;
            this.comboBoxToken.SelectedIndexChanged += new System.EventHandler(this.comboBoxToken_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "Fungible Token";
            // 
            // SendTokenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 397);
            this.Controls.Add(this.panel1);
            this.Name = "SendTokenForm";
            this.Text = "Send Fungible Token";
            this.Load += new System.EventHandler(this.SendTokenForm_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private ComboBox comboBoxToken;
        private Label label1;
        private Button buttonSendMax;
        private Label label9;
        private Label label8;
        private TextBox textFee;
        private TextBox textAvailableFunds;
        private TextBox textGasPrice;
        private TextBox textAmount;
        private Label label11;
        private TextBox textToAddress;
        private Label labelSymbol2;
        private Label label7;
        private Label label6;
        private Label label2;
        private Label labelSymbol1;
        private Label label5;
    }
}