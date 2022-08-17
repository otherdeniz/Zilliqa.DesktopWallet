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
            this.labelBlocksCount = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textTransactionsCount = new System.Windows.Forms.Label();
            this.labelTransactionCount = new System.Windows.Forms.Label();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.buttonStart = new System.Windows.Forms.ToolStripButton();
            this.buttonStop = new System.Windows.Forms.ToolStripButton();
            this.panelRowStatus.SuspendLayout();
            this.panelRowDbSize.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.label1.Size = new System.Drawing.Size(52, 15);
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
            this.panelRowStatus.Size = new System.Drawing.Size(276, 22);
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
            this.panelRowDbSize.Location = new System.Drawing.Point(0, 45);
            this.panelRowDbSize.Name = "panelRowDbSize";
            this.panelRowDbSize.Padding = new System.Windows.Forms.Padding(3);
            this.panelRowDbSize.Size = new System.Drawing.Size(276, 22);
            this.panelRowDbSize.TabIndex = 2;
            // 
            // textDbSize
            // 
            this.textDbSize.AutoSize = true;
            this.textDbSize.Dock = System.Windows.Forms.DockStyle.Left;
            this.textDbSize.Location = new System.Drawing.Point(92, 3);
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
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.label3.Size = new System.Drawing.Size(89, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Local DB Size:";
            // 
            // panel2
            // 
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.Controls.Add(this.textBlocksCount);
            this.panel2.Controls.Add(this.labelBlocksCount);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 67);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3);
            this.panel2.Size = new System.Drawing.Size(276, 22);
            this.panel2.TabIndex = 3;
            // 
            // textBlocksCount
            // 
            this.textBlocksCount.AutoSize = true;
            this.textBlocksCount.Dock = System.Windows.Forms.DockStyle.Left;
            this.textBlocksCount.Location = new System.Drawing.Point(118, 3);
            this.textBlocksCount.Name = "textBlocksCount";
            this.textBlocksCount.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.textBlocksCount.Size = new System.Drawing.Size(26, 15);
            this.textBlocksCount.TabIndex = 1;
            this.textBlocksCount.Text = "...";
            // 
            // labelBlocksCount
            // 
            this.labelBlocksCount.AutoSize = true;
            this.labelBlocksCount.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelBlocksCount.Location = new System.Drawing.Point(3, 3);
            this.labelBlocksCount.Name = "labelBlocksCount";
            this.labelBlocksCount.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.labelBlocksCount.Size = new System.Drawing.Size(115, 15);
            this.labelBlocksCount.TabIndex = 0;
            this.labelBlocksCount.Text = "Number of Blocks:";
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.textTransactionsCount);
            this.panel1.Controls.Add(this.labelTransactionCount);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 89);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3);
            this.panel1.Size = new System.Drawing.Size(276, 22);
            this.panel1.TabIndex = 4;
            // 
            // textTransactionsCount
            // 
            this.textTransactionsCount.AutoSize = true;
            this.textTransactionsCount.Dock = System.Windows.Forms.DockStyle.Left;
            this.textTransactionsCount.Location = new System.Drawing.Point(149, 3);
            this.textTransactionsCount.Name = "textTransactionsCount";
            this.textTransactionsCount.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.textTransactionsCount.Size = new System.Drawing.Size(26, 15);
            this.textTransactionsCount.TabIndex = 1;
            this.textTransactionsCount.Text = "...";
            // 
            // labelTransactionCount
            // 
            this.labelTransactionCount.AutoSize = true;
            this.labelTransactionCount.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelTransactionCount.Location = new System.Drawing.Point(3, 3);
            this.labelTransactionCount.Name = "labelTransactionCount";
            this.labelTransactionCount.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.labelTransactionCount.Size = new System.Drawing.Size(146, 15);
            this.labelTransactionCount.TabIndex = 0;
            this.labelTransactionCount.Text = "Number of Transactions:";
            // 
            // timerRefresh
            // 
            this.timerRefresh.Interval = 2500;
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.buttonStart,
            this.buttonStop});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(276, 23);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
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
            // BottomStatusControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelRowDbSize);
            this.Controls.Add(this.panelRowStatus);
            this.Controls.Add(this.toolStrip1);
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
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
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
        private ToolStrip toolStrip1;
        private ToolStripLabel toolStripLabel1;
        private ToolStripButton buttonStart;
        private ToolStripButton buttonStop;
    }
}
