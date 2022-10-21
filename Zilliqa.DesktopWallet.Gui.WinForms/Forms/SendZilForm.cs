using System.Globalization;
using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.Extensions;
using Zilliqa.DesktopWallet.Core.Repository;
using Zilliqa.DesktopWallet.Core.Services;
using Zilliqa.DesktopWallet.Core.ViewModel;
using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    public partial class SendZilForm : DialogWithPasswordBaseForm
    {
        public static void ExecuteShow(Form parentForm, AccountViewModel account)
        {
            var form = new SendZilForm();
            form.LoadSenderAccounts(account.AccountData as MyAccount);
            form.Show(parentForm);
        }

        private AccountViewModel? _selectedAccount;

        public SendZilForm()
        {
            InitializeComponent();
        }

        public string ToAddress { get; private set; } = string.Empty;

        public decimal Amount { get; private set; }

        protected override void ExecuteResult()
        {
            var sendResult = SendTransactionService.Instance.SendZilToAddress(
                SenderAccount!.AccountDetails,
                new AddressValue(ToAddress),
                Amount);
            TransactionSendResultForm.ExecuteShow(this.Owner, sendResult);
        }

        protected override bool OnOk()
        {
            if (base.OnOk())
            {
                ToAddress = addressTextBox.Address!.Address.GetBech32();
                Amount = decimal.Parse(textAmount.Text);
                return true;
            }
            return false;
        }

        protected override bool CheckFields()
        {
            return base.CheckFields()
                   && addressTextBox.Address != null
                   && decimal.TryParse(textAmount.Text, out var amountValue)
                   && amountValue > 0;
        }

        protected override void AccountSelected(AccountViewModel selectedAccount)
        {
            _selectedAccount = selectedAccount;
            textAvailableFunds.Text = selectedAccount.ZilLiquidBalance.ToString("#,##0.00##########", CultureInfo.CurrentCulture);
        }

        private void SendZilForm_Load(object sender, EventArgs e)
        {
            textGasPrice.Text = RepositoryManager.Instance.BlockchainBrowserRepository.MinimumGasPrice
                .ZilSatoshisToZil().ToString(CultureInfo.CurrentCulture);
            var currentFee = RepositoryManager.Instance.BlockchainBrowserRepository.MinimumGasPrice *
                          SendTransactionService.GasLimitZilTransfer;
            textFee.Text = currentFee.ZilSatoshisToZil().ToString(CultureInfo.CurrentCulture);
        }

        private void textToAddress_TextChanged(object sender, EventArgs e)
        {
            RefreshOkButton();
        }

        private void textAmount_TextChanged(object sender, EventArgs e)
        {
            RefreshOkButton();
        }

        private void addressTextBox_AddressChanged(object sender, EventArgs e)
        {
            RefreshOkButton();
        }

        private void buttonSendMax_Click(object sender, EventArgs e)
        {
            if (_selectedAccount != null)
            {
                var currentFee = RepositoryManager.Instance.BlockchainBrowserRepository.MinimumGasPrice *
                                 SendTransactionService.GasLimitZilTransfer;
                var maxAmount = _selectedAccount.ZilLiquidBalance - currentFee.ZilSatoshisToZil();
                textAmount.Text = maxAmount > 0
                    ? maxAmount.ToString(CultureInfo.CurrentCulture)
                    : "0";
            }
        }

    }
}
