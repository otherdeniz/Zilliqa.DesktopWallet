namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    partial class DisplayRawJsonForm
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
            this.components = new System.ComponentModel.Container();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.buttonClose = new System.Windows.Forms.Button();
            this.rawTextBox = new Alsing.Windows.Forms.SyntaxBoxControl();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.buttonClose);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(8, 350);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(585, 34);
            this.panelBottom.TabIndex = 1;
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonClose.Location = new System.Drawing.Point(233, 3);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(119, 27);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // rawTextBox
            // 
            this.rawTextBox.ActiveView = Alsing.Windows.Forms.ActiveView.BottomRight;
            this.rawTextBox.AutoListPosition = null;
            this.rawTextBox.AutoListSelectedText = "a123";
            this.rawTextBox.AutoListVisible = false;
            this.rawTextBox.BackColor = System.Drawing.Color.White;
            this.rawTextBox.BorderStyle = Alsing.Windows.Forms.BorderStyle.None;
            this.rawTextBox.CopyAsRTF = false;
            this.rawTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rawTextBox.FontName = "Courier new";
            this.rawTextBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rawTextBox.InfoTipCount = 1;
            this.rawTextBox.InfoTipPosition = null;
            this.rawTextBox.InfoTipSelectedIndex = 1;
            this.rawTextBox.InfoTipVisible = false;
            this.rawTextBox.Location = new System.Drawing.Point(8, 8);
            this.rawTextBox.LockCursorUpdate = false;
            this.rawTextBox.Name = "rawTextBox";
            this.rawTextBox.ShowScopeIndicator = false;
            this.rawTextBox.Size = new System.Drawing.Size(585, 342);
            this.rawTextBox.SmoothScroll = false;
            this.rawTextBox.SplitviewH = -4;
            this.rawTextBox.SplitviewV = -4;
            this.rawTextBox.TabGuideColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.rawTextBox.TabIndex = 0;
            this.rawTextBox.Text = "syntaxBoxControl1";
            this.rawTextBox.WhitespaceColor = System.Drawing.SystemColors.ControlDark;
            // 
            // DisplayRawJsonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 392);
            this.Controls.Add(this.rawTextBox);
            this.Controls.Add(this.panelBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "DisplayRawJsonForm";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Raw JSON data";
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelBottom;
        private Button buttonClose;
        private Alsing.Windows.Forms.SyntaxBoxControl rawTextBox;
    }
}