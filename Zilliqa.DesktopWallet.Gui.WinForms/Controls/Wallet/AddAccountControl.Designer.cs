namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Wallet
{
    partial class AddAccountControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddAccountControl));
            this.textWalletName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.radioButtonLedger = new System.Windows.Forms.RadioButton();
            this.radioButtonImportPrivateKey = new System.Windows.Forms.RadioButton();
            this.radioButtonNew = new System.Windows.Forms.RadioButton();
            this.panelPrivateKey = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.textPrivateKey = new System.Windows.Forms.TextBox();
            this.panelOptions = new System.Windows.Forms.Panel();
            this.panelLedger = new System.Windows.Forms.Panel();
            this.labelConnectHint = new System.Windows.Forms.Label();
            this.labelQueryLedger = new System.Windows.Forms.Label();
            this.labelLedgerError = new System.Windows.Forms.Label();
            this.buttonGetLedgerAddress = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textLedgerAddress = new System.Windows.Forms.TextBox();
            this.numKeyIndex = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelPrivateKey.SuspendLayout();
            this.panelOptions.SuspendLayout();
            this.panelLedger.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numKeyIndex)).BeginInit();
            this.SuspendLayout();
            // 
            // textWalletName
            // 
            this.textWalletName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textWalletName.Location = new System.Drawing.Point(0, 18);
            this.textWalletName.Name = "textWalletName";
            this.textWalletName.Size = new System.Drawing.Size(431, 23);
            this.textWalletName.TabIndex = 9;
            this.textWalletName.TextChanged += new System.EventHandler(this.textWalletName_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Account Title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(3, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(436, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "The display name to identify your Account. This title is not visible to other peo" +
    "ple.";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textWalletName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(431, 67);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.radioButtonLedger);
            this.panel2.Controls.Add(this.radioButtonImportPrivateKey);
            this.panel2.Controls.Add(this.radioButtonNew);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 67);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(431, 86);
            this.panel2.TabIndex = 2;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(0, 61);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(16, 19);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 36);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 19);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 19);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // radioButtonLedger
            // 
            this.radioButtonLedger.AutoSize = true;
            this.radioButtonLedger.Location = new System.Drawing.Point(23, 61);
            this.radioButtonLedger.Name = "radioButtonLedger";
            this.radioButtonLedger.Size = new System.Drawing.Size(195, 19);
            this.radioButtonLedger.TabIndex = 2;
            this.radioButtonLedger.TabStop = true;
            this.radioButtonLedger.Text = "Connect Ledger hardware wallet";
            this.radioButtonLedger.UseVisualStyleBackColor = true;
            this.radioButtonLedger.Click += new System.EventHandler(this.radioButtonLedger_Click);
            // 
            // radioButtonImportPrivateKey
            // 
            this.radioButtonImportPrivateKey.AutoSize = true;
            this.radioButtonImportPrivateKey.Location = new System.Drawing.Point(23, 36);
            this.radioButtonImportPrivateKey.Name = "radioButtonImportPrivateKey";
            this.radioButtonImportPrivateKey.Size = new System.Drawing.Size(121, 19);
            this.radioButtonImportPrivateKey.TabIndex = 1;
            this.radioButtonImportPrivateKey.TabStop = true;
            this.radioButtonImportPrivateKey.Text = "Import private key";
            this.radioButtonImportPrivateKey.UseVisualStyleBackColor = true;
            this.radioButtonImportPrivateKey.Click += new System.EventHandler(this.radioButtonImportPrivateKey_Click);
            // 
            // radioButtonNew
            // 
            this.radioButtonNew.AutoSize = true;
            this.radioButtonNew.Location = new System.Drawing.Point(23, 11);
            this.radioButtonNew.Name = "radioButtonNew";
            this.radioButtonNew.Size = new System.Drawing.Size(84, 19);
            this.radioButtonNew.TabIndex = 0;
            this.radioButtonNew.TabStop = true;
            this.radioButtonNew.Text = "Create new";
            this.radioButtonNew.UseVisualStyleBackColor = true;
            this.radioButtonNew.Click += new System.EventHandler(this.radioButtonNew_Click);
            // 
            // panelPrivateKey
            // 
            this.panelPrivateKey.Controls.Add(this.label1);
            this.panelPrivateKey.Controls.Add(this.textPrivateKey);
            this.panelPrivateKey.Location = new System.Drawing.Point(3, 6);
            this.panelPrivateKey.Name = "panelPrivateKey";
            this.panelPrivateKey.Size = new System.Drawing.Size(278, 49);
            this.panelPrivateKey.TabIndex = 2;
            this.panelPrivateKey.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 15);
            this.label1.TabIndex = 13;
            this.label1.Text = "Private key";
            // 
            // textPrivateKey
            // 
            this.textPrivateKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textPrivateKey.Location = new System.Drawing.Point(0, 18);
            this.textPrivateKey.Name = "textPrivateKey";
            this.textPrivateKey.Size = new System.Drawing.Size(278, 23);
            this.textPrivateKey.TabIndex = 12;
            this.textPrivateKey.TextChanged += new System.EventHandler(this.textPrivateKey_TextChanged);
            // 
            // panelOptions
            // 
            this.panelOptions.Controls.Add(this.panelLedger);
            this.panelOptions.Controls.Add(this.panelPrivateKey);
            this.panelOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOptions.Location = new System.Drawing.Point(0, 153);
            this.panelOptions.Name = "panelOptions";
            this.panelOptions.Size = new System.Drawing.Size(431, 185);
            this.panelOptions.TabIndex = 1;
            // 
            // panelLedger
            // 
            this.panelLedger.Controls.Add(this.numKeyIndex);
            this.panelLedger.Controls.Add(this.label4);
            this.panelLedger.Controls.Add(this.labelConnectHint);
            this.panelLedger.Controls.Add(this.labelQueryLedger);
            this.panelLedger.Controls.Add(this.labelLedgerError);
            this.panelLedger.Controls.Add(this.buttonGetLedgerAddress);
            this.panelLedger.Controls.Add(this.label3);
            this.panelLedger.Controls.Add(this.textLedgerAddress);
            this.panelLedger.Location = new System.Drawing.Point(3, 61);
            this.panelLedger.Name = "panelLedger";
            this.panelLedger.Size = new System.Drawing.Size(425, 67);
            this.panelLedger.TabIndex = 3;
            this.panelLedger.Visible = false;
            // 
            // labelConnectHint
            // 
            this.labelConnectHint.AutoSize = true;
            this.labelConnectHint.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelConnectHint.Location = new System.Drawing.Point(136, 28);
            this.labelConnectHint.Name = "labelConnectHint";
            this.labelConnectHint.Size = new System.Drawing.Size(240, 30);
            this.labelConnectHint.TabIndex = 17;
            this.labelConnectHint.Text = "Connect Ledger to USB and open Zilliqa app\r\nBefore clicking this button";
            // 
            // labelQueryLedger
            // 
            this.labelQueryLedger.AutoSize = true;
            this.labelQueryLedger.ForeColor = System.Drawing.Color.Blue;
            this.labelQueryLedger.Location = new System.Drawing.Point(136, 35);
            this.labelQueryLedger.Name = "labelQueryLedger";
            this.labelQueryLedger.Size = new System.Drawing.Size(130, 15);
            this.labelQueryLedger.TabIndex = 16;
            this.labelQueryLedger.Text = "Query Ledger address...";
            this.labelQueryLedger.Visible = false;
            // 
            // labelLedgerError
            // 
            this.labelLedgerError.AutoSize = true;
            this.labelLedgerError.ForeColor = System.Drawing.Color.Red;
            this.labelLedgerError.Location = new System.Drawing.Point(136, 35);
            this.labelLedgerError.Name = "labelLedgerError";
            this.labelLedgerError.Size = new System.Drawing.Size(32, 15);
            this.labelLedgerError.TabIndex = 15;
            this.labelLedgerError.Text = "Error";
            this.labelLedgerError.Visible = false;
            // 
            // buttonGetLedgerAddress
            // 
            this.buttonGetLedgerAddress.Location = new System.Drawing.Point(0, 31);
            this.buttonGetLedgerAddress.Name = "buttonGetLedgerAddress";
            this.buttonGetLedgerAddress.Size = new System.Drawing.Size(133, 23);
            this.buttonGetLedgerAddress.TabIndex = 1;
            this.buttonGetLedgerAddress.Text = "Read Address";
            this.buttonGetLedgerAddress.UseVisualStyleBackColor = true;
            this.buttonGetLedgerAddress.Click += new System.EventHandler(this.buttonGetLedgerAddress_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "Ledger key index:";
            // 
            // textLedgerAddress
            // 
            this.textLedgerAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textLedgerAddress.Location = new System.Drawing.Point(132, 31);
            this.textLedgerAddress.Name = "textLedgerAddress";
            this.textLedgerAddress.ReadOnly = true;
            this.textLedgerAddress.Size = new System.Drawing.Size(293, 23);
            this.textLedgerAddress.TabIndex = 12;
            this.textLedgerAddress.Visible = false;
            // 
            // numKeyIndex
            // 
            this.numKeyIndex.Location = new System.Drawing.Point(132, 3);
            this.numKeyIndex.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.numKeyIndex.Name = "numKeyIndex";
            this.numKeyIndex.Size = new System.Drawing.Size(83, 23);
            this.numKeyIndex.TabIndex = 0;
            this.numKeyIndex.ValueChanged += new System.EventHandler(this.numKeyIndex_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(221, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "First key number is \'0\'";
            // 
            // AddAccountControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelOptions);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "AddAccountControl";
            this.Size = new System.Drawing.Size(431, 338);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelPrivateKey.ResumeLayout(false);
            this.panelPrivateKey.PerformLayout();
            this.panelOptions.ResumeLayout(false);
            this.panelLedger.ResumeLayout(false);
            this.panelLedger.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numKeyIndex)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private TextBox textWalletName;
        private Label label5;
        private Label label2;
        private Panel panel1;
        private Panel panel2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private RadioButton radioButtonLedger;
        private RadioButton radioButtonImportPrivateKey;
        private RadioButton radioButtonNew;
        private Panel panelPrivateKey;
        private Panel panelOptions;
        private Label label1;
        private TextBox textPrivateKey;
        private Panel panelLedger;
        private Button buttonGetLedgerAddress;
        private Label label3;
        private TextBox textLedgerAddress;
        private Label labelQueryLedger;
        private Label labelLedgerError;
        private Label labelConnectHint;
        private NumericUpDown numKeyIndex;
        private Label label4;
    }
}
