namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    partial class StakingUnstakeForm
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
            this.buttonUnstakeMax = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.textAvailableFunds = new System.Windows.Forms.TextBox();
            this.textAmount = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panelPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(415, 6);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(523, 6);
            // 
            // panelPage1
            // 
            this.panelPage1.Controls.Add(this.comboBoxSsn);
            this.panelPage1.Controls.Add(this.buttonUnstakeMax);
            this.panelPage1.Controls.Add(this.label8);
            this.panelPage1.Controls.Add(this.textAvailableFunds);
            this.panelPage1.Controls.Add(this.textAmount);
            this.panelPage1.Controls.Add(this.label10);
            this.panelPage1.Controls.Add(this.label2);
            this.panelPage1.Controls.Add(this.label4);
            this.panelPage1.Controls.Add(this.label5);
            this.panelPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPage1.Location = new System.Drawing.Point(8, 8);
            this.panelPage1.Name = "panelPage1";
            this.panelPage1.Size = new System.Drawing.Size(629, 125);
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
            this.comboBoxSsn.Size = new System.Drawing.Size(620, 23);
            this.comboBoxSsn.TabIndex = 0;
            this.comboBoxSsn.SelectedIndexChanged += new System.EventHandler(this.comboBoxSsn_SelectedIndexChanged);
            // 
            // buttonUnstakeMax
            // 
            this.buttonUnstakeMax.Enabled = false;
            this.buttonUnstakeMax.Location = new System.Drawing.Point(173, 75);
            this.buttonUnstakeMax.Name = "buttonUnstakeMax";
            this.buttonUnstakeMax.Size = new System.Drawing.Size(87, 23);
            this.buttonUnstakeMax.TabIndex = 2;
            this.buttonUnstakeMax.TabStop = false;
            this.buttonUnstakeMax.Text = "Unstake all";
            this.buttonUnstakeMax.UseVisualStyleBackColor = true;
            this.buttonUnstakeMax.Click += new System.EventHandler(this.buttonUnstakeMax_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(277, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 15);
            this.label8.TabIndex = 10;
            this.label8.Text = "Staked Funds";
            // 
            // textAvailableFunds
            // 
            this.textAvailableFunds.Location = new System.Drawing.Point(277, 75);
            this.textAvailableFunds.Name = "textAvailableFunds";
            this.textAvailableFunds.ReadOnly = true;
            this.textAvailableFunds.Size = new System.Drawing.Size(163, 23);
            this.textAvailableFunds.TabIndex = 3;
            this.textAvailableFunds.TabStop = false;
            // 
            // textAmount
            // 
            this.textAmount.Location = new System.Drawing.Point(3, 75);
            this.textAmount.Name = "textAmount";
            this.textAmount.Size = new System.Drawing.Size(135, 23);
            this.textAmount.TabIndex = 1;
            this.textAmount.TextChanged += new System.EventHandler(this.textAmount_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(446, 78);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(23, 15);
            this.label10.TabIndex = 6;
            this.label10.Text = "ZIL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Unstake Amount";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(144, 78);
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
            this.label5.Size = new System.Drawing.Size(106, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "Staking Seed Node";
            // 
            // StakingUnstakeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 262);
            this.Controls.Add(this.panelPage1);
            this.Name = "StakingUnstakeForm";
            this.Text = "Unstake Funds";
            this.Controls.SetChildIndex(this.panelPage1, 0);
            this.panelPage1.ResumeLayout(false);
            this.panelPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelPage1;
        private ComboBox comboBoxSsn;
        private Button buttonUnstakeMax;
        private Label label8;
        private TextBox textAvailableFunds;
        private TextBox textAmount;
        private Label label10;
        private Label label2;
        private Label label4;
        private Label label5;
    }
}