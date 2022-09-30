namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    partial class ExportPrivateKeyForm
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
            this.textPassword1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textFileName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonSelect = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.panelPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Enabled = false;
            this.buttonOk.Location = new System.Drawing.Point(552, 6);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(660, 6);
            // 
            // panelPage1
            // 
            this.panelPage1.Controls.Add(this.buttonSelect);
            this.panelPage1.Controls.Add(this.textPassword1);
            this.panelPage1.Controls.Add(this.label1);
            this.panelPage1.Controls.Add(this.textFileName);
            this.panelPage1.Controls.Add(this.label3);
            this.panelPage1.Controls.Add(this.label2);
            this.panelPage1.Controls.Add(this.label5);
            this.panelPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPage1.Location = new System.Drawing.Point(8, 8);
            this.panelPage1.Name = "panelPage1";
            this.panelPage1.Size = new System.Drawing.Size(766, 169);
            this.panelPage1.TabIndex = 100;
            // 
            // textPassword1
            // 
            this.textPassword1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textPassword1.Location = new System.Drawing.Point(3, 101);
            this.textPassword1.Name = "textPassword1";
            this.textPassword1.PasswordChar = '*';
            this.textPassword1.Size = new System.Drawing.Size(757, 23);
            this.textPassword1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(3, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Wallet Password";
            // 
            // textFileName
            // 
            this.textFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textFileName.Location = new System.Drawing.Point(3, 38);
            this.textFileName.Name = "textFileName";
            this.textFileName.ReadOnly = true;
            this.textFileName.Size = new System.Drawing.Size(676, 23);
            this.textFileName.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(3, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Your current Wallet password.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(3, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(494, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "The Private Key File should be on a secure storage, it will contain the Private K" +
    "ey in clear Text!";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "Export to File";
            // 
            // buttonSelect
            // 
            this.buttonSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSelect.Location = new System.Drawing.Point(685, 38);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(75, 23);
            this.buttonSelect.TabIndex = 10;
            this.buttonSelect.Text = "Select";
            this.buttonSelect.UseVisualStyleBackColor = true;
            this.buttonSelect.Click += new System.EventHandler(this.buttonSelect_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Text File (*.txt)|*.txt|All Files (*.*)|*.*";
            this.saveFileDialog.Title = "Choose Target File";
            // 
            // ExportPrivateKeyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 222);
            this.Controls.Add(this.panelPage1);
            this.Name = "ExportPrivateKeyForm";
            this.Text = "Export Private Key";
            this.Controls.SetChildIndex(this.panelPage1, 0);
            this.panelPage1.ResumeLayout(false);
            this.panelPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelPage1;
        private Button buttonSelect;
        private TextBox textPassword1;
        private Label label1;
        private TextBox textFileName;
        private Label label3;
        private Label label2;
        private Label label5;
        private SaveFileDialog saveFileDialog;
    }
}