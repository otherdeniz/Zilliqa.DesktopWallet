namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    partial class SendZilForm
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
            this.addressTextBox = new Zilliqa.DesktopWallet.Gui.WinForms.Controls.Values.AddressTextBox();
            this.buttonSendMax = new System.Windows.Forms.Button();
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
            this.textGasCost = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panelPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(445, 6);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(553, 6);
            // 
            // panelPage1
            // 
            this.panelPage1.Controls.Add(this.addressTextBox);
            this.panelPage1.Controls.Add(this.buttonSendMax);
            this.panelPage1.Controls.Add(this.label1);
            this.panelPage1.Controls.Add(this.label9);
            this.panelPage1.Controls.Add(this.label8);
            this.panelPage1.Controls.Add(this.textGasCost);
            this.panelPage1.Controls.Add(this.textFee);
            this.panelPage1.Controls.Add(this.textAvailableFunds);
            this.panelPage1.Controls.Add(this.textGasPrice);
            this.panelPage1.Controls.Add(this.textAmount);
            this.panelPage1.Controls.Add(this.label11);
            this.panelPage1.Controls.Add(this.label10);
            this.panelPage1.Controls.Add(this.label7);
            this.panelPage1.Controls.Add(this.label12);
            this.panelPage1.Controls.Add(this.label3);
            this.panelPage1.Controls.Add(this.label6);
            this.panelPage1.Controls.Add(this.label2);
            this.panelPage1.Controls.Add(this.label4);
            this.panelPage1.Controls.Add(this.label5);
            this.panelPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPage1.Location = new System.Drawing.Point(8, 62);
            this.panelPage1.Name = "panelPage1";
            this.panelPage1.Size = new System.Drawing.Size(659, 179);
            this.panelPage1.TabIndex = 0;
            // 
            // addressTextBox
            // 
            this.addressTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addressTextBox.Location = new System.Drawing.Point(3, 18);
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(650, 51);
            this.addressTextBox.TabIndex = 0;
            this.addressTextBox.AddressChanged += new System.EventHandler<System.EventArgs>(this.addressTextBox_AddressChanged);
            // 
            // buttonSendMax
            // 
            this.buttonSendMax.Location = new System.Drawing.Point(173, 93);
            this.buttonSendMax.Name = "buttonSendMax";
            this.buttonSendMax.Size = new System.Drawing.Size(75, 23);
            this.buttonSendMax.TabIndex = 2;
            this.buttonSendMax.TabStop = false;
            this.buttonSendMax.Text = "Send max.";
            this.buttonSendMax.UseVisualStyleBackColor = true;
            this.buttonSendMax.Click += new System.EventHandler(this.buttonSendMax_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(264, 124);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 15);
            this.label9.TabIndex = 10;
            this.label9.Text = "Current fee";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(264, 76);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 15);
            this.label8.TabIndex = 10;
            this.label8.Text = "Available funds";
            // 
            // textFee
            // 
            this.textFee.Location = new System.Drawing.Point(264, 142);
            this.textFee.Name = "textFee";
            this.textFee.ReadOnly = true;
            this.textFee.Size = new System.Drawing.Size(90, 23);
            this.textFee.TabIndex = 5;
            this.textFee.TabStop = false;
            this.textFee.TextChanged += new System.EventHandler(this.textAmount_TextChanged);
            // 
            // textAvailableFunds
            // 
            this.textAvailableFunds.Location = new System.Drawing.Point(264, 94);
            this.textAvailableFunds.Name = "textAvailableFunds";
            this.textAvailableFunds.ReadOnly = true;
            this.textAvailableFunds.Size = new System.Drawing.Size(163, 23);
            this.textAvailableFunds.TabIndex = 3;
            this.textAvailableFunds.TabStop = false;
            this.textAvailableFunds.TextChanged += new System.EventHandler(this.textAmount_TextChanged);
            // 
            // textGasPrice
            // 
            this.textGasPrice.Location = new System.Drawing.Point(3, 142);
            this.textGasPrice.Name = "textGasPrice";
            this.textGasPrice.ReadOnly = true;
            this.textGasPrice.Size = new System.Drawing.Size(90, 23);
            this.textGasPrice.TabIndex = 4;
            this.textGasPrice.TabStop = false;
            this.textGasPrice.TextChanged += new System.EventHandler(this.textAmount_TextChanged);
            // 
            // textAmount
            // 
            this.textAmount.Location = new System.Drawing.Point(3, 94);
            this.textAmount.Name = "textAmount";
            this.textAmount.Size = new System.Drawing.Size(135, 23);
            this.textAmount.TabIndex = 1;
            this.textAmount.TextChanged += new System.EventHandler(this.textAmount_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(360, 145);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(23, 15);
            this.label11.TabIndex = 6;
            this.label11.Text = "ZIL";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(433, 97);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(23, 15);
            this.label10.TabIndex = 6;
            this.label10.Text = "ZIL";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 15);
            this.label7.TabIndex = 7;
            this.label7.Text = "Current gas price";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(99, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 15);
            this.label6.TabIndex = 6;
            this.label6.Text = "ZIL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Amount";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(144, 97);
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
            this.label5.Size = new System.Drawing.Size(64, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "To Address";
            // 
            // textGasCost
            // 
            this.textGasCost.Location = new System.Drawing.Point(173, 142);
            this.textGasCost.Name = "textGasCost";
            this.textGasCost.ReadOnly = true;
            this.textGasCost.Size = new System.Drawing.Size(61, 23);
            this.textGasCost.TabIndex = 5;
            this.textGasCost.TabStop = false;
            this.textGasCost.Text = "50";
            this.textGasCost.TextChanged += new System.EventHandler(this.textAmount_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(173, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Gas cost";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(153, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "X";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(240, 145);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(15, 15);
            this.label12.TabIndex = 6;
            this.label12.Text = "=";
            // 
            // SendZilForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 370);
            this.Controls.Add(this.panelPage1);
            this.Name = "SendZilForm";
            this.Text = "Send ZIL";
            this.Load += new System.EventHandler(this.SendZilForm_Load);
            this.Controls.SetChildIndex(this.panelPage1, 0);
            this.panelPage1.ResumeLayout(false);
            this.panelPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelPage1;
        private TextBox textAmount;
        private Label label2;
        private Label label4;
        private Label label5;
        private TextBox textGasPrice;
        private Label label7;
        private Label label6;
        private Label label9;
        private Label label8;
        private Button buttonSendMax;
        private TextBox textFee;
        private TextBox textAvailableFunds;
        private Label label11;
        private Label label10;
        private Controls.Values.AddressTextBox addressTextBox;
        private Label label1;
        private TextBox textGasCost;
        private Label label12;
        private Label label3;
    }
}