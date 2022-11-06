namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Main
{
    partial class BottomZilPriceControl
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
            this.pictureSparkline = new System.Windows.Forms.PictureBox();
            this.panelRowPrice = new System.Windows.Forms.Panel();
            this.textPrice = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textMarketCap = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.textRank = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSparkline)).BeginInit();
            this.panelRowPrice.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureSparkline
            // 
            this.pictureSparkline.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pictureSparkline.Location = new System.Drawing.Point(0, 89);
            this.pictureSparkline.Name = "pictureSparkline";
            this.pictureSparkline.Size = new System.Drawing.Size(142, 50);
            this.pictureSparkline.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureSparkline.TabIndex = 0;
            this.pictureSparkline.TabStop = false;
            // 
            // panelRowPrice
            // 
            this.panelRowPrice.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelRowPrice.Controls.Add(this.textPrice);
            this.panelRowPrice.Controls.Add(this.label1);
            this.panelRowPrice.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelRowPrice.Location = new System.Drawing.Point(0, 0);
            this.panelRowPrice.Name = "panelRowPrice";
            this.panelRowPrice.Padding = new System.Windows.Forms.Padding(3);
            this.panelRowPrice.Size = new System.Drawing.Size(142, 20);
            this.panelRowPrice.TabIndex = 2;
            // 
            // textPrice
            // 
            this.textPrice.AutoSize = true;
            this.textPrice.Dock = System.Windows.Forms.DockStyle.Left;
            this.textPrice.Location = new System.Drawing.Point(39, 3);
            this.textPrice.Name = "textPrice";
            this.textPrice.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.textPrice.Size = new System.Drawing.Size(22, 15);
            this.textPrice.TabIndex = 1;
            this.textPrice.Text = "-";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.label1.Size = new System.Drawing.Size(36, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Price:";
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.textMarketCap);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 20);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3);
            this.panel1.Size = new System.Drawing.Size(142, 20);
            this.panel1.TabIndex = 3;
            // 
            // textMarketCap
            // 
            this.textMarketCap.AutoSize = true;
            this.textMarketCap.Dock = System.Windows.Forms.DockStyle.Left;
            this.textMarketCap.Location = new System.Drawing.Point(46, 3);
            this.textMarketCap.Name = "textMarketCap";
            this.textMarketCap.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.textMarketCap.Size = new System.Drawing.Size(22, 15);
            this.textMarketCap.TabIndex = 1;
            this.textMarketCap.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.label3.Size = new System.Drawing.Size(43, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "M.Cap:";
            // 
            // timerRefresh
            // 
            this.timerRefresh.Interval = 1000;
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // panel2
            // 
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.Controls.Add(this.textRank);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 40);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3);
            this.panel2.Size = new System.Drawing.Size(142, 20);
            this.panel2.TabIndex = 4;
            // 
            // textRank
            // 
            this.textRank.AutoSize = true;
            this.textRank.Dock = System.Windows.Forms.DockStyle.Left;
            this.textRank.Location = new System.Drawing.Point(39, 3);
            this.textRank.Name = "textRank";
            this.textRank.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.textRank.Size = new System.Drawing.Size(22, 15);
            this.textRank.TabIndex = 1;
            this.textRank.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(3, 3);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.label4.Size = new System.Drawing.Size(36, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "Rank:";
            // 
            // BottomZilPriceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pictureSparkline);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelRowPrice);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "BottomZilPriceControl";
            this.Size = new System.Drawing.Size(142, 139);
            this.Load += new System.EventHandler(this.BottomZilPriceControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureSparkline)).EndInit();
            this.panelRowPrice.ResumeLayout(false);
            this.panelRowPrice.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox pictureSparkline;
        private Panel panelRowPrice;
        private Label textPrice;
        private Label label1;
        private Panel panel1;
        private Label textMarketCap;
        private Label label3;
        private System.Windows.Forms.Timer timerRefresh;
        private Panel panel2;
        private Label textRank;
        private Label label4;
    }
}
