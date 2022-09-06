using Zilliqa.DesktopWallet.Gui.WinForms.Controls.Values;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Details
{
    partial class TransactionDetailsControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransactionDetailsControl));
            this.groupBoxDetails = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelId = new Zilliqa.DesktopWallet.Gui.WinForms.Controls.Values.DrillDownLinkLabel();
            this.labelBlockNumber = new Zilliqa.DesktopWallet.Gui.WinForms.Controls.Values.DrillDownLinkLabel();
            this.labelDate = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuId = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuIdCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.menuIdBlockExplorer = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.propertyGridModel = new System.Windows.Forms.PropertyGrid();
            this.groupBoxDetails.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.contextMenuId.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.groupBoxDetails.Size = new System.Drawing.Size(509, 83);
            this.groupBoxDetails.TabIndex = 1;
            this.groupBoxDetails.TabStop = false;
            this.groupBoxDetails.Text = "Overview";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelId);
            this.panel2.Controls.Add(this.labelBlockNumber);
            this.panel2.Controls.Add(this.labelDate);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel2.Location = new System.Drawing.Point(95, 19);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(411, 61);
            this.panel2.TabIndex = 3;
            // 
            // labelId
            // 
            this.labelId.ActiveLinkColor = System.Drawing.Color.DarkBlue;
            this.labelId.AutoSize = true;
            this.labelId.LinkColor = System.Drawing.Color.DarkBlue;
            this.labelId.Location = new System.Drawing.Point(6, 0);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(13, 15);
            this.labelId.TabIndex = 5;
            this.labelId.TabStop = true;
            this.labelId.Text = "1";
            this.labelId.VisitedLinkColor = System.Drawing.Color.DarkBlue;
            this.labelId.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.labelId_LinkClicked);
            // 
            // labelBlockNumber
            // 
            this.labelBlockNumber.ActiveLinkColor = System.Drawing.Color.DarkBlue;
            this.labelBlockNumber.AutoSize = true;
            this.labelBlockNumber.LinkColor = System.Drawing.Color.DarkBlue;
            this.labelBlockNumber.Location = new System.Drawing.Point(6, 34);
            this.labelBlockNumber.Name = "labelBlockNumber";
            this.labelBlockNumber.Size = new System.Drawing.Size(13, 15);
            this.labelBlockNumber.TabIndex = 4;
            this.labelBlockNumber.TabStop = true;
            this.labelBlockNumber.Text = "1";
            this.labelBlockNumber.VisitedLinkColor = System.Drawing.Color.DarkBlue;
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(6, 17);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(91, 15);
            this.labelDate.TabIndex = 1;
            this.labelDate.Text = "01.01.1900 00:00";
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel1.Location = new System.Drawing.Point(3, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(92, 61);
            this.panel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Block Number:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Date:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Transaction Id:";
            // 
            // contextMenuId
            // 
            this.contextMenuId.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuIdCopy,
            this.menuIdBlockExplorer});
            this.contextMenuId.Name = "contextMenuId";
            this.contextMenuId.Size = new System.Drawing.Size(195, 48);
            // 
            // menuIdCopy
            // 
            this.menuIdCopy.Image = ((System.Drawing.Image)(resources.GetObject("menuIdCopy.Image")));
            this.menuIdCopy.Name = "menuIdCopy";
            this.menuIdCopy.Size = new System.Drawing.Size(194, 22);
            this.menuIdCopy.Text = "Copy to Clipboard";
            this.menuIdCopy.Click += new System.EventHandler(this.menuIdCopy_Click);
            // 
            // menuIdBlockExplorer
            // 
            this.menuIdBlockExplorer.Image = ((System.Drawing.Image)(resources.GetObject("menuIdBlockExplorer.Image")));
            this.menuIdBlockExplorer.Name = "menuIdBlockExplorer";
            this.menuIdBlockExplorer.Size = new System.Drawing.Size(194, 22);
            this.menuIdBlockExplorer.Text = "Open in Block Explorer";
            this.menuIdBlockExplorer.Click += new System.EventHandler(this.menuIdBlockExplorer_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.propertyGridModel);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(0, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(509, 439);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Transaction Details";
            // 
            // propertyGridModel
            // 
            this.propertyGridModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridModel.HelpVisible = false;
            this.propertyGridModel.Location = new System.Drawing.Point(3, 19);
            this.propertyGridModel.Name = "propertyGridModel";
            this.propertyGridModel.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.propertyGridModel.Size = new System.Drawing.Size(503, 417);
            this.propertyGridModel.TabIndex = 1;
            this.propertyGridModel.ToolbarVisible = false;
            // 
            // TransactionDetailsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxDetails);
            this.Name = "TransactionDetailsControl";
            this.Size = new System.Drawing.Size(509, 522);
            this.groupBoxDetails.ResumeLayout(false);
            this.groupBoxDetails.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.contextMenuId.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBoxDetails;
        private Panel panel2;
        private Label labelDate;
        private Panel panel1;
        private Label label2;
        private Label label3;
        private Label label1;
        private DrillDownLinkLabel labelBlockNumber;
        private DrillDownLinkLabel labelId;
        private ContextMenuStrip contextMenuId;
        private ToolStripMenuItem menuIdCopy;
        private ToolStripMenuItem menuIdBlockExplorer;
        private GroupBox groupBox1;
        private PropertyGrid propertyGridModel;
    }
}
