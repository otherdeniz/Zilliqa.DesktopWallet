namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    partial class ContractCallTransactionForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panelArguments = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.textGasCost = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.comboBoxMethod = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.addressTextBox = new Zilliqa.DesktopWallet.Gui.WinForms.Controls.Values.AddressTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textFee = new System.Windows.Forms.TextBox();
            this.textAvailableFunds = new System.Windows.Forms.TextBox();
            this.textGasPrice = new System.Windows.Forms.TextBox();
            this.textAmount = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panelPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(496, 6);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(604, 6);
            // 
            // panelPage1
            // 
            this.panelPage1.Controls.Add(this.groupBox1);
            this.panelPage1.Controls.Add(this.label3);
            this.panelPage1.Controls.Add(this.textGasCost);
            this.panelPage1.Controls.Add(this.label12);
            this.panelPage1.Controls.Add(this.label13);
            this.panelPage1.Controls.Add(this.comboBoxMethod);
            this.panelPage1.Controls.Add(this.label1);
            this.panelPage1.Controls.Add(this.addressTextBox);
            this.panelPage1.Controls.Add(this.label9);
            this.panelPage1.Controls.Add(this.label8);
            this.panelPage1.Controls.Add(this.textFee);
            this.panelPage1.Controls.Add(this.textAvailableFunds);
            this.panelPage1.Controls.Add(this.textGasPrice);
            this.panelPage1.Controls.Add(this.textAmount);
            this.panelPage1.Controls.Add(this.label11);
            this.panelPage1.Controls.Add(this.label10);
            this.panelPage1.Controls.Add(this.label7);
            this.panelPage1.Controls.Add(this.label6);
            this.panelPage1.Controls.Add(this.label2);
            this.panelPage1.Controls.Add(this.label4);
            this.panelPage1.Controls.Add(this.label5);
            this.panelPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPage1.Location = new System.Drawing.Point(8, 62);
            this.panelPage1.Name = "panelPage1";
            this.panelPage1.Size = new System.Drawing.Size(710, 356);
            this.panelPage1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.panelArguments);
            this.groupBox1.Location = new System.Drawing.Point(0, 120);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(710, 136);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Arguments";
            // 
            // panelArguments
            // 
            this.panelArguments.AutoScroll = true;
            this.panelArguments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelArguments.Location = new System.Drawing.Point(3, 19);
            this.panelArguments.Name = "panelArguments";
            this.panelArguments.Size = new System.Drawing.Size(704, 114);
            this.panelArguments.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(173, 307);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 15);
            this.label3.TabIndex = 17;
            this.label3.Text = "Expected gas cost";
            // 
            // textGasCost
            // 
            this.textGasCost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textGasCost.Location = new System.Drawing.Point(173, 325);
            this.textGasCost.Name = "textGasCost";
            this.textGasCost.ReadOnly = true;
            this.textGasCost.Size = new System.Drawing.Size(90, 23);
            this.textGasCost.TabIndex = 7;
            this.textGasCost.TabStop = false;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(323, 328);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(15, 15);
            this.label12.TabIndex = 15;
            this.label12.Text = "=";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(153, 328);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(14, 15);
            this.label13.TabIndex = 16;
            this.label13.Text = "X";
            // 
            // comboBoxMethod
            // 
            this.comboBoxMethod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMethod.FormattingEnabled = true;
            this.comboBoxMethod.Location = new System.Drawing.Point(3, 91);
            this.comboBoxMethod.Name = "comboBoxMethod";
            this.comboBoxMethod.Size = new System.Drawing.Size(701, 23);
            this.comboBoxMethod.TabIndex = 1;
            this.comboBoxMethod.SelectedIndexChanged += new System.EventHandler(this.comboBoxMethod_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 15);
            this.label1.TabIndex = 13;
            this.label1.Text = "Contract method";
            // 
            // addressTextBox
            // 
            this.addressTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addressTextBox.Location = new System.Drawing.Point(3, 18);
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.OnlyContractAddresses = true;
            this.addressTextBox.Size = new System.Drawing.Size(701, 51);
            this.addressTextBox.TabIndex = 0;
            this.addressTextBox.AddressChanged += new System.EventHandler<System.EventArgs>(this.addressTextBox_AddressChanged);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(344, 307);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 15);
            this.label9.TabIndex = 10;
            this.label9.Text = "Expected fee";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(175, 259);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 15);
            this.label8.TabIndex = 10;
            this.label8.Text = "Available funds";
            // 
            // textFee
            // 
            this.textFee.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textFee.Location = new System.Drawing.Point(344, 325);
            this.textFee.Name = "textFee";
            this.textFee.ReadOnly = true;
            this.textFee.Size = new System.Drawing.Size(90, 23);
            this.textFee.TabIndex = 8;
            this.textFee.TabStop = false;
            // 
            // textAvailableFunds
            // 
            this.textAvailableFunds.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textAvailableFunds.Location = new System.Drawing.Point(175, 277);
            this.textAvailableFunds.Name = "textAvailableFunds";
            this.textAvailableFunds.ReadOnly = true;
            this.textAvailableFunds.Size = new System.Drawing.Size(163, 23);
            this.textAvailableFunds.TabIndex = 5;
            this.textAvailableFunds.TabStop = false;
            // 
            // textGasPrice
            // 
            this.textGasPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textGasPrice.Location = new System.Drawing.Point(3, 325);
            this.textGasPrice.Name = "textGasPrice";
            this.textGasPrice.ReadOnly = true;
            this.textGasPrice.Size = new System.Drawing.Size(90, 23);
            this.textGasPrice.TabIndex = 6;
            this.textGasPrice.TabStop = false;
            // 
            // textAmount
            // 
            this.textAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textAmount.Location = new System.Drawing.Point(3, 277);
            this.textAmount.Name = "textAmount";
            this.textAmount.Size = new System.Drawing.Size(135, 23);
            this.textAmount.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(440, 328);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(23, 15);
            this.label11.TabIndex = 6;
            this.label11.Text = "ZIL";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(344, 280);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(23, 15);
            this.label10.TabIndex = 6;
            this.label10.Text = "ZIL";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 307);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 15);
            this.label7.TabIndex = 7;
            this.label7.Text = "Current gas price";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(99, 328);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 15);
            this.label6.TabIndex = 6;
            this.label6.Text = "ZIL";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 259);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Send ZIL amount";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(144, 280);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "ZIL";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "Smart Contract address";
            // 
            // ContractCallTransactionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 547);
            this.Controls.Add(this.panelPage1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "ContractCallTransactionForm";
            this.Text = "Call Smart Contract";
            this.Load += new System.EventHandler(this.ContractCallTransactionForm_Load);
            this.Controls.SetChildIndex(this.panelPage1, 0);
            this.panelPage1.ResumeLayout(false);
            this.panelPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelPage1;
        private Controls.Values.AddressTextBox addressTextBox;
        private Label label9;
        private Label label8;
        private TextBox textFee;
        private TextBox textAvailableFunds;
        private TextBox textGasPrice;
        private TextBox textAmount;
        private Label label11;
        private Label label10;
        private Label label7;
        private Label label6;
        private Label label2;
        private Label label4;
        private Label label5;
        private ComboBox comboBoxMethod;
        private Label label1;
        private Label label3;
        private TextBox textGasCost;
        private Label label12;
        private Label label13;
        private GroupBox groupBox1;
        private Panel panelArguments;
    }
}