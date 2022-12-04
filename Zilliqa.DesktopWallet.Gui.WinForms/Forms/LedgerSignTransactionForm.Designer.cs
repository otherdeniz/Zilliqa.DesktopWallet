namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    partial class LedgerSignTransactionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LedgerSignTransactionForm));
            this.panelButtons = new System.Windows.Forms.Panel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSign = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.groupBoxSign = new System.Windows.Forms.GroupBox();
            this.panelSign = new System.Windows.Forms.Panel();
            this.labelSignError = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.labelRecipient = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelTransactionPayload = new System.Windows.Forms.Label();
            this.labelSignHint = new System.Windows.Forms.Label();
            this.labelSignQuery = new System.Windows.Forms.Label();
            this.groupBoxValidate = new System.Windows.Forms.GroupBox();
            this.panelLedger = new System.Windows.Forms.Panel();
            this.labelConnectHint = new System.Windows.Forms.Label();
            this.labelQueryLedger = new System.Windows.Forms.Label();
            this.labelLedgerError = new System.Windows.Forms.Label();
            this.buttonGetLedgerAddress = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textExpectedAddress = new System.Windows.Forms.TextBox();
            this.textLedgerAddress = new System.Windows.Forms.TextBox();
            this.panelButtons.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.groupBoxSign.SuspendLayout();
            this.panelSign.SuspendLayout();
            this.groupBoxValidate.SuspendLayout();
            this.panelLedger.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.buttonCancel);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(8, 220);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Padding = new System.Windows.Forms.Padding(6);
            this.panelButtons.Size = new System.Drawing.Size(557, 37);
            this.panelButtons.TabIndex = 100;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonCancel.Image = ((System.Drawing.Image)(resources.GetObject("buttonCancel.Image")));
            this.buttonCancel.Location = new System.Drawing.Point(451, 6);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(8);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 25);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSign
            // 
            this.buttonSign.Image = ((System.Drawing.Image)(resources.GetObject("buttonSign.Image")));
            this.buttonSign.Location = new System.Drawing.Point(0, 47);
            this.buttonSign.Margin = new System.Windows.Forms.Padding(8);
            this.buttonSign.Name = "buttonSign";
            this.buttonSign.Size = new System.Drawing.Size(133, 25);
            this.buttonSign.TabIndex = 0;
            this.buttonSign.Text = "Sign";
            this.buttonSign.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonSign.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonSign.UseVisualStyleBackColor = true;
            this.buttonSign.Click += new System.EventHandler(this.buttonSign_Click);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.groupBoxSign);
            this.panelMain.Controls.Add(this.groupBoxValidate);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(8, 8);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(3);
            this.panelMain.Size = new System.Drawing.Size(557, 212);
            this.panelMain.TabIndex = 0;
            // 
            // groupBoxSign
            // 
            this.groupBoxSign.Controls.Add(this.panelSign);
            this.groupBoxSign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxSign.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBoxSign.Location = new System.Drawing.Point(3, 100);
            this.groupBoxSign.Name = "groupBoxSign";
            this.groupBoxSign.Size = new System.Drawing.Size(551, 109);
            this.groupBoxSign.TabIndex = 0;
            this.groupBoxSign.TabStop = false;
            this.groupBoxSign.Text = "Sign transaction";
            // 
            // panelSign
            // 
            this.panelSign.Controls.Add(this.buttonSign);
            this.panelSign.Controls.Add(this.labelSignError);
            this.panelSign.Controls.Add(this.label11);
            this.panelSign.Controls.Add(this.labelRecipient);
            this.panelSign.Controls.Add(this.label2);
            this.panelSign.Controls.Add(this.labelTransactionPayload);
            this.panelSign.Controls.Add(this.labelSignHint);
            this.panelSign.Controls.Add(this.labelSignQuery);
            this.panelSign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSign.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panelSign.Location = new System.Drawing.Point(3, 19);
            this.panelSign.Name = "panelSign";
            this.panelSign.Size = new System.Drawing.Size(545, 87);
            this.panelSign.TabIndex = 0;
            // 
            // labelSignError
            // 
            this.labelSignError.AutoSize = true;
            this.labelSignError.ForeColor = System.Drawing.Color.Red;
            this.labelSignError.Location = new System.Drawing.Point(136, 51);
            this.labelSignError.Name = "labelSignError";
            this.labelSignError.Size = new System.Drawing.Size(32, 15);
            this.labelSignError.TabIndex = 20;
            this.labelSignError.Text = "Error";
            this.labelSignError.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 4);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 15);
            this.label11.TabIndex = 12;
            this.label11.Text = "Recipient:";
            // 
            // labelRecipient
            // 
            this.labelRecipient.AutoSize = true;
            this.labelRecipient.Location = new System.Drawing.Point(136, 4);
            this.labelRecipient.Name = "labelRecipient";
            this.labelRecipient.Size = new System.Drawing.Size(16, 15);
            this.labelRecipient.TabIndex = 10;
            this.labelRecipient.Text = "...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 13;
            this.label2.Text = "Details:";
            // 
            // labelTransactionPayload
            // 
            this.labelTransactionPayload.AutoSize = true;
            this.labelTransactionPayload.Location = new System.Drawing.Point(136, 23);
            this.labelTransactionPayload.Name = "labelTransactionPayload";
            this.labelTransactionPayload.Size = new System.Drawing.Size(16, 15);
            this.labelTransactionPayload.TabIndex = 11;
            this.labelTransactionPayload.Text = "...";
            // 
            // labelSignHint
            // 
            this.labelSignHint.AutoSize = true;
            this.labelSignHint.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelSignHint.Location = new System.Drawing.Point(136, 44);
            this.labelSignHint.Name = "labelSignHint";
            this.labelSignHint.Size = new System.Drawing.Size(240, 30);
            this.labelSignHint.TabIndex = 22;
            this.labelSignHint.Text = "Connect Ledger to USB and open Zilliqa app\r\nBefore clicking this button";
            // 
            // labelSignQuery
            // 
            this.labelSignQuery.AutoSize = true;
            this.labelSignQuery.ForeColor = System.Drawing.Color.Blue;
            this.labelSignQuery.Location = new System.Drawing.Point(136, 51);
            this.labelSignQuery.Name = "labelSignQuery";
            this.labelSignQuery.Size = new System.Drawing.Size(139, 15);
            this.labelSignQuery.TabIndex = 21;
            this.labelSignQuery.Text = "Query Ledger signature...";
            this.labelSignQuery.Visible = false;
            // 
            // groupBoxValidate
            // 
            this.groupBoxValidate.Controls.Add(this.panelLedger);
            this.groupBoxValidate.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxValidate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBoxValidate.Location = new System.Drawing.Point(3, 3);
            this.groupBoxValidate.Name = "groupBoxValidate";
            this.groupBoxValidate.Size = new System.Drawing.Size(551, 97);
            this.groupBoxValidate.TabIndex = 1;
            this.groupBoxValidate.TabStop = false;
            this.groupBoxValidate.Text = "Validate Ledger device (optional)";
            // 
            // panelLedger
            // 
            this.panelLedger.Controls.Add(this.labelConnectHint);
            this.panelLedger.Controls.Add(this.labelQueryLedger);
            this.panelLedger.Controls.Add(this.labelLedgerError);
            this.panelLedger.Controls.Add(this.buttonGetLedgerAddress);
            this.panelLedger.Controls.Add(this.label3);
            this.panelLedger.Controls.Add(this.textExpectedAddress);
            this.panelLedger.Controls.Add(this.textLedgerAddress);
            this.panelLedger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLedger.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panelLedger.Location = new System.Drawing.Point(3, 19);
            this.panelLedger.Name = "panelLedger";
            this.panelLedger.Size = new System.Drawing.Size(545, 75);
            this.panelLedger.TabIndex = 4;
            // 
            // labelConnectHint
            // 
            this.labelConnectHint.AutoSize = true;
            this.labelConnectHint.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelConnectHint.Location = new System.Drawing.Point(136, 30);
            this.labelConnectHint.Name = "labelConnectHint";
            this.labelConnectHint.Size = new System.Drawing.Size(240, 30);
            this.labelConnectHint.TabIndex = 17;
            this.labelConnectHint.Text = "Connect Ledger to USB and open Zilliqa app\r\nBefore clicking this button";
            // 
            // labelQueryLedger
            // 
            this.labelQueryLedger.AutoSize = true;
            this.labelQueryLedger.ForeColor = System.Drawing.Color.Blue;
            this.labelQueryLedger.Location = new System.Drawing.Point(136, 37);
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
            this.labelLedgerError.Location = new System.Drawing.Point(136, 37);
            this.labelLedgerError.Name = "labelLedgerError";
            this.labelLedgerError.Size = new System.Drawing.Size(32, 15);
            this.labelLedgerError.TabIndex = 15;
            this.labelLedgerError.Text = "Error";
            this.labelLedgerError.Visible = false;
            // 
            // buttonGetLedgerAddress
            // 
            this.buttonGetLedgerAddress.Location = new System.Drawing.Point(0, 33);
            this.buttonGetLedgerAddress.Name = "buttonGetLedgerAddress";
            this.buttonGetLedgerAddress.Size = new System.Drawing.Size(133, 23);
            this.buttonGetLedgerAddress.TabIndex = 0;
            this.buttonGetLedgerAddress.Text = "Validate Address";
            this.buttonGetLedgerAddress.UseVisualStyleBackColor = true;
            this.buttonGetLedgerAddress.Click += new System.EventHandler(this.buttonGetLedgerAddress_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "Expected Address:";
            // 
            // textExpectedAddress
            // 
            this.textExpectedAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textExpectedAddress.Location = new System.Drawing.Point(132, 0);
            this.textExpectedAddress.Name = "textExpectedAddress";
            this.textExpectedAddress.ReadOnly = true;
            this.textExpectedAddress.Size = new System.Drawing.Size(413, 23);
            this.textExpectedAddress.TabIndex = 1;
            // 
            // textLedgerAddress
            // 
            this.textLedgerAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textLedgerAddress.Location = new System.Drawing.Point(132, 33);
            this.textLedgerAddress.Name = "textLedgerAddress";
            this.textLedgerAddress.ReadOnly = true;
            this.textLedgerAddress.Size = new System.Drawing.Size(413, 23);
            this.textLedgerAddress.TabIndex = 2;
            this.textLedgerAddress.Visible = false;
            // 
            // LedgerSignTransactionForm
            // 
            this.AcceptButton = this.buttonSign;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(573, 265);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelButtons);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LedgerSignTransactionForm";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sign transaction with Ledger device";
            this.panelButtons.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.groupBoxSign.ResumeLayout(false);
            this.panelSign.ResumeLayout(false);
            this.panelSign.PerformLayout();
            this.groupBoxValidate.ResumeLayout(false);
            this.panelLedger.ResumeLayout(false);
            this.panelLedger.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelButtons;
        protected Button buttonSign;
        protected Button buttonCancel;
        private Panel panelMain;
        private GroupBox groupBoxValidate;
        private Panel panelLedger;
        private Label labelConnectHint;
        private Label labelQueryLedger;
        private Label labelLedgerError;
        private Button buttonGetLedgerAddress;
        private Label label3;
        private TextBox textExpectedAddress;
        private TextBox textLedgerAddress;
        private GroupBox groupBoxSign;
        private Panel panelSign;
        private Label labelSignError;
        private Label label11;
        private Label labelRecipient;
        private Label label2;
        private Label labelTransactionPayload;
        private Label labelSignHint;
        private Label labelSignQuery;
    }
}