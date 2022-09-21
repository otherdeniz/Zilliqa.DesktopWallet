namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Details
{
    partial class SmartContractDetailsControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SmartContractDetailsControl));
            this.groupBoxDetails = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panelTabsTransactions = new System.Windows.Forms.Panel();
            this.panelTabPagesTransactions = new System.Windows.Forms.Panel();
            this.textConstructorArguments = new System.Windows.Forms.TextBox();
            this.toolStripPages = new System.Windows.Forms.ToolStrip();
            this.tabButtonArguments = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tabButtonCode = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tabButtonTransaction = new System.Windows.Forms.ToolStripButton();
            this.syntaxDocument1 = new Alsing.SourceCode.SyntaxDocument(this.components);
            this.groupBoxDetails.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelTabsTransactions.SuspendLayout();
            this.panelTabPagesTransactions.SuspendLayout();
            this.toolStripPages.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxDetails
            // 
            this.groupBoxDetails.Controls.Add(this.panel2);
            this.groupBoxDetails.Controls.Add(this.panel1);
            this.groupBoxDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxDetails.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBoxDetails.Location = new System.Drawing.Point(0, 0);
            this.groupBoxDetails.Name = "groupBoxDetails";
            this.groupBoxDetails.Size = new System.Drawing.Size(472, 83);
            this.groupBoxDetails.TabIndex = 2;
            this.groupBoxDetails.TabStop = false;
            this.groupBoxDetails.Text = "Overview";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.labelDate);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel2.Location = new System.Drawing.Point(110, 19);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(359, 61);
            this.panel2.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "-";
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(6, 4);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(91, 15);
            this.labelDate.TabIndex = 1;
            this.labelDate.Text = "01.01.1900 00:00";
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel1.Location = new System.Drawing.Point(3, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(107, 61);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Contract Address:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Contract Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Created Date:";
            // 
            // panelTabsTransactions
            // 
            this.panelTabsTransactions.Controls.Add(this.panelTabPagesTransactions);
            this.panelTabsTransactions.Controls.Add(this.toolStripPages);
            this.panelTabsTransactions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTabsTransactions.Location = new System.Drawing.Point(0, 83);
            this.panelTabsTransactions.Name = "panelTabsTransactions";
            this.panelTabsTransactions.Size = new System.Drawing.Size(472, 408);
            this.panelTabsTransactions.TabIndex = 9;
            // 
            // panelTabPagesTransactions
            // 
            this.panelTabPagesTransactions.Controls.Add(this.textConstructorArguments);
            this.panelTabPagesTransactions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTabPagesTransactions.Location = new System.Drawing.Point(0, 23);
            this.panelTabPagesTransactions.Name = "panelTabPagesTransactions";
            this.panelTabPagesTransactions.Size = new System.Drawing.Size(472, 385);
            this.panelTabPagesTransactions.TabIndex = 2;
            // 
            // textConstructorArguments
            // 
            this.textConstructorArguments.Location = new System.Drawing.Point(40, 46);
            this.textConstructorArguments.Multiline = true;
            this.textConstructorArguments.Name = "textConstructorArguments";
            this.textConstructorArguments.ReadOnly = true;
            this.textConstructorArguments.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textConstructorArguments.Size = new System.Drawing.Size(140, 107);
            this.textConstructorArguments.TabIndex = 0;
            this.textConstructorArguments.Visible = false;
            // 
            // toolStripPages
            // 
            this.toolStripPages.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tabButtonArguments,
            this.toolStripSeparator1,
            this.tabButtonCode,
            this.toolStripSeparator5,
            this.tabButtonTransaction});
            this.toolStripPages.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStripPages.Location = new System.Drawing.Point(0, 0);
            this.toolStripPages.Name = "toolStripPages";
            this.toolStripPages.Padding = new System.Windows.Forms.Padding(4, 0, 1, 0);
            this.toolStripPages.Size = new System.Drawing.Size(472, 23);
            this.toolStripPages.TabIndex = 0;
            // 
            // tabButtonArguments
            // 
            this.tabButtonArguments.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tabButtonArguments.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabButtonArguments.Image = ((System.Drawing.Image)(resources.GetObject("tabButtonArguments.Image")));
            this.tabButtonArguments.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tabButtonArguments.Name = "tabButtonArguments";
            this.tabButtonArguments.Size = new System.Drawing.Size(136, 19);
            this.tabButtonArguments.Text = "Constructor Arguments";
            this.tabButtonArguments.Click += new System.EventHandler(this.tabButtonArguments_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // tabButtonCode
            // 
            this.tabButtonCode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tabButtonCode.Image = ((System.Drawing.Image)(resources.GetObject("tabButtonCode.Image")));
            this.tabButtonCode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tabButtonCode.Name = "tabButtonCode";
            this.tabButtonCode.Size = new System.Drawing.Size(39, 19);
            this.tabButtonCode.Text = "Code";
            this.tabButtonCode.Click += new System.EventHandler(this.tabButtonCode_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 23);
            // 
            // tabButtonTransaction
            // 
            this.tabButtonTransaction.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tabButtonTransaction.Image = ((System.Drawing.Image)(resources.GetObject("tabButtonTransaction.Image")));
            this.tabButtonTransaction.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tabButtonTransaction.Name = "tabButtonTransaction";
            this.tabButtonTransaction.Size = new System.Drawing.Size(139, 19);
            this.tabButtonTransaction.Text = "Deployment Transaction";
            this.tabButtonTransaction.Click += new System.EventHandler(this.tabButtonTransaction_Click);
            // 
            // syntaxDocument1
            // 
            this.syntaxDocument1.Lines = new string[] {
        ""};
            this.syntaxDocument1.MaxUndoBufferSize = 1000;
            this.syntaxDocument1.Modified = false;
            this.syntaxDocument1.UndoStep = 0;
            // 
            // SmartContractDetailsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelTabsTransactions);
            this.Controls.Add(this.groupBoxDetails);
            this.Name = "SmartContractDetailsControl";
            this.Size = new System.Drawing.Size(472, 491);
            this.Load += new System.EventHandler(this.SmartContractDetailsControl_Load);
            this.groupBoxDetails.ResumeLayout(false);
            this.groupBoxDetails.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelTabsTransactions.ResumeLayout(false);
            this.panelTabsTransactions.PerformLayout();
            this.panelTabPagesTransactions.ResumeLayout(false);
            this.panelTabPagesTransactions.PerformLayout();
            this.toolStripPages.ResumeLayout(false);
            this.toolStripPages.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBoxDetails;
        private Panel panel2;
        private Label label4;
        private Label labelDate;
        private Panel panel1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Panel panelTabsTransactions;
        private Panel panelTabPagesTransactions;
        private ToolStrip toolStripPages;
        private ToolStripButton tabButtonArguments;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton tabButtonCode;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripButton tabButtonTransaction;
        private TextBox textConstructorArguments;
        private Alsing.SourceCode.SyntaxDocument syntaxDocument1;
    }
}
