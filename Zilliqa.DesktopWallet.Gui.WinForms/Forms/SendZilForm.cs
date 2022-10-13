using System.Globalization;
using Zilliqa.DesktopWallet.Core.Cryptography;
using Zilliqa.DesktopWallet.Core.Data.Files;
using Zilliqa.DesktopWallet.Core.Extensions;
using Zilliqa.DesktopWallet.Core.Repository;
using Zilliqa.DesktopWallet.Core.Services;
using Zilliqa.DesktopWallet.Core.ViewModel;
using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;
using Zilliqa.DesktopWallet.Gui.WinForms.Properties;
using Zilliqa.DesktopWallet.Gui.WinForms.ViewModel;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    public partial class SendZilForm : DialogBaseForm
    {
        private AccountViewModel _account = null!;

        public SendZilForm()
        {
            InitializeComponent();
        }

        public string ToAddress { get; private set; } = string.Empty;

        public decimal Amount { get; private set; }

        public string Password { get; private set; } = string.Empty;

        public static SendZilResult? Execute(Form parentForm, AccountViewModel account)
        {
            using (var form = new SendZilForm())
            {
                form._account = account;
                if (form.ShowDialog(parentForm) == DialogResult.OK)
                {
                    return new SendZilResult()
                    {
                        Password = new PasswordInfo(form.Password),
                        ToAddress = new AddressValue(form.ToAddress),
                        Amount = form.Amount
                    };
                }
            }

            return null;
        }

        protected override bool OnOk()
        {
            if (CheckFields(true))
            {
                ToAddress = textToAddress.Text;
                Password = textPassword1.Text;
                Amount = decimal.Parse(textAmount.Text);
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

            var ok = AddressValue.TryParse(textToAddress.Text, out _)
                     && decimal.TryParse(textAmount.Text, out _)
                     && textPassword1.Text.Length >= 1;
            buttonOk.Enabled = ok;
            return ok;
        }

        private void SendZilForm_Load(object sender, EventArgs e)
        {
            textGasPrice.Text = RepositoryManager.Instance.BlockchainBrowserRepository.MinimumGasPrice
                .ToString("#,##0", CultureInfo.CurrentCulture);
            var currentFee = RepositoryManager.Instance.BlockchainBrowserRepository.MinimumGasPrice *
                          SendTransactionService.GasLimitZilTransfer;
            textFee.Text = currentFee.ZilSatoshisToZil().ToString(CultureInfo.CurrentCulture);
            textAvailableFunds.Text = _account.ZilLiquidBalance.ToString("#,##0.0000", CultureInfo.CurrentCulture);
        }

        private void textToAddress_TextChanged(object sender, EventArgs e)
        {
            CheckFields(false);
        }

        private void textAmount_TextChanged(object sender, EventArgs e)
        {
            CheckFields(false);
        }

        private void textPassword1_TextChanged(object sender, EventArgs e)
        {
            CheckFields(false);
        }

        private void buttonSendMax_Click(object sender, EventArgs e)
        {
            var currentFee = RepositoryManager.Instance.BlockchainBrowserRepository.MinimumGasPrice *
                             SendTransactionService.GasLimitZilTransfer;
            textAmount.Text = (_account.ZilLiquidBalance - currentFee.ZilSatoshisToZil())
                .ToString(CultureInfo.CurrentCulture);
        }
    }
}
