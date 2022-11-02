using Zilligraph.Database.Storage;
using Zilliqa.DesktopWallet.ApiClient;
using Zilliqa.DesktopWallet.Core.Data.Files;
using Zilliqa.DesktopWallet.Core.Extensions;
using Zilliqa.DesktopWallet.Core.Repository;
using Zilliqa.DesktopWallet.Core.ViewModel;
using Zilliqa.DesktopWallet.DatabaseSchema;

namespace Zilliqa.DesktopWallet.Core.Services
{
    public class NotificationService
    {
        public static NotificationService Instance { get; } = new();
        private NotificationService()
        {
        }

        private readonly List<ZilligraphTableEventNotificator<Transaction>> _transactionEventNotificators = new();
        public event EventHandler<IncominZilTransactionEventArgs>? IncomingZilTransaction;
        public event EventHandler<IncominTokenTransactionEventArgs>? IncomingTokenTransaction;
        public event EventHandler<WhaleTransactionEventArgs>? WhaleTransaction;


        public void RegisterEventNotificators()
        {
            var walletRepo = RepositoryManager.Instance.WalletRepository;
            var tableTransaction = RepositoryManager.Instance.DatabaseRepository.Database.GetTable<Transaction>();
            // incoming ZIL transaction
            _transactionEventNotificators.Add(tableTransaction.AddEventNotificator(t =>
                    !t.TransactionFailed
                    && t.TransactionTypeEnum == TransactionType.Payment
                    && walletRepo.FindAccount(t.ToAddress) != null
                , t =>
                {
                    var account = walletRepo.FindAccount(t.ToAddress)!;
                    IncomingZilTransaction?.Invoke(this, 
                        new IncominZilTransactionEventArgs(account, new ZilTransactionRowViewModel(account.Address, t)));
                }
            ));
            // incoming Token transaction
            _transactionEventNotificators.Add(tableTransaction.AddEventNotificator(t =>
                    !t.TransactionFailed
                    && t.TransactionTypeEnum == TransactionType.ContractCall
                    && walletRepo.FindAccount(t.TokenTransferRecipient()) != null
                , t =>
                {
                    var tokenModel = TokenDataService.Instance.FindTokenByAddress(t.ToAddress);
                    if (tokenModel != null)
                    {
                        var account = walletRepo.FindAccount(t.TokenTransferRecipient())!;
                        IncomingTokenTransaction?.Invoke(this,
                            new IncominTokenTransactionEventArgs(account, new TokenTransactionRowViewModel(account.Address, t, tokenModel)));
                    }
                }
            ));
            // Whale transactions
            _transactionEventNotificators.Add(tableTransaction.AddEventNotificator(t =>
                {
                    if (SettingsFile.Instance.WhaleNotificationUsd == 0
                        || t.TransactionFailed
                        || t.TransactionTypeEnum != TransactionType.Payment) return false;
                    var currentZilPrice = RepositoryManager.Instance.CoingeckoRepository.ZilCoinPrice?.MarketData
                        .CurrentPrice.Usd;
                    if (currentZilPrice == null) return false;
                    return t.Amount.ZilSatoshisToZil() * currentZilPrice >= SettingsFile.Instance.WhaleNotificationUsd
                           && walletRepo.FindAccount(t.SenderAddress) == null
                           && walletRepo.FindAccount(t.ToAddress) == null;
                }
                , t =>
                {
                    WhaleTransaction?.Invoke(this,
                        new WhaleTransactionEventArgs(new ZilTransactionRowViewModel(new Address(t.SenderAddress), t)));
                }
            ));
        }

        public void UnregisterEventNotificators()
        {
            var tableTransaction = RepositoryManager.Instance.DatabaseRepository.Database.GetTable<Transaction>();
            foreach (var eventNotificator in _transactionEventNotificators)
            {
                tableTransaction.RemoveEventNotificator(eventNotificator);
            }
            _transactionEventNotificators.Clear();
        }

        public class IncominZilTransactionEventArgs : EventArgs
        {
            public IncominZilTransactionEventArgs(AccountViewModel accountViewModel, ZilTransactionRowViewModel transactionViewModel)
            {
                AccountViewModel = accountViewModel;
                TransactionViewModel = transactionViewModel;
            }

            public AccountViewModel AccountViewModel { get; }
            public ZilTransactionRowViewModel TransactionViewModel { get; }
        }

        public class IncominTokenTransactionEventArgs : EventArgs
        {
            public IncominTokenTransactionEventArgs(AccountViewModel accountViewModel, TokenTransactionRowViewModel transactionViewModel)
            {
                AccountViewModel = accountViewModel;
                TransactionViewModel = transactionViewModel;
            }

            public AccountViewModel AccountViewModel { get; }
            public TokenTransactionRowViewModel TransactionViewModel { get; }
        }

        public class WhaleTransactionEventArgs : EventArgs
        {
            public WhaleTransactionEventArgs(ZilTransactionRowViewModel transactionViewModel)
            {
                TransactionViewModel = transactionViewModel;
            }

            public ZilTransactionRowViewModel TransactionViewModel { get; }
        }

    }
}
