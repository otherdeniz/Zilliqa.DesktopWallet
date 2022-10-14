namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Values
{
    partial class ContractFieldsControl
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
            this.groupConstructorArguments = new System.Windows.Forms.GroupBox();
            this.groupStateFields = new System.Windows.Forms.GroupBox();
            this.groupMethods = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // groupConstructorArguments
            // 
            this.groupConstructorArguments.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupConstructorArguments.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupConstructorArguments.Location = new System.Drawing.Point(0, 0);
            this.groupConstructorArguments.Name = "groupConstructorArguments";
            this.groupConstructorArguments.Size = new System.Drawing.Size(377, 78);
            this.groupConstructorArguments.TabIndex = 0;
            this.groupConstructorArguments.TabStop = false;
            this.groupConstructorArguments.Text = "Deployed Constructor Arguments";
            // 
            // groupStateFields
            // 
            this.groupStateFields.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupStateFields.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupStateFields.Location = new System.Drawing.Point(0, 78);
            this.groupStateFields.Name = "groupStateFields";
            this.groupStateFields.Size = new System.Drawing.Size(377, 78);
            this.groupStateFields.TabIndex = 1;
            this.groupStateFields.TabStop = false;
            this.groupStateFields.Text = "Contract State Fields";
            // 
            // groupMethods
            // 
            this.groupMethods.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupMethods.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupMethods.Location = new System.Drawing.Point(0, 156);
            this.groupMethods.Name = "groupMethods";
            this.groupMethods.Size = new System.Drawing.Size(377, 95);
            this.groupMethods.TabIndex = 2;
            this.groupMethods.TabStop = false;
            this.groupMethods.Text = "Contract Methods";
            // 
            // ContractFieldsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupMethods);
            this.Controls.Add(this.groupStateFields);
            this.Controls.Add(this.groupConstructorArguments);
            this.Name = "ContractFieldsControl";
            this.Size = new System.Drawing.Size(377, 315);
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupConstructorArguments;
        private GroupBox groupStateFields;
        private GroupBox groupMethods;
    }
}
