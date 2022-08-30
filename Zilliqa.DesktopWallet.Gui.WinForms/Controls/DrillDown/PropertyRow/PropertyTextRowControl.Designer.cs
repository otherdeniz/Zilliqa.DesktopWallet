namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.DrillDown.PropertyRow
{
    partial class PropertyTextRowControl
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
            this.labelProperty = new System.Windows.Forms.Label();
            this.labelValue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelProperty
            // 
            this.labelProperty.AutoSize = true;
            this.labelProperty.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelProperty.Location = new System.Drawing.Point(0, 0);
            this.labelProperty.Name = "labelProperty";
            this.labelProperty.Size = new System.Drawing.Size(55, 15);
            this.labelProperty.TabIndex = 0;
            this.labelProperty.Text = "Property:";
            // 
            // labelValue
            // 
            this.labelValue.AutoSize = true;
            this.labelValue.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelValue.Location = new System.Drawing.Point(55, 0);
            this.labelValue.Name = "labelValue";
            this.labelValue.Size = new System.Drawing.Size(35, 15);
            this.labelValue.TabIndex = 1;
            this.labelValue.Text = "Value";
            // 
            // PropertyTextRowControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.labelValue);
            this.Controls.Add(this.labelProperty);
            this.Name = "PropertyTextRowControl";
            this.Size = new System.Drawing.Size(286, 16);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Label labelProperty;
        public Label labelValue;
    }
}
