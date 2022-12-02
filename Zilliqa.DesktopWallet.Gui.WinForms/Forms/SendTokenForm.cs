using System.Globalization;
using Zillifriends.Shared.Common;
using Zilliqa.DesktopWallet.Core;
using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.Extensions;
using Zilliqa.DesktopWallet.Core.Repository;
using Zilliqa.DesktopWallet.Core.Services;
using Zilliqa.DesktopWallet.Core.ViewModel;
using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    public partial class SendTokenForm : DialogWithPasswordBaseForm
    {
        public static void ExecuteShow(Form parentForm, AccountViewModel account)
        {
            var form = new SendTokenForm();
            form.LoadSenderAccounts(account.AccountData as MyAccount);
            form.Show(parentForm);
        }

        private List<TokenBalanceRowViewModel>? _accountTokens;

        public SendTokenForm()
        {
            InitializeComponent();
        }

        public TokenModelByAddress TokenModelByAddress { get; private set; } = null!;

        public string ToAddress { get; private set; } = string.Empty;

        public decimal Amount { get; private set; }

        protected override void ExecuteResult()
        {
            var sendResult = SendTransactionService.Instance.SendTokenToAddress(
                SenderAccount!.GetSenderAccount(),
                new AddressValue(ToAddress),
                TokenModelByAddress,
                Amount);
            TransactionSendResultForm.ExecuteShow(this.Owner, sendResult);
        }

        protected override bool OnOk()
        {
            if (base.OnOk())
            {
                TokenModelByAddress = GetSelectedToken()!.Model;
                ToAddress = addressTextBox.Address!.Address.GetBech32();
                Amount = decimal.Parse(textAmount.Text);
                return true;
            }
            return false;
        }

        protected override bool CheckFields()
        {
            return base.CheckFields()
                && GetSelectedToken() != null
                && addressTextBox.Address != null
                && decimal.TryParse(textAmount.Text, out var amountValue)
                && amountValue > 0;
        }

        private TokenBalanceRowViewModel? GetSelectedToken()
        {
            if (comboBoxToken.SelectedIndex > -1)
            {
                return _accountTokens?[comboBoxToken.SelectedIndex];
            }
            return null;
        }

        protected override void AccountSelected(AccountViewModel selectedAccount)
        {
            _accountTokens = selectedAccount.TokenBalances.Where(tb => tb.Balance > 0).ToList();
            comboBoxToken.Items.Clear();
            foreach (var tokenBalance in _accountTokens)
            {
                comboBoxToken.Items.Add($"{tokenBalance.TokenTitle}  -  {tokenBalance.BalanceDisplay}");
            }
        }

        private void SendTokenForm_Load(object sender, EventArgs e)
        {
            textGasPrice.Text = RepositoryManager.Instance.BlockchainBrowserRepository.MinimumGasPrice
                .ZilSatoshisToZil().ToString(CultureInfo.CurrentCulture);
        }

        private void comboBoxToken_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedToken = GetSelectedToken();
            if (selectedToken == null)
            {
                labelSymbol1.Text = "";
                labelSymbol2.Text = "";
                textAvailableFunds.Text = "";
                buttonSendMax.Enabled = false;
            }
            else
            {
                var symbol = selectedToken.Model.TokenModel.Symbol.TokenSymbolShort();
                labelSymbol1.Text = symbol;
                labelSymbol2.Text = symbol;
                textAvailableFunds.Text = selectedToken.Balance.ToString("#,##0.############");
                buttonSendMax.Enabled = true;
                Task.Run(() =>
                {
                    var dbRepo = RepositoryManager.Instance.DatabaseRepository;
                    var lastTransferTransaction = dbRepo.GetLatestContractCallTransaction(
                        new AddressValue(selectedToken.Model.ContractAddressBech32), "Transfer");
                    var transferGasLimit = lastTransferTransaction?.Receipt.CumulativeGas ??
                                        SendTransactionService.GasLimitDefaultTokenTransfer;
                    var transferFee = RepositoryManager.Instance.BlockchainBrowserRepository.MinimumGasPrice *
                                      transferGasLimit;
                    WinFormsSynchronisationContext.ExecuteSynchronized(() =>
                    {
                        textFee.Text = transferFee.ZilSatoshisToZil().ToString(CultureInfo.CurrentCulture);
                    });
                });
            }
            RefreshOkButton();
        }

        private void buttonSendMax_Click(object sender, EventArgs e)
        {
            var selectedToken = GetSelectedToken();
            if (selectedToken != null)
            {
                textAmount.Text = selectedToken.Balance.ToString(CultureInfo.CurrentCulture);
            }
        }

        private void addressTextBox_AddressChanged(object sender, EventArgs e)
        {
            RefreshOkButton();
        }

        private void textAmount_TextChanged(object sender, EventArgs e)
        {
            RefreshOkButton();
        }

    }
}
