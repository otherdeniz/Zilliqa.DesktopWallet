namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Main
{
    partial class BottomStatusControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BottomStatusControl));
            this.label1 = new System.Windows.Forms.Label();
            this.panelRowStatus = new System.Windows.Forms.Panel();
            this.textStatus = new System.Windows.Forms.Label();
            this.panelRowDbSize = new System.Windows.Forms.Panel();
            this.textDbSize = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBlocksCount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textDbBlocksCount = new System.Windows.Forms.Label();
            this.labelBlocksCount = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textTransactionsCount = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textDbTransactionsCount = new System.Windows.Forms.Label();
            this.labelTransactionCount = new System.Windows.Forms.Label();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.toolStripCommands = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.buttonStart = new System.Windows.Forms.ToolStripButton();
            this.buttonStop = new System.Windows.Forms.ToolStripButton();
            this.timerRefreshDbSize = new System.Windows.Forms.Timer(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelLastBlockdate = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panelRowStatus.SuspendLayout();
            this.panelRowDbSize.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStripCommands.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Status:";
            // 
            // panelRowStatus
            // 
            this.panelRowStatus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelRowStatus.Controls.Add(this.textStatus);
            this.panelRowStatus.Controls.Add(this.label1);
            this.panelRowStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelRowStatus.Location = new System.Drawing.Point(0, 23);
            this.panelRowStatus.Name = "panelRowStatus";
            this.panelRowStatus.Padding = new System.Windows.Forms.Padding(3);
            this.panelRowStatus.Size = new System.Drawing.Size(276, 19);
            this.panelRowStatus.TabIndex = 1;
            // 
            // textStatus
            // 
            this.textStatus.AutoSize = true;
            this.textStatus.Dock = System.Windows.Forms.DockStyle.Left;
            this.textStatus.Location = new System.Drawing.Point(55, 3);
            this.textStatus.Name = "textStatus";
            this.textStatus.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.textStatus.Size = new System.Drawing.Size(36, 15);
            this.textStatus.TabIndex = 1;
            this.textStatus.Text = "Idle";
            // 
            // panelRowDbSize
            // 
            this.panelRowDbSize.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelRowDbSize.Controls.Add(this.textDbSize);
            this.panelRowDbSize.Controls.Add(this.label3);
            this.panelRowDbSize.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelRowDbSize.Location = new System.Drawing.Point(0, 42);
            this.panelRowDbSize.Name = "panelRowDbSize";
            this.panelRowDbSize.Padding = new System.Windows.Forms.Padding(3);
            this.panelRowDbSize.Size = new System.Drawing.Size(276, 19);
            this.panelRowDbSize.TabIndex = 2;
            // 
            // textDbSize
            // 
            this.textDbSize.AutoSize = true;
            this.textDbSize.Dock = System.Windows.Forms.DockStyle.Left;
            this.textDbSize.Location = new System.Drawing.Point(89, 3);
            this.textDbSize.Name = "textDbSize";
            this.textDbSize.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.textDbSize.Size = new System.Drawing.Size(26, 15);
            this.textDbSize.TabIndex = 1;
            this.textDbSize.Text = "...";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Local DB Size:";
            // 
            // panel2
            // 
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.Controls.Add(this.textBlocksCount);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.textDbBlocksCount);
            this.panel2.Controls.Add(this.labelBlocksCount);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 61);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3);
            this.panel2.Size = new System.Drawing.Size(276, 19);
            this.panel2.TabIndex = 3;
            // 
            // textBlocksCount
            // 
            this.textBlocksCount.AutoSize = true;
            this.textBlocksCount.Dock = System.Windows.Forms.DockStyle.Left;
            this.textBlocksCount.Location = new System.Drawing.Point(141, 3);
            this.textBlocksCount.Name = "textBlocksCount";
            this.textBlocksCount.Size = new System.Drawing.Size(16, 15);
            this.textBlocksCount.TabIndex = 1;
            this.textBlocksCount.Text = "...";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Location = new System.Drawing.Point(129, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "/";
            // 
            // textDbBlocksCount
            // 
            this.textDbBlocksCount.AutoSize = true;
            this.textDbBlocksCount.Dock = System.Windows.Forms.DockStyle.Left;
            this.textDbBlocksCount.Location = new System.Drawing.Point(113, 3);
            this.textDbBlocksCount.Name = "textDbBlocksCount";
            this.textDbBlocksCount.Size = new System.Drawing.Size(16, 15);
            this.textDbBlocksCount.TabIndex = 2;
            this.textDbBlocksCount.Text = "...";
            // 
            // labelBlocksCount
            // 
            this.labelBlocksCount.AutoSize = true;
            this.labelBlocksCount.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelBlocksCount.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelBlocksCount.Location = new System.Drawing.Point(3, 3);
            this.labelBlocksCount.Name = "labelBlocksCount";
            this.labelBlocksCount.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.labelBlocksCount.Size = new System.Drawing.Size(110, 13);
            this.labelBlocksCount.TabIndex = 0;
            this.labelBlocksCount.Text = "Number of Blocks:";
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.textTransactionsCount);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.textDbTransactionsCount);
            this.panel1.Controls.Add(this.labelTransactionCount);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 80);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3);
            this.panel1.Size = new System.Drawing.Size(276, 19);
            this.panel1.TabIndex = 4;
            // 
            // textTransactionsCount
            // 
            this.textTransactionsCount.AutoSize = true;
            this.textTransactionsCount.Dock = System.Windows.Forms.DockStyle.Left;
            this.textTransactionsCount.Location = new System.Drawing.Point(173, 3);
            this.textTransactionsCount.Name = "textTransactionsCount";
            this.textTransactionsCount.Size = new System.Drawing.Size(16, 15);
            this.textTransactionsCount.TabIndex = 1;
            this.textTransactionsCount.Text = "...";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Location = new System.Drawing.Point(161, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "/";
            // 
            // textDbTransactionsCount
            // 
            this.textDbTransactionsCount.AutoSize = true;
            this.textDbTransactionsCount.Dock = System.Windows.Forms.DockStyle.Left;
            this.textDbTransactionsCount.Location = new System.Drawing.Point(145, 3);
            this.textDbTransactionsCount.Name = "textDbTransactionsCount";
            this.textDbTransactionsCount.Size = new System.Drawing.Size(16, 15);
            this.textDbTransactionsCount.TabIndex = 5;
            this.textDbTransactionsCount.Text = "...";
            // 
            // labelTransactionCount
            // 
            this.labelTransactionCount.AutoSize = true;
            this.labelTransactionCount.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelTransactionCount.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelTransactionCount.Location = new System.Drawing.Point(3, 3);
            this.labelTransactionCount.Name = "labelTransactionCount";
            this.labelTransactionCount.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.labelTransactionCount.Size = new System.Drawing.Size(142, 13);
            this.labelTransactionCount.TabIndex = 0;
            this.labelTransactionCount.Text = "Number of Transactions:";
            // 
            // timerRefresh
            // 
            this.timerRefresh.Interval = 2500;
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // toolStripCommands
            // 
            this.toolStripCommands.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.buttonStart,
            this.buttonStop});
            this.toolStripCommands.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStripCommands.Location = new System.Drawing.Point(0, 0);
            this.toolStripCommands.Name = "toolStripCommands";
            this.toolStripCommands.Size = new System.Drawing.Size(276, 23);
            this.toolStripCommands.TabIndex = 5;
            this.toolStripCommands.Text = "toolStripButtons";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.toolStripLabel1.Size = new System.Drawing.Size(35, 19);
            this.toolStripLabel1.Text = "Sync:";
            // 
            // buttonStart
            // 
            this.buttonStart.Enabled = false;
            this.buttonStart.Image = ((System.Drawing.Image)(resources.GetObject("buttonStart.Image")));
            this.buttonStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(51, 20);
            this.buttonStart.Text = "Start";
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Enabled = false;
            this.buttonStop.Image = ((System.Drawing.Image)(resources.GetObject("buttonStop.Image")));
            this.buttonStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(51, 20);
            this.buttonStop.Text = "Stop";
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // timerRefreshDbSize
            // 
            this.timerRefreshDbSize.Interval = 10000;
            this.timerRefreshDbSize.Tick += new System.EventHandler(this.timerRefreshDbSize_Tick);
            // 
            // panel3
            // 
            this.panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel3.Controls.Add(this.labelLastBlockdate);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 99);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(3);
            this.panel3.Size = new System.Drawing.Size(276, 34);
            this.panel3.TabIndex = 6;
            // 
            // labelLastBlockdate
            // 
            this.labelLastBlockdate.AutoSize = true;
            this.labelLastBlockdate.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelLastBlockdate.Location = new System.Drawing.Point(165, 3);
            this.labelLastBlockdate.Name = "labelLastBlockdate";
            this.labelLastBlockdate.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.labelLastBlockdate.Size = new System.Drawing.Size(22, 15);
            this.labelLastBlockdate.TabIndex = 1;
            this.labelLastBlockdate.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(3, 3);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.label6.Size = new System.Drawing.Size(162, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Last downloaded Blockdate:";
            // 
            // BottomStatusControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelRowDbSize);
            this.Controls.Add(this.panelRowStatus);
            this.Controls.Add(this.toolStripCommands);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "BottomStatusControl";
            this.Size = new System.Drawing.Size(276, 139);
            this.Load += new System.EventHandler(this.BottomStatusControl_Load);
            this.panelRowStatus.ResumeLayout(false);
            this.panelRowStatus.PerformLayout();
            this.panelRowDbSize.ResumeLayout(false);
            this.panelRowDbSize.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStripCommands.ResumeLayout(false);
            this.toolStripCommands.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Panel panelRowStatus;
        private Label textStatus;
        private Panel panelRowDbSize;
        private Label textDbSize;
        private Label label3;
        private Panel panel2;
        private Label textBlocksCount;
        private Label labelBlocksCount;
        private Panel panel1;
        private Label textTransactionsCount;
        private Label labelTransactionCount;
        private System.Windows.Forms.Timer timerRefresh;
        private ToolStrip toolStripCommands;
        private ToolStripLabel toolStripLabel1;
        private ToolStripButton buttonStart;
        private ToolStripButton buttonStop;
        private System.Windows.Forms.Timer timerRefreshDbSize;
        private Label label4;
        private Label textDbBlocksCount;
        private Label label5;
        private Label textDbTransactionsCount;
        private Panel panel3;
        private Label labelLastBlockdate;
        private Label label6;
    }
}
