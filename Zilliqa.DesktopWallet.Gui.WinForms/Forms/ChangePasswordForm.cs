using Zilliqa.DesktopWallet.Core.Cryptography;
using Zilliqa.DesktopWallet.Core.Data.Files;
using Zilliqa.DesktopWallet.Core.ViewModel;
using Zilliqa.DesktopWallet.Gui.WinForms.Properties;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    public partial class ChangePasswordForm : DialogBaseForm
    {
        public ChangePasswordForm()
        {
            InitializeComponent();
        }

        public static bool Execute(Form parentForm)
        {
            using (var form = new ChangePasswordForm())
            {
                try
                {
                    if (form.ShowDialog(parentForm) == DialogResult.OK)
                    {
                        return true;
                    }
                }
                catch (Exception)
                {
                    // app closed
                }
            }

            return false;
        }

        protected override bool OnOk()
        {
            if (!EncryptionUtils.ValidatePasswordHash(textOldPassword.Text, WalletDat.Instance.PasswordHash))
            {
                MessageBox.Show(Resources.EnterPasswordForm_WrongPassword_Text, Resources.EnterPasswordForm_WrongPassword_Title,
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textOldPassword.Text = "";
                return false;
            }

            if (textNewPassword1.Text.Length < WalletDat.MinPasswordLength)
            {
                MessageBox.Show($"The new password must have at least {WalletDat.MinPasswordLength} characters", ApplicationInfo.ApplicationName,
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (textNewPassword1.Text != textNewPassword2.Text)
            {
                MessageBox.Show("The new password was not repeated correctly", ApplicationInfo.ApplicationName,
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            WalletDat.Instance.SetPassword(new PasswordInfo(textNewPassword1.Text));
            WalletDat.Instance.Save();

            return true;
        }

    }
}
