namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    partial class StakingStakeForm
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
            this.comboBoxSsn = new System.Windows.Forms.ComboBox();
            this.labelNodeHint = new System.Windows.Forms.Label();
            this.pictureNodeHint = new System.Windows.Forms.PictureBox();
            this.buttonSendMax = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textPassword1 = new System.Windows.Forms.TextBox();
            this.textClaimFee = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textStakeFee = new System.Windows.Forms.TextBox();
            this.textAvailableFunds = new System.Windows.Forms.TextBox();
            this.textGasPrice = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textAmount = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panelPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureNodeHint)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Enabled = false;
            this.buttonOk.Location = new System.Drawing.Point(462, 6);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(570, 6);
            // 
            // panelPage1
            // 
            this.panelPage1.Controls.Add(this.comboBoxSsn);
            this.panelPage1.Controls.Add(this.labelNodeHint);
            this.panelPage1.Controls.Add(this.pictureNodeHint);
            this.panelPage1.Controls.Add(this.buttonSendMax);
            this.panelPage1.Controls.Add(this.label13);
            this.panelPage1.Controls.Add(this.label9);
            this.panelPage1.Controls.Add(this.label8);
            this.panelPage1.Controls.Add(this.textPassword1);
            this.panelPage1.Controls.Add(this.textClaimFee);
            this.panelPage1.Controls.Add(this.label1);
            this.panelPage1.Controls.Add(this.textStakeFee);
            this.panelPage1.Controls.Add(this.textAvailableFunds);
            this.panelPage1.Controls.Add(this.textGasPrice);
            this.panelPage1.Controls.Add(this.label12);
            this.panelPage1.Controls.Add(this.textAmount);
            this.panelPage1.Controls.Add(this.label11);
            this.panelPage1.Controls.Add(this.label10);
            this.panelPage1.Controls.Add(this.label7);
            this.panelPage1.Controls.Add(this.label6);
            this.panelPage1.Controls.Add(this.label2);
            this.panelPage1.Controls.Add(this.label4);
            this.panelPage1.Controls.Add(this.label3);
            this.panelPage1.Controls.Add(this.label5);
            this.panelPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPage1.Location = new System.Drawing.Point(8, 8);
            this.panelPage1.Name = "panelPage1";
            this.panelPage1.Size = new System.Drawing.Size(676, 315);
            this.panelPage1.TabIndex = 0;
            // 
            // comboBoxSsn
            // 
            this.comboBoxSsn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxSsn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSsn.FormattingEnabled = true;
            this.comboBoxSsn.Location = new System.Drawing.Point(3, 18);
            this.comboBoxSsn.Name = "comboBoxSsn";
            this.comboBoxSsn.Size = new System.Drawing.Size(667, 23);
            this.comboBoxSsn.TabIndex = 0;
            this.comboBoxSsn.SelectedIndexChanged += new System.EventHandler(this.comboBoxSsn_SelectedIndexChanged);
            // 
            // labelNodeHint
            // 
            this.labelNodeHint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelNodeHint.Location = new System.Drawing.Point(41, 47);
            this.labelNodeHint.Name = "labelNodeHint";
            this.labelNodeHint.Size = new System.Drawing.Size(629, 82);
            this.labelNodeHint.TabIndex = 13;
            // 
            // pictureNodeHint
            // 
            this.pictureNodeHint.Location = new System.Drawing.Point(3, 47);
            this.pictureNodeHint.Name = "pictureNodeHint";
            this.pictureNodeHint.Size = new System.Drawing.Size(32, 32);
            this.pictureNodeHint.TabIndex = 12;
            this.pictureNodeHint.TabStop = false;
            // 
            // buttonSendMax
            // 
            this.buttonSendMax.Enabled = false;
            this.buttonSendMax.Location = new System.Drawing.Point(173, 156);
            this.buttonSendMax.Name = "buttonSendMax";
            this.buttonSendMax.Size = new System.Drawing.Size(75, 23);
            this.buttonSendMax.TabIndex = 11;
            this.buttonSendMax.TabStop = false;
            this.buttonSendMax.Text = "Stake max.";
            this.buttonSendMax.UseVisualStyleBackColor = true;
            this.buttonSendMax.Click += new System.EventHandler(this.buttonSendMax_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(407, 186);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(127, 15);
            this.label13.TabIndex = 10;
            this.label13.Text = "Expected Claiming Fee";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(261, 186);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(118, 15);
            this.label9.TabIndex = 10;
            this.label9.Text = "Expected Staking Fee";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(261, 138);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 15);
            this.label8.TabIndex = 10;
            this.label8.Text = "Available Funds";
            // 
            // textPassword1
            // 
            this.textPassword1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textPassword1.Location = new System.Drawing.Point(3, 262);
            this.textPassword1.Name = "textPassword1";
            this.textPassword1.PasswordChar = '*';
            this.textPassword1.Size = new System.Drawing.Size(667, 23);
            this.textPassword1.TabIndex = 2;
            this.textPassword1.TextChanged += new System.EventHandler(this.textPassword1_TextChanged);
            // 
            // textClaimFee
            // 
            this.textClaimFee.Location = new System.Drawing.Point(407, 204);
            this.textClaimFee.Name = "textClaimFee";
            this.textClaimFee.ReadOnly = true;
            this.textClaimFee.Size = new System.Drawing.Size(90, 23);
            this.textClaimFee.TabIndex = 1;
            this.textClaimFee.TabStop = false;
            this.textClaimFee.Text = "(loading)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(3, 244);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Wallet Password";
            // 
            // textStakeFee
            // 
            this.textStakeFee.Location = new System.Drawing.Point(261, 204);
            this.textStakeFee.Name = "textStakeFee";
            this.textStakeFee.ReadOnly = true;
            this.textStakeFee.Size = new System.Drawing.Size(90, 23);
            this.textStakeFee.TabIndex = 1;
            this.textStakeFee.TabStop = false;
            this.textStakeFee.Text = "(loading)";
            // 
            // textAvailableFunds
            // 
            this.textAvailableFunds.Location = new System.Drawing.Point(261, 156);
            this.textAvailableFunds.Name = "textAvailableFunds";
            this.textAvailableFunds.ReadOnly = true;
            this.textAvailableFunds.Size = new System.Drawing.Size(163, 23);
            this.textAvailableFunds.TabIndex = 1;
            this.textAvailableFunds.TabStop = false;
            // 
            // textGasPrice
            // 
            this.textGasPrice.Location = new System.Drawing.Point(3, 204);
            this.textGasPrice.Name = "textGasPrice";
            this.textGasPrice.ReadOnly = true;
            this.textGasPrice.Size = new System.Drawing.Size(90, 23);
            this.textGasPrice.TabIndex = 1;
            this.textGasPrice.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(503, 207);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(23, 15);
            this.label12.TabIndex = 6;
            this.label12.Text = "ZIL";
            // 
            // textAmount
            // 
            this.textAmount.Location = new System.Drawing.Point(3, 156);
            this.textAmount.Name = "textAmount";
            this.textAmount.Size = new System.Drawing.Size(135, 23);
            this.textAmount.TabIndex = 1;
            this.textAmount.TextChanged += new System.EventHandler(this.textAmount_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(357, 207);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(23, 15);
            this.label11.TabIndex = 6;
            this.label11.Text = "ZIL";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(430, 159);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(23, 15);
            this.label10.TabIndex = 6;
            this.label10.Text = "ZIL";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 186);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 15);
            this.label7.TabIndex = 7;
            this.label7.Text = "Current GAS Price";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(99, 207);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 15);
            this.label6.TabIndex = 6;
            this.label6.Text = "ZIL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Amount";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(144, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "ZIL";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(3, 288);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Your current Wallet password.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "Staking Seed Node";
            // 
            // StakingStakeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 368);
            this.Controls.Add(this.panelPage1);
            this.Name = "StakingStakeForm";
            this.Text = "Stake Funds";
            this.Load += new System.EventHandler(this.StakingStakeForm_Load);
            this.Controls.SetChildIndex(this.panelPage1, 0);
            this.panelPage1.ResumeLayout(false);
            this.panelPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureNodeHint)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelPage1;
        private Button buttonSendMax;
        private Label label9;
        private Label label8;
        private TextBox textPassword1;
        private Label label1;
        private TextBox textStakeFee;
        private TextBox textAvailableFunds;
        private TextBox textGasPrice;
        private TextBox textAmount;
        private Label label11;
        private Label label10;
        private Label label7;
        private Label label6;
        private Label label2;
        private Label label4;
        private Label label3;
        private Label label5;
        private Label labelNodeHint;
        private PictureBox pictureNodeHint;
        private Label label13;
        private TextBox textClaimFee;
        private Label label12;
        private ComboBox comboBoxSsn;
    }
}