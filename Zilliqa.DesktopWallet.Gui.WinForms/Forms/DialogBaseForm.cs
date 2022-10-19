namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    public partial class DialogBaseForm : Form
    {
        public DialogBaseForm()
        {
            InitializeComponent();
        }

        protected virtual bool OnCancel()
        {
            return true;
        }

        protected virtual bool OnOk()
        {
            return true;
        }

        protected virtual void ExecuteResult()
        {
            this.DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (OnCancel())
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (OnOk())
            {
                buttonOk.Enabled = false;
                buttonOk.Refresh();
                buttonCancel.Enabled = false;
                buttonCancel.Refresh();
                ExecuteResult();
                this.Close();
            }
        }
    }
}
