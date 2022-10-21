namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    partial class ContractDeployTransactionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContractDeployTransactionForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelTabs = new System.Windows.Forms.Panel();
            this.panelTabConstructor = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panelArguments = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textGasPrice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textGasCost = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textFee = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.scillaCodeText = new Zilliqa.DesktopWallet.Gui.WinForms.Controls.Values.ScillaCodeTextBox();
            this.toolStripTabs = new System.Windows.Forms.ToolStrip();
            this.buttonStepCode = new System.Windows.Forms.ToolStripButton();
            this.toolStripSep1 = new System.Windows.Forms.ToolStripLabel();
            this.buttonStepConstructor = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            this.panelTabs.SuspendLayout();
            this.panelTabConstructor.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.toolStripTabs.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(588, 6);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(696, 6);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelTabs);
            this.panel1.Controls.Add(this.toolStripTabs);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(8, 62);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3, 3, 6, 3);
            this.panel1.Size = new System.Drawing.Size(802, 345);
            this.panel1.TabIndex = 101;
            // 
            // panelTabs
            // 
            this.panelTabs.Controls.Add(this.panelTabConstructor);
            this.panelTabs.Controls.Add(this.scillaCodeText);
            this.panelTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTabs.Location = new System.Drawing.Point(3, 26);
            this.panelTabs.Name = "panelTabs";
            this.panelTabs.Size = new System.Drawing.Size(793, 316);
            this.panelTabs.TabIndex = 102;
            // 
            // panelTabConstructor
            // 
            this.panelTabConstructor.Controls.Add(this.groupBox1);
            this.panelTabConstructor.Controls.Add(this.panel3);
            this.panelTabConstructor.Location = new System.Drawing.Point(0, 122);
            this.panelTabConstructor.Name = "panelTabConstructor";
            this.panelTabConstructor.Size = new System.Drawing.Size(656, 176);
            this.panelTabConstructor.TabIndex = 1;
            this.panelTabConstructor.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panelArguments);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(656, 124);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Arguments";
            // 
            // panelArguments
            // 
            this.panelArguments.AutoScroll = true;
            this.panelArguments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelArguments.Location = new System.Drawing.Point(3, 19);
            this.panelArguments.Name = "panelArguments";
            this.panelArguments.Size = new System.Drawing.Size(650, 102);
            this.panelArguments.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.textGasPrice);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.textGasCost);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.textFee);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 124);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(656, 52);
            this.panel3.TabIndex = 28;
            // 
            // textGasPrice
            // 
            this.textGasPrice.Location = new System.Drawing.Point(0, 24);
            this.textGasPrice.Name = "textGasPrice";
            this.textGasPrice.ReadOnly = true;
            this.textGasPrice.Size = new System.Drawing.Size(90, 23);
            this.textGasPrice.TabIndex = 18;
            this.textGasPrice.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(96, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 15);
            this.label6.TabIndex = 20;
            this.label6.Text = "ZIL";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(170, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 15);
            this.label3.TabIndex = 27;
            this.label3.Text = "Expected gas cost";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(0, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 15);
            this.label7.TabIndex = 22;
            this.label7.Text = "Current gas price";
            // 
            // textGasCost
            // 
            this.textGasCost.Location = new System.Drawing.Point(170, 24);
            this.textGasCost.Name = "textGasCost";
            this.textGasCost.ReadOnly = true;
            this.textGasCost.Size = new System.Drawing.Size(90, 23);
            this.textGasCost.TabIndex = 21;
            this.textGasCost.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(437, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(23, 15);
            this.label11.TabIndex = 19;
            this.label11.Text = "ZIL";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(320, 27);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(15, 15);
            this.label12.TabIndex = 25;
            this.label12.Text = "=";
            // 
            // textFee
            // 
            this.textFee.Location = new System.Drawing.Point(341, 24);
            this.textFee.Name = "textFee";
            this.textFee.ReadOnly = true;
            this.textFee.Size = new System.Drawing.Size(90, 23);
            this.textFee.TabIndex = 23;
            this.textFee.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(150, 27);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(14, 15);
            this.label13.TabIndex = 26;
            this.label13.Text = "X";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(341, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 15);
            this.label9.TabIndex = 24;
            this.label9.Text = "Expected fee";
            // 
            // scillaCodeText
            // 
            this.scillaCodeText.Location = new System.Drawing.Point(0, 12);
            this.scillaCodeText.Name = "scillaCodeText";
            this.scillaCodeText.Size = new System.Drawing.Size(471, 88);
            this.scillaCodeText.TabIndex = 0;
            this.scillaCodeText.Visible = false;
            // 
            // toolStripTabs
            // 
            this.toolStripTabs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonStepCode,
            this.toolStripSep1,
            this.buttonStepConstructor});
            this.toolStripTabs.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStripTabs.Location = new System.Drawing.Point(3, 3);
            this.toolStripTabs.Name = "toolStripTabs";
            this.toolStripTabs.Size = new System.Drawing.Size(793, 23);
            this.toolStripTabs.TabIndex = 101;
            // 
            // buttonStepCode
            // 
            this.buttonStepCode.Image = ((System.Drawing.Image)(resources.GetObject("buttonStepCode.Image")));
            this.buttonStepCode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonStepCode.Name = "buttonStepCode";
            this.buttonStepCode.Size = new System.Drawing.Size(85, 20);
            this.buttonStepCode.Text = "Scilla Code";
            this.buttonStepCode.Click += new System.EventHandler(this.buttonStepCode_Click);
            // 
            // toolStripSep1
            // 
            this.toolStripSep1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSep1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSep1.Image")));
            this.toolStripSep1.Margin = new System.Windows.Forms.Padding(0, 1, 4, 2);
            this.toolStripSep1.Name = "toolStripSep1";
            this.toolStripSep1.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.toolStripSep1.Size = new System.Drawing.Size(16, 20);
            this.toolStripSep1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonStepConstructor
            // 
            this.buttonStepConstructor.Image = ((System.Drawing.Image)(resources.GetObject("buttonStepConstructor.Image")));
            this.buttonStepConstructor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonStepConstructor.Name = "buttonStepConstructor";
            this.buttonStepConstructor.Size = new System.Drawing.Size(152, 20);
            this.buttonStepConstructor.Text = "Constructor Arguments";
            this.buttonStepConstructor.Click += new System.EventHandler(this.buttonStepConstructor_Click);
            // 
            // ContractDeployTransactionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 536);
            this.Controls.Add(this.panel1);
            this.Name = "ContractDeployTransactionForm";
            this.Text = "Deploy Smart Contract";
            this.Load += new System.EventHandler(this.ContractDeployTransactionForm_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelTabs.ResumeLayout(false);
            this.panelTabConstructor.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.toolStripTabs.ResumeLayout(false);
            this.toolStripTabs.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Panel panelTabs;
        private Panel panelTabConstructor;
        private Controls.Values.ScillaCodeTextBox scillaCodeText;
        private ToolStrip toolStripTabs;
        private ToolStripButton buttonStepCode;
        private ToolStripLabel toolStripSep1;
        private ToolStripButton buttonStepConstructor;
        private Label label3;
        private TextBox textGasCost;
        private Label label12;
        private Label label13;
        private Label label9;
        private TextBox textFee;
        private TextBox textGasPrice;
        private Label label11;
        private Label label7;
        private Label label6;
        private GroupBox groupBox1;
        private Panel panelArguments;
        private Panel panel3;
    }
}