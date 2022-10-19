namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    partial class ContractCallTransactionForm
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
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(496, 6);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(604, 6);
            // 
            // SendContractCallTransactionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 360);
            this.Name = "SendContractCallTransactionForm";
            this.Text = "Call Smart Contract";
            this.ResumeLayout(false);

        }

        #endregion
    }
}