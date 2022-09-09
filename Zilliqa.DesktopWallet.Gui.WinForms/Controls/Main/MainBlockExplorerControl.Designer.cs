namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Main
{
    partial class MainBlockExplorerControl
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
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelResult = new System.Windows.Forms.Panel();
            this.panelSearchItem = new System.Windows.Forms.Panel();
            this.labelSearchItemTitle = new System.Windows.Forms.Label();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.textSearch = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.panelMain.SuspendLayout();
            this.panelSearchItem.SuspendLayout();
            this.panelSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.panelResult);
            this.panelMain.Controls.Add(this.panelSearchItem);
            this.panelMain.Controls.Add(this.panelSearch);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(486, 587);
            this.panelMain.TabIndex = 12;
            // 
            // panelResult
            // 
            this.panelResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelResult.Location = new System.Drawing.Point(0, 57);
            this.panelResult.Name = "panelResult";
            this.panelResult.Size = new System.Drawing.Size(486, 530);
            this.panelResult.TabIndex = 1;
            // 
            // panelSearchItem
            // 
            this.panelSearchItem.Controls.Add(this.labelSearchItemTitle);
            this.panelSearchItem.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearchItem.Location = new System.Drawing.Point(0, 32);
            this.panelSearchItem.Name = "panelSearchItem";
            this.panelSearchItem.Size = new System.Drawing.Size(486, 25);
            this.panelSearchItem.TabIndex = 2;
            // 
            // labelSearchItemTitle
            // 
            this.labelSearchItemTitle.AutoSize = true;
            this.labelSearchItemTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelSearchItemTitle.Location = new System.Drawing.Point(4, 3);
            this.labelSearchItemTitle.Name = "labelSearchItemTitle";
            this.labelSearchItemTitle.Size = new System.Drawing.Size(167, 15);
            this.labelSearchItemTitle.TabIndex = 0;
            this.labelSearchItemTitle.Text = "Unrecognized Search Term...";
            this.labelSearchItemTitle.Visible = false;
            // 
            // panelSearch
            // 
            this.panelSearch.Controls.Add(this.textSearch);
            this.panelSearch.Controls.Add(this.buttonSearch);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearch.Location = new System.Drawing.Point(0, 0);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Padding = new System.Windows.Forms.Padding(4);
            this.panelSearch.Size = new System.Drawing.Size(486, 32);
            this.panelSearch.TabIndex = 0;
            // 
            // textSearch
            // 
            this.textSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textSearch.Location = new System.Drawing.Point(4, 4);
            this.textSearch.Name = "textSearch";
            this.textSearch.PlaceholderText = "Enter Zil-Address, Block-Number or Transaction-ID";
            this.textSearch.Size = new System.Drawing.Size(390, 23);
            this.textSearch.TabIndex = 0;
            this.textSearch.TextChanged += new System.EventHandler(this.textSearch_TextChanged);
            this.textSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textSearch_KeyDown);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonSearch.Enabled = false;
            this.buttonSearch.Location = new System.Drawing.Point(394, 4);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(88, 24);
            this.buttonSearch.TabIndex = 1;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // MainBlockExplorerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "MainBlockExplorerControl";
            this.Size = new System.Drawing.Size(830, 587);
            this.Load += new System.EventHandler(this.MainBlockchainBrowserControl_Load);
            this.Controls.SetChildIndex(this.panelMain, 0);
            this.panelMain.ResumeLayout(false);
            this.panelSearchItem.ResumeLayout(false);
            this.panelSearchItem.PerformLayout();
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelMain;
        private Panel panelResult;
        private Panel panelSearch;
        private TextBox textSearch;
        private Button buttonSearch;
        private Panel panelSearchItem;
        private Label labelSearchItemTitle;
    }
}
