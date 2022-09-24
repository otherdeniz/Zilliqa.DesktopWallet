namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Main
{
    partial class MainTokensControl
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
            this.panelLoading = new System.Windows.Forms.Panel();
            this.labelLoading = new System.Windows.Forms.Label();
            this.panelLoaded = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBoxTokensList = new System.Windows.Forms.GroupBox();
            this.gridViewTokens = new Zilliqa.DesktopWallet.Gui.WinForms.Controls.GridView.GridViewControl();
            this.groupBoxMarketData = new System.Windows.Forms.GroupBox();
            this.propertyGridMarketData = new System.Windows.Forms.PropertyGrid();
            this.groupBoxTokenDetails = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.linkLabelWhitepaper = new System.Windows.Forms.LinkLabel();
            this.label9 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.linkLabelTelegram = new System.Windows.Forms.LinkLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.linkLabelWebsite = new System.Windows.Forms.LinkLabel();
            this.label8 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.labelMaxSupply = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelInitSupply = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelContractAddress = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelSymbol = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            this.timerStartLoading = new System.Windows.Forms.Timer(this.components);
            this.panelLoading.SuspendLayout();
            this.panelLoaded.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBoxTokensList.SuspendLayout();
            this.groupBoxMarketData.SuspendLayout();
            this.groupBoxTokenDetails.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // panelLoading
            // 
            this.panelLoading.Controls.Add(this.labelLoading);
            this.panelLoading.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLoading.Location = new System.Drawing.Point(0, 0);
            this.panelLoading.Name = "panelLoading";
            this.panelLoading.Size = new System.Drawing.Size(535, 45);
            this.panelLoading.TabIndex = 1;
            // 
            // labelLoading
            // 
            this.labelLoading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelLoading.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelLoading.Location = new System.Drawing.Point(0, 0);
            this.labelLoading.Name = "labelLoading";
            this.labelLoading.Size = new System.Drawing.Size(535, 45);
            this.labelLoading.TabIndex = 0;
            this.labelLoading.Text = "Loading, please wait...";
            this.labelLoading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelLoaded
            // 
            this.panelLoaded.Controls.Add(this.splitContainer1);
            this.panelLoaded.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLoaded.Location = new System.Drawing.Point(0, 45);
            this.panelLoaded.Name = "panelLoaded";
            this.panelLoaded.Size = new System.Drawing.Size(535, 377);
            this.panelLoaded.TabIndex = 2;
            this.panelLoaded.Visible = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBoxTokensList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBoxMarketData);
            this.splitContainer1.Panel2.Controls.Add(this.groupBoxTokenDetails);
            this.splitContainer1.Size = new System.Drawing.Size(535, 377);
            this.splitContainer1.SplitterDistance = 284;
            this.splitContainer1.TabIndex = 1;
            // 
            // groupBoxTokensList
            // 
            this.groupBoxTokensList.Controls.Add(this.gridViewTokens);
            this.groupBoxTokensList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxTokensList.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBoxTokensList.Location = new System.Drawing.Point(0, 0);
            this.groupBoxTokensList.Name = "groupBoxTokensList";
            this.groupBoxTokensList.Size = new System.Drawing.Size(284, 377);
            this.groupBoxTokensList.TabIndex = 2;
            this.groupBoxTokensList.TabStop = false;
            this.groupBoxTokensList.Text = "ZRC-2 Tokens";
            // 
            // gridViewTokens
            // 
            this.gridViewTokens.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridViewTokens.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gridViewTokens.Location = new System.Drawing.Point(3, 19);
            this.gridViewTokens.Name = "gridViewTokens";
            this.gridViewTokens.Size = new System.Drawing.Size(278, 355);
            this.gridViewTokens.TabIndex = 1;
            this.gridViewTokens.SelectionChanged += new System.EventHandler<Zilliqa.DesktopWallet.Gui.WinForms.Controls.GridView.GridViewControl.SelectedItemEventArgs>(this.gridViewTokens_SelectionChanged);
            // 
            // groupBoxMarketData
            // 
            this.groupBoxMarketData.Controls.Add(this.propertyGridMarketData);
            this.groupBoxMarketData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxMarketData.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBoxMarketData.Location = new System.Drawing.Point(0, 223);
            this.groupBoxMarketData.Name = "groupBoxMarketData";
            this.groupBoxMarketData.Size = new System.Drawing.Size(247, 154);
            this.groupBoxMarketData.TabIndex = 1;
            this.groupBoxMarketData.TabStop = false;
            this.groupBoxMarketData.Text = "Market Data";
            this.groupBoxMarketData.Visible = false;
            // 
            // propertyGridMarketData
            // 
            this.propertyGridMarketData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridMarketData.Enabled = false;
            this.propertyGridMarketData.HelpVisible = false;
            this.propertyGridMarketData.Location = new System.Drawing.Point(3, 19);
            this.propertyGridMarketData.Name = "propertyGridMarketData";
            this.propertyGridMarketData.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.propertyGridMarketData.Size = new System.Drawing.Size(241, 132);
            this.propertyGridMarketData.TabIndex = 1;
            this.propertyGridMarketData.ToolbarVisible = false;
            // 
            // groupBoxTokenDetails
            // 
            this.groupBoxTokenDetails.Controls.Add(this.panel1);
            this.groupBoxTokenDetails.Controls.Add(this.labelSymbol);
            this.groupBoxTokenDetails.Controls.Add(this.labelName);
            this.groupBoxTokenDetails.Controls.Add(this.pictureBoxIcon);
            this.groupBoxTokenDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxTokenDetails.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBoxTokenDetails.Location = new System.Drawing.Point(0, 0);
            this.groupBoxTokenDetails.Name = "groupBoxTokenDetails";
            this.groupBoxTokenDetails.Size = new System.Drawing.Size(247, 223);
            this.groupBoxTokenDetails.TabIndex = 0;
            this.groupBoxTokenDetails.TabStop = false;
            this.groupBoxTokenDetails.Text = "Token Details";
            this.groupBoxTokenDetails.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel1.Location = new System.Drawing.Point(6, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(235, 141);
            this.panel1.TabIndex = 2;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.linkLabelWhitepaper);
            this.panel7.Controls.Add(this.label9);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 115);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(235, 23);
            this.panel7.TabIndex = 8;
            // 
            // linkLabelWhitepaper
            // 
            this.linkLabelWhitepaper.AutoSize = true;
            this.linkLabelWhitepaper.Dock = System.Windows.Forms.DockStyle.Left;
            this.linkLabelWhitepaper.Location = new System.Drawing.Point(74, 0);
            this.linkLabelWhitepaper.Name = "linkLabelWhitepaper";
            this.linkLabelWhitepaper.Padding = new System.Windows.Forms.Padding(3);
            this.linkLabelWhitepaper.Size = new System.Drawing.Size(40, 21);
            this.linkLabelWhitepaper.TabIndex = 3;
            this.linkLabelWhitepaper.TabStop = true;
            this.linkLabelWhitepaper.Text = "none";
            this.linkLabelWhitepaper.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Left;
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.label9.Size = new System.Drawing.Size(74, 21);
            this.label9.TabIndex = 1;
            this.label9.Text = "Whitepaper:";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.linkLabelTelegram);
            this.panel6.Controls.Add(this.label7);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 92);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(235, 23);
            this.panel6.TabIndex = 7;
            // 
            // linkLabelTelegram
            // 
            this.linkLabelTelegram.AutoSize = true;
            this.linkLabelTelegram.Dock = System.Windows.Forms.DockStyle.Left;
            this.linkLabelTelegram.Location = new System.Drawing.Point(61, 0);
            this.linkLabelTelegram.Name = "linkLabelTelegram";
            this.linkLabelTelegram.Padding = new System.Windows.Forms.Padding(3);
            this.linkLabelTelegram.Size = new System.Drawing.Size(40, 21);
            this.linkLabelTelegram.TabIndex = 3;
            this.linkLabelTelegram.TabStop = true;
            this.linkLabelTelegram.Text = "none";
            this.linkLabelTelegram.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Left;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.label7.Size = new System.Drawing.Size(61, 21);
            this.label7.TabIndex = 1;
            this.label7.Text = "Telegram:";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.linkLabelWebsite);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 69);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(235, 23);
            this.panel5.TabIndex = 6;
            // 
            // linkLabelWebsite
            // 
            this.linkLabelWebsite.AutoSize = true;
            this.linkLabelWebsite.Dock = System.Windows.Forms.DockStyle.Left;
            this.linkLabelWebsite.Location = new System.Drawing.Point(55, 0);
            this.linkLabelWebsite.Name = "linkLabelWebsite";
            this.linkLabelWebsite.Padding = new System.Windows.Forms.Padding(3);
            this.linkLabelWebsite.Size = new System.Drawing.Size(40, 21);
            this.linkLabelWebsite.TabIndex = 3;
            this.linkLabelWebsite.TabStop = true;
            this.linkLabelWebsite.Text = "none";
            this.linkLabelWebsite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Left;
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.label8.Size = new System.Drawing.Size(55, 21);
            this.label8.TabIndex = 1;
            this.label8.Text = "Website:";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.labelMaxSupply);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 46);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(235, 23);
            this.panel4.TabIndex = 5;
            // 
            // labelMaxSupply
            // 
            this.labelMaxSupply.AutoSize = true;
            this.labelMaxSupply.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelMaxSupply.Location = new System.Drawing.Point(75, 0);
            this.labelMaxSupply.Name = "labelMaxSupply";
            this.labelMaxSupply.Padding = new System.Windows.Forms.Padding(3);
            this.labelMaxSupply.Size = new System.Drawing.Size(19, 21);
            this.labelMaxSupply.TabIndex = 2;
            this.labelMaxSupply.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.label6.Size = new System.Drawing.Size(75, 21);
            this.label6.TabIndex = 1;
            this.label6.Text = "Max Supply:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelInitSupply);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(235, 23);
            this.panel2.TabIndex = 4;
            // 
            // labelInitSupply
            // 
            this.labelInitSupply.AutoSize = true;
            this.labelInitSupply.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelInitSupply.Location = new System.Drawing.Point(69, 0);
            this.labelInitSupply.Name = "labelInitSupply";
            this.labelInitSupply.Padding = new System.Windows.Forms.Padding(3);
            this.labelInitSupply.Size = new System.Drawing.Size(19, 21);
            this.labelInitSupply.TabIndex = 2;
            this.labelInitSupply.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.label2.Size = new System.Drawing.Size(69, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Init Supply:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.labelContractAddress);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(235, 23);
            this.panel3.TabIndex = 3;
            // 
            // labelContractAddress
            // 
            this.labelContractAddress.AutoSize = true;
            this.labelContractAddress.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelContractAddress.Location = new System.Drawing.Point(104, 0);
            this.labelContractAddress.Name = "labelContractAddress";
            this.labelContractAddress.Padding = new System.Windows.Forms.Padding(3);
            this.labelContractAddress.Size = new System.Drawing.Size(39, 21);
            this.labelContractAddress.TabIndex = 2;
            this.labelContractAddress.Text = "zil1...";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.label4.Size = new System.Drawing.Size(104, 21);
            this.label4.TabIndex = 1;
            this.label4.Text = "Contract Address:";
            // 
            // labelSymbol
            // 
            this.labelSymbol.AutoSize = true;
            this.labelSymbol.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelSymbol.Location = new System.Drawing.Point(60, 43);
            this.labelSymbol.Name = "labelSymbol";
            this.labelSymbol.Size = new System.Drawing.Size(31, 21);
            this.labelSymbol.TabIndex = 1;
            this.labelSymbol.Text = "ZIL";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelName.Location = new System.Drawing.Point(60, 22);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(59, 21);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "Zilliqa";
            // 
            // pictureBoxIcon
            // 
            this.pictureBoxIcon.Location = new System.Drawing.Point(6, 22);
            this.pictureBoxIcon.Name = "pictureBoxIcon";
            this.pictureBoxIcon.Size = new System.Drawing.Size(48, 48);
            this.pictureBoxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxIcon.TabIndex = 0;
            this.pictureBoxIcon.TabStop = false;
            // 
            // timerStartLoading
            // 
            this.timerStartLoading.Interval = 10;
            this.timerStartLoading.Tick += new System.EventHandler(this.timerStartLoading_Tick);
            // 
            // MainTokensControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelLoaded);
            this.Controls.Add(this.panelLoading);
            this.Name = "MainTokensControl";
            this.Size = new System.Drawing.Size(535, 422);
            this.Load += new System.EventHandler(this.MainTokensControl_Load);
            this.panelLoading.ResumeLayout(false);
            this.panelLoaded.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBoxTokensList.ResumeLayout(false);
            this.groupBoxMarketData.ResumeLayout(false);
            this.groupBoxTokenDetails.ResumeLayout(false);
            this.groupBoxTokenDetails.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Panel panelLoading;
        private Label labelLoading;
        private Panel panelLoaded;
        private System.Windows.Forms.Timer timerStartLoading;
        private SplitContainer splitContainer1;
        private GroupBox groupBoxTokenDetails;
        private GridView.GridViewControl gridViewTokens;
        private Label labelSymbol;
        private Label labelName;
        private PictureBox pictureBoxIcon;
        private Panel panel1;
        private Panel panel3;
        private Label labelContractAddress;
        private Label label4;
        private Panel panel4;
        private Label labelMaxSupply;
        private Label label6;
        private Panel panel2;
        private Label labelInitSupply;
        private Label label2;
        private Panel panel7;
        private LinkLabel linkLabelWhitepaper;
        private Label label9;
        private Panel panel6;
        private LinkLabel linkLabelTelegram;
        private Label label7;
        private Panel panel5;
        private LinkLabel linkLabelWebsite;
        private Label label8;
        private GroupBox groupBoxMarketData;
        private PropertyGrid propertyGridMarketData;
        private GroupBox groupBoxTokensList;
    }
}
