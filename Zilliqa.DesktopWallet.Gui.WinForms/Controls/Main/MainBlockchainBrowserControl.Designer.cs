namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Main
{
    partial class MainBlockchainBrowserControl
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
            _viewModel?.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelCenter = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.propertyGridBlockchainInfo = new System.Windows.Forms.PropertyGrid();
            this.panelCenter.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCenter
            // 
            this.panelCenter.Controls.Add(this.splitter1);
            this.panelCenter.Controls.Add(this.groupBox1);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(0, 0);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(830, 587);
            this.panelCenter.TabIndex = 2;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(625, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(5, 587);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
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
            // MainBlockchainBrowserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelCenter);
            this.Name = "MainBlockchainBrowserControl";
            this.Size = new System.Drawing.Size(830, 587);
            this.panelCenter.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelCenter;
        private Splitter splitter1;
        private GroupBox groupBox1;
        private PropertyGrid propertyGridBlockchainInfo;
    }
}
