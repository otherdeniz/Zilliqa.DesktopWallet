using Zillifriends.Shared.Common;
using Zilliqa.DesktopWallet.Core.Repository;
using Zilliqa.DesktopWallet.Core.ViewModel;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Notification
{
    public partial class IncomingTokenNotificationControl : NotificationBaseControl
    {
        private TokenTransactionRowViewModel? _transactionViewModel;

        public IncomingTokenNotificationControl()
        {
            InitializeComponent();
        }

        public void LoadData(AccountViewModel accountViewModel, TokenTransactionRowViewModel transaction)
        {
            _transactionViewModel = transaction;
            pictureImage.Image = transaction.LogoIcon;
            labelTitle.Text = $"Incoming {transaction.Token.Symbol.TokenSymbolShort()} Transfer";
            labelAccount.Text = accountViewModel.AccountData.Name;
            labelSender.Text = transaction.OtherAddress?.ToString();
            labelAmount.Text = transaction.AmountDisplay;
            labelValueTitle.Visible = false;
            labelValue.Visible = false;
            //labelValue.Text =
            //    $"{(transaction.Amount * RepositoryManager.Instance.CoingeckoRepository.ZilCoinPrice?.MarketData.CurrentPrice.Usd ?? 0):#,##0.00} $";
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
