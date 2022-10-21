namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Values.Arguments
{
    partial class ArgumentEditBaseControl
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
            this.panelLeft = new System.Windows.Forms.Panel();
            this.labelName = new System.Windows.Forms.Label();
            this.panelType = new System.Windows.Forms.Panel();
            this.labelType = new System.Windows.Forms.Label();
            this.pictureCheck = new System.Windows.Forms.PictureBox();
            this.panelLeft.SuspendLayout();
            this.panelType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCheck)).BeginInit();
            this.SuspendLayout();
            // 
            // panelLeft
            // 
            this.panelLeft.AutoSize = true;
            this.panelLeft.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelLeft.Controls.Add(this.labelName);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(112, 24);
            this.panelLeft.TabIndex = 1;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(0, 0);
            this.labelName.Name = "labelName";
            this.labelName.Padding = new System.Windows.Forms.Padding(4);
            this.labelName.Size = new System.Drawing.Size(109, 23);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "[ArgumentName]";
            // 
            // panelType
            // 
            this.panelType.AutoSize = true;
            this.panelType.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelType.Controls.Add(this.labelType);
            this.panelType.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelType.Location = new System.Drawing.Point(112, 0);
            this.panelType.Name = "panelType";
            this.panelType.Size = new System.Drawing.Size(50, 24);
            this.panelType.TabIndex = 2;
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Location = new System.Drawing.Point(0, 0);
            this.labelType.Name = "labelType";
            this.labelType.Padding = new System.Windows.Forms.Padding(4);
            this.labelType.Size = new System.Drawing.Size(47, 23);
            this.labelType.TabIndex = 1;
            this.labelType.Text = "[Type]";
            // 
            // pictureCheck
            // 
            this.pictureCheck.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureCheck.Location = new System.Drawing.Point(462, 0);
            this.pictureCheck.Name = "pictureCheck";
            this.pictureCheck.Size = new System.Drawing.Size(24, 24);
            this.pictureCheck.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureCheck.TabIndex = 3;
            this.pictureCheck.TabStop = false;
            // 
            // ArgumentEditBaseControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureCheck);
            this.Controls.Add(this.panelType);
            this.Controls.Add(this.panelLeft);
            this.Name = "ArgumentEditBaseControl";
            this.Size = new System.Drawing.Size(486, 24);
            this.Load += new System.EventHandler(this.ArgumentEditBaseControl_Load);
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            this.panelType.ResumeLayout(false);
            this.panelType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCheck)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panelLeft;
        protected Label labelName;
        private Panel panelType;
        protected Label labelType;
        private PictureBox pictureCheck;
    }
}
