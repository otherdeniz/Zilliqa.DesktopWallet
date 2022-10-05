namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Details.PropertyRow
{
    partial class PropertyRowBlockNumber
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PropertyRowBlockNumber));
            this.labelNumber = new System.Windows.Forms.Label();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.toolTipButton = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.Padding = new System.Windows.Forms.Padding(4, 4, 0, 4);
            this.labelName.Size = new System.Drawing.Size(96, 23);
            // 
            // labelNumber
            // 
            this.labelNumber.AutoSize = true;
            this.labelNumber.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelNumber.Location = new System.Drawing.Point(99, 0);
            this.labelNumber.Margin = new System.Windows.Forms.Padding(0);
            this.labelNumber.Name = "labelNumber";
            this.labelNumber.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.labelNumber.Size = new System.Drawing.Size(13, 19);
            this.labelNumber.TabIndex = 1;
            this.labelNumber.Text = "0";
            // 
            // buttonOpen
            // 
            this.buttonOpen.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonOpen.Image = ((System.Drawing.Image)(resources.GetObject("buttonOpen.Image")));
            this.buttonOpen.Location = new System.Drawing.Point(112, 0);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(24, 24);
            this.buttonOpen.TabIndex = 9;
            this.toolTipButton.SetToolTip(this.buttonOpen, "Open");
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // toolTipButton
            // 
            this.toolTipButton.AutomaticDelay = 50;
            this.toolTipButton.AutoPopDelay = 5000;
            this.toolTipButton.InitialDelay = 50;
            this.toolTipButton.ReshowDelay = 10;
            this.toolTipButton.UseAnimation = false;
            this.toolTipButton.UseFading = false;
            // 
            // PropertyRowBlockNumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.labelNumber);
            this.Name = "PropertyRowBlockNumber";
            this.Size = new System.Drawing.Size(456, 24);
            this.Controls.SetChildIndex(this.labelNumber, 0);
            this.Controls.SetChildIndex(this.buttonOpen, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelNumber;
        private Button buttonOpen;
        private ToolTip toolTipButton;
    }
}
