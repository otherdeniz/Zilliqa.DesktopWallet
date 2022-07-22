namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Wallet
{
    partial class WalletAddressDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WalletAddressDetails));
            this.toolStripAccountActions = new System.Windows.Forms.ToolStrip();
            this.buttonReceive = new System.Windows.Forms.ToolStripButton();
            this.buttonSend = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonBackupPrivateKey = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.toolStripAccountActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripAccountActions
            // 
            this.toolStripAccountActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonReceive,
            this.buttonSend,
            this.toolStripSeparator1,
            this.buttonBackupPrivateKey});
            this.toolStripAccountActions.Location = new System.Drawing.Point(0, 0);
            this.toolStripAccountActions.Name = "toolStripAccountActions";
            this.toolStripAccountActions.Size = new System.Drawing.Size(653, 25);
            this.toolStripAccountActions.TabIndex = 1;
            // 
            // buttonReceive
            // 
            this.buttonReceive.Image = ((System.Drawing.Image)(resources.GetObject("buttonReceive.Image")));
            this.buttonReceive.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonReceive.Name = "buttonReceive";
            this.buttonReceive.Size = new System.Drawing.Size(67, 22);
            this.buttonReceive.Text = "Receive";
            // 
            // buttonSend
            // 
            this.buttonSend.Image = ((System.Drawing.Image)(resources.GetObject("buttonSend.Image")));
            this.buttonSend.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(53, 22);
            this.buttonSend.Text = "Send";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // buttonBackupPrivateKey
            // 
            this.buttonBackupPrivateKey.Image = ((System.Drawing.Image)(resources.GetObject("buttonBackupPrivateKey.Image")));
            this.buttonBackupPrivateKey.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonBackupPrivateKey.Name = "buttonBackupPrivateKey";
            this.buttonBackupPrivateKey.Size = new System.Drawing.Size(127, 22);
            this.buttonBackupPrivateKey.Text = "Backup Private Key";
            // 
            // groupBox1
            // 
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(653, 83);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Balance Details";
            // 
            // groupBox2
            // 
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 108);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(653, 83);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ZIL Transactions";
            // 
            // groupBox3
            // 
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 191);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(653, 83);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Fungible Token Transactions (ZRC-2)";
            // 
            // WalletAddressDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStripAccountActions);
            this.Name = "WalletAddressDetails";
            this.Size = new System.Drawing.Size(653, 536);
            this.toolStripAccountActions.ResumeLayout(false);
            this.toolStripAccountActions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ToolStrip toolStripAccountActions;
        private ToolStripButton buttonReceive;
        private ToolStripButton buttonSend;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton buttonBackupPrivateKey;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
    }
}
