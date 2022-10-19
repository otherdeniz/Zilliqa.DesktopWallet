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
            this.buttonMenuAdd = new System.Windows.Forms.Button();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.buttonMenuContract = new System.Windows.Forms.Button();
            this.panelAddress = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timerButtonPressed = new System.Windows.Forms.Timer(this.components);
            this.labelCaption = new System.Windows.Forms.Label();
            this.contextMenuAdd = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuAddWatched = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAddAddressbook = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuContract = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuContractCall = new System.Windows.Forms.ToolStripMenuItem();
            this.menuContractRedeploy = new System.Windows.Forms.ToolStripMenuItem();
            this.panelAddress.SuspendLayout();
            this.contextMenuAdd.SuspendLayout();
            this.contextMenuContract.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolTipButton
            // 
            this.toolTipButton.AutomaticDelay = 50;
            this.toolTipButton.AutoPopDelay = 5000;
            this.toolTipButton.InitialDelay = 50;
            this.toolTipButton.ReshowDelay = 10;
            this.toolTipButton.UseAnimation = false;
            this.toolTipButton.UseFading = false;
            // 
            // buttonCopy
            // 
            this.buttonCopy.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonCopy.Image = ((System.Drawing.Image)(resources.GetObject("buttonCopy.Image")));
            this.buttonCopy.Location = new System.Drawing.Point(375, 0);
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
            this.buttonBrowse.Location = new System.Drawing.Point(399, 0);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(24, 25);
            this.buttonBrowse.TabIndex = 5;
            this.toolTipButton.SetToolTip(this.buttonBrowse, "Open in Block Explorer");
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // buttonMenuAdd
            // 
            this.buttonMenuAdd.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonMenuAdd.Image = ((System.Drawing.Image)(resources.GetObject("buttonMenuAdd.Image")));
            this.buttonMenuAdd.Location = new System.Drawing.Point(423, 0);
            this.buttonMenuAdd.Name = "buttonMenuAdd";
            this.buttonMenuAdd.Size = new System.Drawing.Size(24, 25);
            this.buttonMenuAdd.TabIndex = 7;
            this.toolTipButton.SetToolTip(this.buttonMenuAdd, "Add to ...");
            this.buttonMenuAdd.UseVisualStyleBackColor = true;
            this.buttonMenuAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonOpen
            // 
            this.buttonOpen.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonOpen.Image = ((System.Drawing.Image)(resources.GetObject("buttonOpen.Image")));
            this.buttonOpen.Location = new System.Drawing.Point(351, 0);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(24, 25);
            this.buttonOpen.TabIndex = 8;
            this.toolTipButton.SetToolTip(this.buttonOpen, "Open");
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // buttonMenuContract
            // 
            this.buttonMenuContract.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonMenuContract.Image = ((System.Drawing.Image)(resources.GetObject("buttonMenuContract.Image")));
            this.buttonMenuContract.Location = new System.Drawing.Point(447, 0);
            this.buttonMenuContract.Name = "buttonMenuContract";
            this.buttonMenuContract.Size = new System.Drawing.Size(24, 25);
            this.buttonMenuContract.TabIndex = 9;
            this.toolTipButton.SetToolTip(this.buttonMenuContract, "Smart Contract Actions ...");
            this.buttonMenuContract.UseVisualStyleBackColor = true;
            this.buttonMenuContract.Visible = false;
            this.buttonMenuContract.Click += new System.EventHandler(this.buttonMenuContract_Click);
            // 
            // panelAddress
            // 
            this.panelAddress.Controls.Add(this.label4);
            this.panelAddress.Controls.Add(this.label3);
            this.panelAddress.Controls.Add(this.label2);
            this.panelAddress.Controls.Add(this.label1);
            this.panelAddress.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelAddress.Location = new System.Drawing.Point(57, 0);
            this.panelAddress.Name = "panelAddress";
            this.panelAddress.Size = new System.Drawing.Size(294, 25);
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
            // labelCaption
            // 
            this.labelCaption.AutoSize = true;
            this.labelCaption.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelCaption.Location = new System.Drawing.Point(0, 0);
            this.labelCaption.Margin = new System.Windows.Forms.Padding(0);
            this.labelCaption.Name = "labelCaption";
            this.labelCaption.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.labelCaption.Size = new System.Drawing.Size(57, 23);
            this.labelCaption.TabIndex = 5;
            this.labelCaption.Text = "[Caption]";
            // 
            // contextMenuAdd
            // 
            this.contextMenuAdd.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAddWatched,
            this.menuAddAddressbook});
            this.contextMenuAdd.Name = "contextMenuStrip1";
            this.contextMenuAdd.Size = new System.Drawing.Size(214, 48);
            // 
            // menuAddWatched
            // 
            this.menuAddWatched.Image = ((System.Drawing.Image)(resources.GetObject("menuAddWatched.Image")));
            this.menuAddWatched.Name = "menuAddWatched";
            this.menuAddWatched.Size = new System.Drawing.Size(213, 22);
            this.menuAddWatched.Text = "Add to Watched Accounts";
            this.menuAddWatched.Click += new System.EventHandler(this.menuAddWatched_Click);
            // 
            // menuAddAddressbook
            // 
            this.menuAddAddressbook.Image = ((System.Drawing.Image)(resources.GetObject("menuAddAddressbook.Image")));
            this.menuAddAddressbook.Name = "menuAddAddressbook";
            this.menuAddAddressbook.Size = new System.Drawing.Size(213, 22);
            this.menuAddAddressbook.Text = "Add to Address Book";
            this.menuAddAddressbook.Click += new System.EventHandler(this.menuAddAddressbook_Click);
            // 
            // contextMenuContract
            // 
            this.contextMenuContract.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuContractCall,
            this.menuContractRedeploy});
            this.contextMenuContract.Name = "contextMenuContract";
            this.contextMenuContract.Size = new System.Drawing.Size(231, 48);
            // 
            // menuContractCall
            // 
            this.menuContractCall.Image = ((System.Drawing.Image)(resources.GetObject("menuContractCall.Image")));
            this.menuContractCall.Name = "menuContractCall";
            this.menuContractCall.Size = new System.Drawing.Size(230, 22);
            this.menuContractCall.Text = "Call this Smart Contract";
            this.menuContractCall.Click += new System.EventHandler(this.menuContractCall_Click);
            // 
            // menuContractRedeploy
            // 
            this.menuContractRedeploy.Image = ((System.Drawing.Image)(resources.GetObject("menuContractRedeploy.Image")));
            this.menuContractRedeploy.Name = "menuContractRedeploy";
            this.menuContractRedeploy.Size = new System.Drawing.Size(230, 22);
            this.menuContractRedeploy.Text = "Re-Deploy this Smat Contract";
            this.menuContractRedeploy.Click += new System.EventHandler(this.menuContractRedeploy_Click);
            // 
            // Bech32AddressLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.buttonMenuContract);
            this.Controls.Add(this.buttonMenuAdd);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.buttonCopy);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.panelAddress);
            this.Controls.Add(this.labelCaption);
            this.Name = "Bech32AddressLabel";
            this.Size = new System.Drawing.Size(601, 25);
            this.Load += new System.EventHandler(this.Bech32AddressLabel_Load);
            this.Resize += new System.EventHandler(this.Bech32AddressLabel_Resize);
            this.panelAddress.ResumeLayout(false);
            this.panelAddress.PerformLayout();
            this.contextMenuAdd.ResumeLayout(false);
            this.contextMenuContract.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private Button buttonMenuAdd;
        private Button buttonOpen;
        private Label labelCaption;
        private ContextMenuStrip contextMenuAdd;
        private ToolStripMenuItem menuAddAddressbook;
        private ToolStripMenuItem menuAddWatched;
        private Button buttonMenuContract;
        private ContextMenuStrip contextMenuContract;
        private ToolStripMenuItem menuContractCall;
        private ToolStripMenuItem menuContractRedeploy;
    }
}
