namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Main
{
    partial class MainBlockchainBrowserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelCenter = new System.Windows.Forms.Panel();
            this.textDbResult = new System.Windows.Forms.TextBox();
            this.textApiResult = new System.Windows.Forms.TextBox();
            this.buttonAddrInDb = new System.Windows.Forms.Button();
            this.buttonQueryAddr = new System.Windows.Forms.Button();
            this.textAddrInDb = new System.Windows.Forms.TextBox();
            this.textBoxQueryAddr = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelDbInfo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelCrawlerStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonStartCrawler = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.propertyGridBlockchainInfo = new System.Windows.Forms.PropertyGrid();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panelCenter.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCenter
            // 
            this.panelCenter.Controls.Add(this.textDbResult);
            this.panelCenter.Controls.Add(this.textApiResult);
            this.panelCenter.Controls.Add(this.buttonAddrInDb);
            this.panelCenter.Controls.Add(this.buttonQueryAddr);
            this.panelCenter.Controls.Add(this.textAddrInDb);
            this.panelCenter.Controls.Add(this.textBoxQueryAddr);
            this.panelCenter.Controls.Add(this.label4);
            this.panelCenter.Controls.Add(this.label3);
            this.panelCenter.Controls.Add(this.labelDbInfo);
            this.panelCenter.Controls.Add(this.label2);
            this.panelCenter.Controls.Add(this.labelCrawlerStatus);
            this.panelCenter.Controls.Add(this.label1);
            this.panelCenter.Controls.Add(this.buttonStartCrawler);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(0, 0);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(625, 587);
            this.panelCenter.TabIndex = 2;
            // 
            // textDbResult
            // 
            this.textDbResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textDbResult.Location = new System.Drawing.Point(20, 343);
            this.textDbResult.Multiline = true;
            this.textDbResult.Name = "textDbResult";
            this.textDbResult.ReadOnly = true;
            this.textDbResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textDbResult.Size = new System.Drawing.Size(585, 90);
            this.textDbResult.TabIndex = 11;
            // 
            // textApiResult
            // 
            this.textApiResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textApiResult.Location = new System.Drawing.Point(20, 194);
            this.textApiResult.Multiline = true;
            this.textApiResult.Name = "textApiResult";
            this.textApiResult.ReadOnly = true;
            this.textApiResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textApiResult.Size = new System.Drawing.Size(585, 90);
            this.textApiResult.TabIndex = 10;
            // 
            // buttonAddrInDb
            // 
            this.buttonAddrInDb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddrInDb.Location = new System.Drawing.Point(530, 313);
            this.buttonAddrInDb.Name = "buttonAddrInDb";
            this.buttonAddrInDb.Size = new System.Drawing.Size(75, 23);
            this.buttonAddrInDb.TabIndex = 9;
            this.buttonAddrInDb.Text = "Execute";
            this.buttonAddrInDb.UseVisualStyleBackColor = true;
            // 
            // buttonQueryAddr
            // 
            this.buttonQueryAddr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonQueryAddr.Location = new System.Drawing.Point(530, 164);
            this.buttonQueryAddr.Name = "buttonQueryAddr";
            this.buttonQueryAddr.Size = new System.Drawing.Size(75, 23);
            this.buttonQueryAddr.TabIndex = 9;
            this.buttonQueryAddr.Text = "Execute";
            this.buttonQueryAddr.UseVisualStyleBackColor = true;
            this.buttonQueryAddr.Click += new System.EventHandler(this.buttonQueryAddr_Click);
            // 
            // textAddrInDb
            // 
            this.textAddrInDb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textAddrInDb.Location = new System.Drawing.Point(20, 314);
            this.textAddrInDb.Name = "textAddrInDb";
            this.textAddrInDb.Size = new System.Drawing.Size(504, 23);
            this.textAddrInDb.TabIndex = 8;
            // 
            // textBoxQueryAddr
            // 
            this.textBoxQueryAddr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxQueryAddr.Location = new System.Drawing.Point(20, 165);
            this.textBoxQueryAddr.Name = "textBoxQueryAddr";
            this.textBoxQueryAddr.Size = new System.Drawing.Size(504, 23);
            this.textBoxQueryAddr.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 296);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Query Address in DB";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Query Address on API";
            // 
            // labelDbInfo
            // 
            this.labelDbInfo.AutoSize = true;
            this.labelDbInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelDbInfo.Location = new System.Drawing.Point(128, 89);
            this.labelDbInfo.Name = "labelDbInfo";
            this.labelDbInfo.Size = new System.Drawing.Size(62, 15);
            this.labelDbInfo.TabIndex = 6;
            this.labelDbInfo.Text = "Not Exists";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Database Info:";
            // 
            // labelCrawlerStatus
            // 
            this.labelCrawlerStatus.AutoSize = true;
            this.labelCrawlerStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelCrawlerStatus.Location = new System.Drawing.Point(128, 56);
            this.labelCrawlerStatus.Name = "labelCrawlerStatus";
            this.labelCrawlerStatus.Size = new System.Drawing.Size(52, 15);
            this.labelCrawlerStatus.TabIndex = 6;
            this.labelCrawlerStatus.Text = "Inactive";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Crawler Status:";
            // 
            // buttonStartCrawler
            // 
            this.buttonStartCrawler.Location = new System.Drawing.Point(20, 19);
            this.buttonStartCrawler.Name = "buttonStartCrawler";
            this.buttonStartCrawler.Size = new System.Drawing.Size(120, 23);
            this.buttonStartCrawler.TabIndex = 4;
            this.buttonStartCrawler.Text = "Start Crawler";
            this.buttonStartCrawler.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.propertyGridBlockchainInfo);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(630, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 587);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Blockchain Info";
            // 
            // propertyGridBlockchainInfo
            // 
            this.propertyGridBlockchainInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridBlockchainInfo.Enabled = false;
            this.propertyGridBlockchainInfo.HelpVisible = false;
            this.propertyGridBlockchainInfo.Location = new System.Drawing.Point(3, 19);
            this.propertyGridBlockchainInfo.Name = "propertyGridBlockchainInfo";
            this.propertyGridBlockchainInfo.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.propertyGridBlockchainInfo.Size = new System.Drawing.Size(194, 565);
            this.propertyGridBlockchainInfo.TabIndex = 0;
            this.propertyGridBlockchainInfo.ToolbarVisible = false;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(625, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(5, 587);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // MainBlockchainBrowserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainBlockchainBrowserControl";
            this.Size = new System.Drawing.Size(830, 587);
            this.panelCenter.ResumeLayout(false);
            this.panelCenter.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelCenter;
        private GroupBox groupBox1;
        private PropertyGrid propertyGridBlockchainInfo;
        private Button buttonQueryAddr;
        private TextBox textBoxQueryAddr;
        private Label label3;
        private Label labelDbInfo;
        private Label label2;
        private Label labelCrawlerStatus;
        private Label label1;
        private Button buttonStartCrawler;
        private Button buttonAddrInDb;
        private TextBox textAddrInDb;
        private Label label4;
        private TextBox textDbResult;
        private TextBox textApiResult;
        private Splitter splitter1;
    }
}
