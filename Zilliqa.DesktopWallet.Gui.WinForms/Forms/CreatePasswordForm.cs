using Zilliqa.DesktopWallet.Core.ViewModel;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    public partial class CreatePasswordForm : DialogBaseForm
    {
        public CreatePasswordForm()
        {
            InitializeComponent();
        }

        public string Password { get; private set; } = string.Empty;

        public static PasswordGuiViewModel? Execute(Form parentForm)
        {
            using (var form = new CreatePasswordForm())
            {
                if (form.ShowDialog(parentForm) == DialogResult.OK)
                {
                    return new PasswordGuiViewModel(form.Password);
                }
            }

            return null;
        }

        protected override bool OnCancel()
        {
            if (MessageBox.Show("If you cancel, the application will exit.", "Exit application?",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                Application.Exit();
            }

            return false;
        }

        protected override bool OnOk()
        {
            if (CheckPassword())
            {
                Password = textPassword1.Text;
            }
            return true;
        }

        private bool CheckPassword()
        {
            var nameOk = textWalletName.Text.Length >= 1;
            var passwordOk = textPassword1.Text.Length >= 12 
                               && textPassword1.Text == textPassword2.Text;
            buttonOk.Enabled = passwordOk && nameOk;
            return passwordOk;
        }

        private void textPassword1_TextChanged(object sender, EventArgs e)
        {
            CheckPassword();
        }

        private void textPassword2_TextChanged(object sender, EventArgs e)
        {
            CheckPassword();
        }

        private void textWalletName_TextChanged(object sender, EventArgs e)
        {
            CheckPassword();
        }
    }
}
