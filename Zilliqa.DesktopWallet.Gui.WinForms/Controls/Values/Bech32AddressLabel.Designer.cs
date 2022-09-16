namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Values
{
    partial class Bech32AddressLabel
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Bech32AddressLabel));
            this.toolTipButton = new System.Windows.Forms.ToolTip(this.components);
            this.buttonCopy = new System.Windows.Forms.Button();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.panelAddress = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timerButtonPressed = new System.Windows.Forms.Timer(this.components);
            this.buttonAddWatchedAccount = new System.Windows.Forms.Button();
            this.panelAddress.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolTipButton
            // 
            this.toolTipButton.AutomaticDelay = 50;
            this.toolTipButton.UseAnimation = false;
            this.toolTipButton.UseFading = false;
            // 
            // buttonCopy
            // 
            this.buttonCopy.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonCopy.Image = ((System.Drawing.Image)(resources.GetObject("buttonCopy.Image")));
            this.buttonCopy.Location = new System.Drawing.Point(296, 0);
            this.buttonCopy.Name = "buttonCopy";
            this.buttonCopy.Size = new System.Drawing.Size(24, 25);
            this.buttonCopy.TabIndex = 4;
            this.toolTipButton.SetToolTip(this.buttonCopy, "Copy to clipboard");
            this.buttonCopy.UseVisualStyleBackColor = true;
            this.buttonCopy.Click += new System.EventHandler(this.buttonCopy_Click);
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonBrowse.Image = ((System.Drawing.Image)(resources.GetObject("buttonBrowse.Image")));
            this.buttonBrowse.Location = new System.Drawing.Point(320, 0);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(24, 25);
            this.buttonBrowse.TabIndex = 5;
            this.toolTipButton.SetToolTip(this.buttonBrowse, "Open in Block Explorer");
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // panelAddress
            // 
            this.panelAddress.Controls.Add(this.label4);
            this.panelAddress.Controls.Add(this.label3);
            this.panelAddress.Controls.Add(this.label2);
            this.panelAddress.Controls.Add(this.label1);
            this.panelAddress.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelAddress.Location = new System.Drawing.Point(0, 0);
            this.panelAddress.Name = "panelAddress";
            this.panelAddress.Size = new System.Drawing.Size(296, 25);
            this.panelAddress.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(259, 0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.label4.Size = new System.Drawing.Size(28, 23);
            this.label4.TabIndex = 4;
            this.label4.Text = "321";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.label3.Size = new System.Drawing.Size(217, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "12345678901234567890123456789012345";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(21, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.label2.Size = new System.Drawing.Size(28, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "123";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.label1.Size = new System.Drawing.Size(24, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "zil1";
            // 
            // timerButtonPressed
            // 
            this.timerButtonPressed.Interval = 2000;
            this.timerButtonPressed.Tick += new System.EventHandler(this.timerButtonPressed_Tick);
            // 
            // buttonAddWatchedAccount
            // 
            this.buttonAddWatchedAccount.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonAddWatchedAccount.Image = ((System.Drawing.Image)(resources.GetObject("buttonAddWatchedAccount.Image")));
            this.buttonAddWatchedAccount.Location = new System.Drawing.Point(344, 0);
            this.buttonAddWatchedAccount.Name = "buttonAddWatchedAccount";
            this.buttonAddWatchedAccount.Size = new System.Drawing.Size(24, 25);
            this.buttonAddWatchedAccount.TabIndex = 7;
            this.toolTipButton.SetToolTip(this.buttonAddWatchedAccount, "Add to Watched Accounts");
            this.buttonAddWatchedAccount.UseVisualStyleBackColor = true;
            this.buttonAddWatchedAccount.Visible = false;
            this.buttonAddWatchedAccount.Click += new System.EventHandler(this.buttonAddWatchedAccount_Click);
            // 
            // Bech32AddressLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.buttonAddWatchedAccount);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.buttonCopy);
            this.Controls.Add(this.panelAddress);
            this.Name = "Bech32AddressLabel";
            this.Size = new System.Drawing.Size(428, 25);
            this.Resize += new System.EventHandler(this.Bech32AddressLabel_Resize);
            this.panelAddress.ResumeLayout(false);
            this.panelAddress.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private ToolTip toolTipButton;
        private Panel panelAddress;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button buttonCopy;
        private Button buttonBrowse;
        private System.Windows.Forms.Timer timerButtonPressed;
        private Button buttonAddWatchedAccount;
    }
}
