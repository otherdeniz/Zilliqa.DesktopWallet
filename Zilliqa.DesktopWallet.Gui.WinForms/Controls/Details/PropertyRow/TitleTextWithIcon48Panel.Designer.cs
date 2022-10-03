namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Details.PropertyRow
{
    partial class TitleTextWithIcon48Panel
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
            this.labelDescription = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // labelDescription
            // 
            this.labelDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDescription.BackColor = System.Drawing.Color.White;
            this.labelDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.labelDescription.Enabled = false;
            this.labelDescription.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelDescription.Location = new System.Drawing.Point(57, 27);
            this.labelDescription.Multiline = true;
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.ReadOnly = true;
            this.labelDescription.Size = new System.Drawing.Size(587, 36);
            this.labelDescription.TabIndex = 10;
            this.labelDescription.Text = "...";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelName.Location = new System.Drawing.Point(57, 3);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(16, 21);
            this.labelName.TabIndex = 9;
            this.labelName.Text = "-";
            // 
            // pictureBoxIcon
            // 
            this.pictureBoxIcon.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxIcon.Name = "pictureBoxIcon";
            this.pictureBoxIcon.Size = new System.Drawing.Size(48, 48);
            this.pictureBoxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxIcon.TabIndex = 8;
            this.pictureBoxIcon.TabStop = false;
            // 
            // TitleTextWithIcon48Panel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.pictureBoxIcon);
            this.Name = "TitleTextWithIcon48Panel";
            this.Size = new System.Drawing.Size(647, 70);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox labelDescription;
        private Label labelName;
        private PictureBox pictureBoxIcon;
    }
}
