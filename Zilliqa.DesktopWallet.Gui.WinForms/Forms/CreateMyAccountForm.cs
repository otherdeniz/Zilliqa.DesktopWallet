using Zilliqa.DesktopWallet.ApiClient.Utils;
using Zilliqa.DesktopWallet.Core.ViewModel;
using Zilliqa.DesktopWallet.Gui.WinForms.Controls.Wallet;
using Zilliqa.DesktopWallet.Gui.WinForms.ViewModel;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    public partial class CreateMyAccountForm : DialogWithPasswordBaseForm
    {
        public CreateMyAccountForm()
        {
            InitializeComponent();
        }

        public string AccountName { get; private set; } = string.Empty;

        public static CreateAccountResult? Execute(Form parentForm)
        {
            using (var form = new CreateMyAccountForm())
            {
                if (form.ShowDialog(parentForm) == DialogResult.OK)
                {
                    return new CreateAccountResult
                    {
                        Password = new PasswordInfo(form.Password),
                        AccountName = form.AccountName,
                        AddWalletType = form.addAccountControl.AddType,
                        PrivateKey = form.addAccountControl.PrivateKey,
                        LedgerAddressBech32 = form.addAccountControl.LedgerAddressBech32
                    };
                }
            }

            return null;
        }

        protected override bool OnOk()
        {
            if (base.OnOk())
            {
                if (addAccountControl.AddType == AddAccountControl.AddWalletType.ImportPrivateKey
                    && !CryptoUtil.IsPrivateKeyValid(addAccountControl.PrivateKey))
                {
                    MessageBox.Show("Invalid Private Key", "The Private Key is not valid",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return false;
                }

                AccountName = addAccountControl.Title;

                return true;
            }
            return false;
        }

        protected override bool CheckFields()
        {
            return base.CheckFields()
                   && addAccountControl.CheckFields();
        }

        private void addAccountControl1_ValueChanged(object sender, EventArgs e)
        {
            RefreshOkButton();
        }
    }
}
