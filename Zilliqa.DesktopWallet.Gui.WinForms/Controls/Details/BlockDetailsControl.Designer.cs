namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Details
{
    partial class BlockDetailsControl
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
            this.groupBoxDetails = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelDate = new System.Windows.Forms.Label();
            this.labelNumber = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxTransactions = new System.Windows.Forms.GroupBox();
            this.gridViewTransactions = new Zilliqa.DesktopWallet.Gui.WinForms.Controls.GridView.GridViewControl();
            this.groupBoxDetails.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBoxTransactions.SuspendLayout();
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
            this.groupBoxDetails.Size = new System.Drawing.Size(386, 60);
            this.groupBoxDetails.TabIndex = 0;
            this.groupBoxDetails.TabStop = false;
            this.groupBoxDetails.Text = "Block Details";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelDate);
            this.panel2.Controls.Add(this.labelNumber);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel2.Location = new System.Drawing.Point(63, 19);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(320, 38);
            this.panel2.TabIndex = 3;
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
            // labelNumber
            // 
            this.labelNumber.AutoSize = true;
            this.labelNumber.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelNumber.Location = new System.Drawing.Point(6, 0);
            this.labelNumber.Name = "labelNumber";
            this.labelNumber.Size = new System.Drawing.Size(15, 17);
            this.labelNumber.TabIndex = 1;
            this.labelNumber.Text = "1";
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel1.Location = new System.Drawing.Point(3, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(60, 38);
            this.panel1.TabIndex = 2;
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
            this.label1.Size = new System.Drawing.Size(54, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number:";
            // 
            // groupBoxTransactions
            // 
            this.groupBoxTransactions.Controls.Add(this.gridViewTransactions);
            this.groupBoxTransactions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxTransactions.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBoxTransactions.Location = new System.Drawing.Point(0, 60);
            this.groupBoxTransactions.Name = "groupBoxTransactions";
            this.groupBoxTransactions.Size = new System.Drawing.Size(386, 364);
            this.groupBoxTransactions.TabIndex = 1;
            this.groupBoxTransactions.TabStop = false;
            this.groupBoxTransactions.Text = "Transactions";
            // 
            // gridViewTransactions
            // 
            this.gridViewTransactions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridViewTransactions.Location = new System.Drawing.Point(3, 19);
            this.gridViewTransactions.Name = "gridViewTransactions";
            this.gridViewTransactions.Size = new System.Drawing.Size(380, 342);
            this.gridViewTransactions.TabIndex = 0;
            // 
            // BlockDetailsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupBoxTransactions);
            this.Controls.Add(this.groupBoxDetails);
            this.Name = "BlockDetailsControl";
            this.Size = new System.Drawing.Size(386, 424);
            this.groupBoxDetails.ResumeLayout(false);
            this.groupBoxDetails.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBoxTransactions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBoxDetails;
        private Panel panel2;
        private Label labelDate;
        private Label labelNumber;
        private Panel panel1;
        private Label label3;
        private Label label1;
        private GroupBox groupBoxTransactions;
        private GridView.GridViewControl gridViewTransactions;
    }
}
