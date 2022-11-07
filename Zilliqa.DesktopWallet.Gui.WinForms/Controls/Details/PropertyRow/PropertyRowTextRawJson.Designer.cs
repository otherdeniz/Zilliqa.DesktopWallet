namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Details.PropertyRow
{
    partial class PropertyRowTextRawJson
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PropertyRowTextRawJson));
            this.textValue = new System.Windows.Forms.TextBox();
            this.panelValue = new System.Windows.Forms.Panel();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.toolTipButton = new System.Windows.Forms.ToolTip(this.components);
            this.panelValue.SuspendLayout();
            this.SuspendLayout();
            // 
            // textValue
            // 
            this.textValue.BackColor = System.Drawing.Color.White;
            this.textValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textValue.Location = new System.Drawing.Point(4, 4);
            this.textValue.Name = "textValue";
            this.textValue.ReadOnly = true;
            this.textValue.Size = new System.Drawing.Size(321, 16);
            this.textValue.TabIndex = 1;
            this.textValue.TabStop = false;
            // 
            // panelValue
            // 
            this.panelValue.Controls.Add(this.textValue);
            this.panelValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelValue.Location = new System.Drawing.Point(103, 0);
            this.panelValue.Name = "panelValue";
            this.panelValue.Padding = new System.Windows.Forms.Padding(4);
            this.panelValue.Size = new System.Drawing.Size(329, 24);
            this.panelValue.TabIndex = 2;
            // 
            // buttonOpen
            // 
            this.buttonOpen.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonOpen.Image = ((System.Drawing.Image)(resources.GetObject("buttonOpen.Image")));
            this.buttonOpen.Location = new System.Drawing.Point(432, 0);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(24, 24);
            this.buttonOpen.TabIndex = 11;
            this.toolTipButton.SetToolTip(this.buttonOpen, "Show raw JSON data");
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
            // PropertyRowTextRawJson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelValue);
            this.Controls.Add(this.buttonOpen);
            this.Name = "PropertyRowTextRawJson";
            this.Controls.SetChildIndex(this.buttonOpen, 0);
            this.Controls.SetChildIndex(this.panelValue, 0);
            this.panelValue.ResumeLayout(false);
            this.panelValue.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textValue;
        private Panel panelValue;
        private Button buttonOpen;
        private ToolTip toolTipButton;
    }
}
