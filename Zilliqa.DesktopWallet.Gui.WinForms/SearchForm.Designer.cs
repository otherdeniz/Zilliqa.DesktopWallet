namespace Zilliqa.DesktopWallet.Gui.WinForms
{
    partial class SearchForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchForm));
            this.mainBlockExplorerControl1 = new Zilliqa.DesktopWallet.Gui.WinForms.Controls.Main.MainBlockExplorerControl();
            this.SuspendLayout();
            // 
            // mainBlockExplorerControl1
            // 
            this.mainBlockExplorerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainBlockExplorerControl1.Location = new System.Drawing.Point(0, 0);
            this.mainBlockExplorerControl1.Name = "mainBlockExplorerControl1";
            this.mainBlockExplorerControl1.Size = new System.Drawing.Size(801, 544);
            this.mainBlockExplorerControl1.TabIndex = 0;
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(801, 544);
            this.Controls.Add(this.mainBlockExplorerControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SearchForm";
            this.Text = "Blockchain Search";
            this.Load += new System.EventHandler(this.SearchForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.Main.MainBlockExplorerControl mainBlockExplorerControl1;
    }
}