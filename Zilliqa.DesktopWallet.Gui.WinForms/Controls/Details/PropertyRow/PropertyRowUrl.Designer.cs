namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Details.PropertyRow
{
    partial class PropertyRowUrl
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
            this.linkLabelUrl = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.Padding = new System.Windows.Forms.Padding(4);
            this.labelName.Size = new System.Drawing.Size(100, 23);
            // 
            // linkLabelUrl
            // 
            this.linkLabelUrl.Dock = System.Windows.Forms.DockStyle.Top;
            this.linkLabelUrl.Location = new System.Drawing.Point(103, 0);
            this.linkLabelUrl.Name = "linkLabelUrl";
            this.linkLabelUrl.Padding = new System.Windows.Forms.Padding(0, 2, 4, 4);
            this.linkLabelUrl.Size = new System.Drawing.Size(353, 22);
            this.linkLabelUrl.TabIndex = 4;
            this.linkLabelUrl.TabStop = true;
            this.linkLabelUrl.Text = "none";
            this.linkLabelUrl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelUrl_LinkClicked);
            // 
            // PropertyRowUrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.linkLabelUrl);
            this.Name = "PropertyRowUrl";
            this.Size = new System.Drawing.Size(456, 24);
            this.Controls.SetChildIndex(this.linkLabelUrl, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LinkLabel linkLabelUrl;
    }
}
