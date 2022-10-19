namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    partial class StakingClaimForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.checkedListBoxSsn = new System.Windows.Forms.CheckedListBox();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(454, 6);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(562, 6);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 15);
            this.label2.TabIndex = 103;
            this.label2.Text = "Stake Nodes to claim rewards";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.checkedListBoxSsn);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(8, 8);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(668, 161);
            this.panel4.TabIndex = 0;
            // 
            // checkedListBoxSsn
            // 
            this.checkedListBoxSsn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBoxSsn.BackColor = System.Drawing.SystemColors.Control;
            this.checkedListBoxSsn.CheckOnClick = true;
            this.checkedListBoxSsn.FormattingEnabled = true;
            this.checkedListBoxSsn.Location = new System.Drawing.Point(3, 22);
            this.checkedListBoxSsn.Name = "checkedListBoxSsn";
            this.checkedListBoxSsn.Size = new System.Drawing.Size(659, 130);
            this.checkedListBoxSsn.TabIndex = 104;
            this.checkedListBoxSsn.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxSsn_ItemCheck);
            // 
            // StakingClaimForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 298);
            this.Controls.Add(this.panel4);
            this.DisplaySenderAccount = false;
            this.Name = "StakingClaimForm";
            this.Text = "Claim Pending Stake Rewards";
            this.Load += new System.EventHandler(this.StakingClaimForm_Load);
            this.Controls.SetChildIndex(this.panel4, 0);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Label label2;
        private Panel panel4;
        private CheckedListBox checkedListBoxSsn;
    }
}