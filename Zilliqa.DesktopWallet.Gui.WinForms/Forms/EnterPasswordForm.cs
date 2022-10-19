using Zilliqa.DesktopWallet.Core.Cryptography;
using Zilliqa.DesktopWallet.Core.Data.Files;
using Zilliqa.DesktopWallet.Core.ViewModel;
using Zilliqa.DesktopWallet.Gui.WinForms.Properties;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    public partial class EnterPasswordForm : DialogBaseForm
    {
        public EnterPasswordForm()
        {
            InitializeComponent();
        }

        public string Password { get; private set; } = string.Empty;

        public static PasswordInfo? Execute(Form parentForm)
        {
            using (var form = new EnterPasswordForm())
            {
                if (form.ShowDialog(parentForm) == DialogResult.OK)
                {
                    return new PasswordInfo(form.Password);
                }
            }

            return null;
        }

        protected override bool OnOk()
        {
            if (EncryptionUtils.ValidatePasswordHash(textPassword1.Text, WalletDat.Instance.PasswordHash))
            {
                Password = textPassword1.Text;
                return true;
            }

            MessageBox.Show(Resources.EnterPasswordForm_WrongPassword_Text, Resources.EnterPasswordForm_WrongPassword_Title,
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            textPassword1.Text = "";
            return false;
        }
    }
}
