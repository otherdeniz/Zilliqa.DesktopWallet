using Zilliqa.DesktopWallet.ApiClient.Utils;
using Zilliqa.DesktopWallet.Core.Data.Files;
using Zilliqa.DesktopWallet.Core.ViewModel;
using Zilliqa.DesktopWallet.Gui.WinForms.Controls.Wallet;
using Zilliqa.DesktopWallet.Gui.WinForms.ViewModel;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    public partial class CreatePasswordForm : DialogBaseForm
    {
        public CreatePasswordForm()
        {
            InitializeComponent();
        }

        public string AccountName { get; private set; } = string.Empty;

        public string Password { get; private set; } = string.Empty;

        public static CreateAccountResult? Execute(Form parentForm)
        {
            using (var form = new CreatePasswordForm())
            {
                try
                {
                    if (form.ShowDialog(parentForm) == DialogResult.OK)
                    {
                        return new CreateAccountResult
                        {
                            Password = new PasswordInfo(form.Password),
                            AccountName = form.AccountName,
                            AddWalletType = form.radioButtonCreateNow.Checked
                                ? form.addAccountControl.AddType
                                : AddAccountControl.AddWalletType.NotSelected,
                            PrivateKey = form.addAccountControl.PrivateKey
                        };
                    }
                }
                catch (Exception)
                {
                    // app closed
                }
            }

            return null;
        }

        protected override bool OnOk()
        {
            if (CheckFields())
            {
                if (radioButtonCreateNow.Checked
                    && addAccountControl.AddType == AddAccountControl.AddWalletType.ImportPrivateKey
                    && !CryptoUtil.IsPrivateKeyValid(addAccountControl.PrivateKey))
                {
                    MessageBox.Show("Invalid Private Key", "The Private Key is not valid",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return false;
                }

                AccountName = addAccountControl.Title;
                Password = textPassword1.Text;
            }
            return true;
        }

        private bool CheckFields()
        {
            var walletOk = radioButtonNotCreate.Checked
                           || addAccountControl.CheckFields();
            var passwordOk = textPassword1.Text.Length >= WalletDat.MinPasswordLength 
                               && textPassword1.Text == textPassword2.Text;
            buttonOk.Enabled = passwordOk && walletOk;
            return passwordOk && walletOk;
        }

        private void textPassword1_TextChanged(object sender, EventArgs e)
        {
            CheckFields();
        }

        private void textPassword2_TextChanged(object sender, EventArgs e)
        {
            CheckFields();
        }

        private void radioButtonCreateNow_CheckedChanged(object sender, EventArgs e)
        {
            addAccountControl.Visible = radioButtonCreateNow.Checked;
            CheckFields();
        }

        private void addAccountControl_ValueChanged(object sender, EventArgs e)
        {
            CheckFields();
        }
    }
}
