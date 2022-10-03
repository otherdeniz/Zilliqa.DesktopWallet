namespace Zilliqa.DesktopWallet.Gui.WinForms
{
    partial class SecondForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SecondForm));
            this.masterPanel = new Zilliqa.DesktopWallet.Gui.WinForms.Controls.Main.MainDynamicMasterPanelControl();
            this.SuspendLayout();
            // 
            // masterPanel
            // 
            this.masterPanel.BackColor = System.Drawing.Color.White;
            this.masterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.masterPanel.Location = new System.Drawing.Point(0, 0);
            this.masterPanel.Name = "masterPanel";
            this.masterPanel.Size = new System.Drawing.Size(810, 528);
            this.masterPanel.TabIndex = 0;
            // 
            // SecondForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 528);
            this.Controls.Add(this.masterPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SecondForm";
            this.Text = "SecondForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SecondForm_FormClosing);
            this.Load += new System.EventHandler(this.SecondForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.Main.MainDynamicMasterPanelControl masterPanel;
    }
}