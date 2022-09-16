namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Details
{
    partial class AddressShortDetailsControl
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.labelCreatedDate = new System.Windows.Forms.Label();
            this.bech32Address = new Zilliqa.DesktopWallet.Gui.WinForms.Controls.Values.Bech32AddressLabel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel13.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.panel14);
            this.panelTop.Controls.Add(this.panel13);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(580, 44);
            this.panelTop.TabIndex = 11;
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.labelCreatedDate);
            this.panel14.Controls.Add(this.bech32Address);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel14.Location = new System.Drawing.Point(85, 0);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(495, 44);
            this.panel14.TabIndex = 3;
            // 
            // labelCreatedDate
            // 
            this.labelCreatedDate.AutoSize = true;
            this.labelCreatedDate.Location = new System.Drawing.Point(2, 23);
            this.labelCreatedDate.Name = "labelCreatedDate";
            this.labelCreatedDate.Size = new System.Drawing.Size(91, 15);
            this.labelCreatedDate.TabIndex = 1;
            this.labelCreatedDate.Text = "00.00.1900 00:00";
            // 
            // bech32Address
            // 
            this.bech32Address.AutoSize = true;
            this.bech32Address.Location = new System.Drawing.Point(2, 0);
            this.bech32Address.Name = "bech32Address";
            this.bech32Address.ShowAddToWatchedAccounts = true;
            this.bech32Address.Size = new System.Drawing.Size(372, 23);
            this.bech32Address.TabIndex = 0;
            // 
            // panel13
            // 
            this.panel13.AutoSize = true;
            this.panel13.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel13.Controls.Add(this.label3);
            this.panel13.Controls.Add(this.label2);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel13.Location = new System.Drawing.Point(0, 0);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(85, 44);
            this.panel13.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Created Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Address:";
            // 
            // AddressShortDetailsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelTop);
            this.Name = "AddressShortDetailsControl";
            this.Size = new System.Drawing.Size(580, 516);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panel14.ResumeLayout(false);
            this.panel14.PerformLayout();
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelTop;
        private Panel panel14;
        private Label labelCreatedDate;
        private Values.Bech32AddressLabel bech32Address;
        private Panel panel13;
        private Label label3;
        private Label label2;
    }
}
