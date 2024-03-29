﻿using Zilliqa.DesktopWallet.Core.Repository;
using Zilliqa.DesktopWallet.Core.ViewModel;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Notification
{
    public partial class IncomingZilNotificationControl : NotificationBaseControl
    {
        private ZilTransactionRowViewModel? _transactionViewModel;

        public IncomingZilNotificationControl()
        {
            InitializeComponent();
        }

        public void LoadData(AccountViewModel accountViewModel, ZilTransactionRowViewModel transaction)
        {
            _transactionViewModel = transaction;
            labelAccount.Text = accountViewModel.AccountData.Name;
            labelSender.Text = transaction.OtherAddress?.ToString();
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
