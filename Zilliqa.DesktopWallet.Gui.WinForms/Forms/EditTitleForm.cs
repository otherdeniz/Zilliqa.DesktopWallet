namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    public partial class EditTitleForm : DialogBaseForm
    {
        public static string? ExecuteEdit(Form parentForm, string title)
        {
            using (var form = new EditTitleForm())
            {
                form.textWalletName.Text = title;
                if (form.ShowDialog(parentForm) == DialogResult.OK)
                {
                    return form.textWalletName.Text;
                }
            }
            return null;
        }

        public EditTitleForm()
        {
            InitializeComponent();
        }

        private void textWalletName_TextChanged(object sender, EventArgs e)
        {
            buttonOk.Enabled = !string.IsNullOrEmpty(textWalletName.Text);
        }
    }
}
