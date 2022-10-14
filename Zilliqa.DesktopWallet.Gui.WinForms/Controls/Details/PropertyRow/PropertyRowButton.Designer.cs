namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Details.PropertyRow
{
    partial class PropertyRowButton
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
            this.panelButtton = new System.Windows.Forms.Panel();
            this.buttonAction = new System.Windows.Forms.Button();
            this.panelButtton.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelButtton
            // 
            this.panelButtton.Controls.Add(this.buttonAction);
            this.panelButtton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelButtton.Location = new System.Drawing.Point(103, 0);
            this.panelButtton.Name = "panelButtton";
            this.panelButtton.Padding = new System.Windows.Forms.Padding(0, 1, 1, 1);
            this.panelButtton.Size = new System.Drawing.Size(353, 24);
            this.panelButtton.TabIndex = 1;
            // 
            // buttonAction
            // 
            this.buttonAction.AutoSize = true;
            this.buttonAction.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonAction.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonAction.Location = new System.Drawing.Point(0, 1);
            this.buttonAction.Name = "buttonAction";
            this.buttonAction.Size = new System.Drawing.Size(53, 22);
            this.buttonAction.TabIndex = 0;
            this.buttonAction.Text = "button";
            this.buttonAction.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAction.UseVisualStyleBackColor = true;
            // 
            // PropertyRowButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelButtton);
            this.Name = "PropertyRowButton";
            this.Controls.SetChildIndex(this.panelButtton, 0);
            this.panelButtton.ResumeLayout(false);
            this.panelButtton.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panelButtton;
        private Button buttonAction;
    }
}
