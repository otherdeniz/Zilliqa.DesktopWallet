using Zilliqa.DesktopWallet.Core.Cryptography;
using Zilliqa.DesktopWallet.Core.Data.Files;
using Zilliqa.DesktopWallet.Gui.WinForms.Properties;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    public partial class DialogWithPasswordBaseForm : DialogBaseForm
    {
        public DialogWithPasswordBaseForm()
        {
            InitializeComponent();
        }

        public string Password { get; private set; } = string.Empty;

        protected override bool OnOk()
        {
            if (!EncryptionUtils.ValidatePasswordHash(textPassword1.Text, WalletDat.Instance.PasswordHash))
            {
                MessageBox.Show(Resources.EnterPasswordForm_WrongPassword_Text, Resources.EnterPasswordForm_WrongPassword_Title,
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return false;
            }

            if (CheckFields())
            {
                Password = textPassword1.Text;
                return true;
            }

            return false;
        }

        protected virtual bool CheckFields()
        {
            return textPassword1.Text.Length >= WalletDat.MinPasswordLength;
        }

        protected void RefreshOkButton()
        {
            buttonOk.Enabled = CheckFields();
        }

        private void textPassword1_TextChanged(object sender, EventArgs e)
        {
            RefreshOkButton();
        }
    }
}
