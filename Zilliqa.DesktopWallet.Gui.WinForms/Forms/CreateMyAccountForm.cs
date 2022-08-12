using Zilliqa.DesktopWallet.Core.Cryptography;
using Zilliqa.DesktopWallet.Core.Data.Files;
using Zilliqa.DesktopWallet.Core.ViewModel;
using Zilliqa.DesktopWallet.Gui.WinForms.Properties;
using Zilliqa.DesktopWallet.Gui.WinForms.ViewModel;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    public partial class CreateMyAccountForm : DialogBaseForm
    {
        public CreateMyAccountForm()
        {
            InitializeComponent();
        }

        public string AccountName { get; private set; } = string.Empty;

        public string Password { get; private set; } = string.Empty;

        public static CreateAccountResult? Execute(Form parentForm)
        {
            using (var form = new CreateMyAccountForm())
            {
                if (form.ShowDialog(parentForm) == DialogResult.OK)
                {
                    return new CreateAccountResult
                    {
                        Password = new PasswordInfo(form.Password),
                        AccountName = form.AccountName
                    };
                }
            }

            return null;
        }

        protected override bool OnOk()
        {
            if (CheckFields(true))
            {
                AccountName = textWalletName.Text;
                Password = textPassword1.Text;

                return true;
            }
            return false;
        }

        private bool CheckFields(bool validatePassword)
        {
            if (validatePassword &&
                !EncryptionUtils.ValidatePasswordHash(textPassword1.Text, WalletDat.Instance.PasswordHash))
            {
                MessageBox.Show(Resources.EnterPasswordForm_WrongPassword_Text, Resources.EnterPasswordForm_WrongPassword_Title,
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return false;
            }

            var ok = textWalletName.Text.Length >= 1
                     && textPassword1.Text.Length >= 1;
            buttonOk.Enabled = ok;
            return ok;
        }

        private void textWalletName_TextChanged(object sender, EventArgs e)
        {
            CheckFields(false);
        }

        private void textPassword1_TextChanged(object sender, EventArgs e)
        {
            CheckFields(false);
        }
    }
}
