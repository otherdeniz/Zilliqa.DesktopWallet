using System.ComponentModel;
using Zilliqa.DesktopWallet.Core.Cryptography;
using Zilliqa.DesktopWallet.Core.Data.Files;
using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.Repository;
using Zilliqa.DesktopWallet.Core.ViewModel;
using Zilliqa.DesktopWallet.Gui.WinForms.Properties;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    public partial class DialogWithPasswordBaseForm : DialogBaseForm
    {
        private List<AccountViewModel> _myAccoutViewModels = new();
        private bool _displaySenderAccount = true;

        public DialogWithPasswordBaseForm()
        {
            InitializeComponent();
        }

        [DefaultValue(null)]
        [Browsable(false)]
        public MyAccount? SenderAccount { get; private set; }

        [DefaultValue("")]
        [Browsable(false)]
        public string Password { get; private set; } = string.Empty;

        protected AccountViewModel? SelectedAccountViewModel { get; private set; }

        [DefaultValue(true)]
        public bool DisplaySenderAccount
        {
            get => _displaySenderAccount;
            set
            {
                _displaySenderAccount = value;
                panelSenderAccount.Visible = value;
            }
        }

        protected void LoadSenderAccounts(MyAccount? selectedAccount = null)
        {
            _myAccoutViewModels = RepositoryManager.Instance.WalletRepository.MyAccounts.ToList();
            foreach (var myAccount in _myAccoutViewModels)
            {
                comboBoxSenderAccount.Items.Add(
                    $"{myAccount.AccountData.Name}  -  Liquid funds: {myAccount.ZilLiquidBalance:#,##0.00} ZIL");
                if (myAccount.AddressBech32 == selectedAccount?.GetAddressBech32())
                {
                    comboBoxSenderAccount.SelectedIndex = comboBoxSenderAccount.Items.Count - 1;
                }
            }
        }

        protected override bool OnOk()
        {
            if (!EncryptionUtils.ValidatePasswordHash(textPassword.Text, WalletDat.Instance.PasswordHash))
            {
                MessageBox.Show(Resources.EnterPasswordForm_WrongPassword_Text, Resources.EnterPasswordForm_WrongPassword_Title,
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return false;
            }

            if (CheckFields())
            {
                SenderAccount = _displaySenderAccount
                    ? (MyAccount)_myAccoutViewModels[comboBoxSenderAccount.SelectedIndex].AccountData
                    : null;
                Password = textPassword.Text;
                return true;
            }

            return false;
        }

        protected virtual bool CheckFields()
        {
            return (!_displaySenderAccount || comboBoxSenderAccount.SelectedIndex > -1)
                   && textPassword.Text.Length >= WalletDat.MinPasswordLength;
        }

        protected virtual void AccountSelected(AccountViewModel selectedAccount)
        {
        }

        protected void RefreshOkButton()
        {
            buttonOk.Enabled = CheckFields();
        }

        private void textPassword1_TextChanged(object sender, EventArgs e)
        {
            RefreshOkButton();
            var passwordEmpty = string.IsNullOrEmpty(textPassword.Text);
            var passwordOk = EncryptionUtils.ValidatePasswordHash(textPassword.Text, WalletDat.Instance.PasswordHash);
            labelPasswortHint.Visible = passwordEmpty;
            labelPasswordIncorrect.Visible = !passwordEmpty && !passwordOk;
            labelPasswordOk.Visible = !passwordEmpty && passwordOk;
        }

        private void comboBoxSenderAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSenderAccount.SelectedIndex > -1)
            {
                var accountVm = _myAccoutViewModels[comboBoxSenderAccount.SelectedIndex];
                SelectedAccountViewModel = accountVm;
                AccountSelected(accountVm);
            }
            RefreshOkButton();
        }
    }
}
