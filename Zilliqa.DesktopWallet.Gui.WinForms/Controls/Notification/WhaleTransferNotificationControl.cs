using Zilliqa.DesktopWallet.Core.Data.Files;
using Zilliqa.DesktopWallet.Core.Repository;
using Zilliqa.DesktopWallet.Core.ViewModel;
using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Notification
{
    public partial class WhaleTransferNotificationControl : NotificationBaseControl
    {
        private ZilTransactionRowViewModel? _transactionViewModel;

        public WhaleTransferNotificationControl()
        {
            InitializeComponent();
        }

        public void LoadData(ZilTransactionRowViewModel transaction)
        {
            _transactionViewModel = transaction;
            labelFrom.Text = new AddressValue(transaction.ThisAddress).ToString();
            labelTo.Text = transaction.OtherAddress!.ToString();
            var isWithdraw = CryptometaFile.Instance.Ecosystems.Any(e =>
                e.Addresses?.Any(a => a == transaction.ThisAddress.GetBech32()) == true);
            labelTitle.Text = isWithdraw ? "Whale withdraw" : "Whale transfer";
            labelAmount.Text = $"{transaction.Amount:#,##0.0###} ZIL";
            labelValue.Text =
                $"{(transaction.Amount * RepositoryManager.Instance.CoingeckoRepository.ZilCoinPrice?.MarketData.CurrentPrice.Usd ?? 0):#,##0.00} $";
            CreatedTimestamp = transaction.Transaction.Timestamp;
            RefreshTimeInfo();
        }

        protected override void ClickAction()
        {
            if (_transactionViewModel != null)
            {
                SecondForm.ShowDetailsAsForm(ControlFactory.CreateDisplayControl(_transactionViewModel));
            }
        }

    }
}
