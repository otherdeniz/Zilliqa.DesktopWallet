using System.Collections.ObjectModel;
using Zilligraph.Database.Storage;
using Zilligraph.Database.Storage.FilterQuery;
using Zilliqa.DesktopWallet.ApiClient;
using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.Repository;
using Zilliqa.DesktopWallet.Core.Services;
using Zilliqa.DesktopWallet.DatabaseSchema;

namespace Zilliqa.DesktopWallet.Core.ViewModel
{
    public class AccountViewModel
    {
        private readonly Action<AccountViewModel> _afterChangedAction;
        private ZilligraphTableEventNotificator<Transaction>? _transactionEventNotificator;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        public AccountViewModel(AccountBase accountData, Action<AccountViewModel> afterChangedAction) 
        {
            AccountData = accountData;
            TokenBalances = new ObservableCollection<AccountTokenBalanceRowViewModel>();
            TokenTransactions = new ObservableCollection<AccountTokenTransactionRowViewModel>();
            ZilTransactions = new ObservableCollection<AccountZilTransactionRowViewModel>();
            _afterChangedAction = afterChangedAction;
            InitialiseData(_cancellationTokenSource.Token);
        }

        public Address Address => AccountData.Address;

        public string AddressBech32 => AccountData.GetAddressBech32();

        public string AddressHex => AccountData.GetAddressHex();

        public AccountBase AccountData { get; }

        public ObservableCollection<AccountZilTransactionRowViewModel> ZilTransactions { get; }

        public ObservableCollection<AccountTokenTransactionRowViewModel> TokenTransactions { get; }

        public ObservableCollection<AccountTokenBalanceRowViewModel> TokenBalances { get; }

        public decimal ZilValueUsd => 0;

        public decimal TokensValueUsd => TokenBalances.Any() ? TokenBalances.Sum(t => t.ValueUsd) : 0;

        public decimal TokensValueZil => TokenBalances.Any() ? TokenBalances.Sum(t => t.ValueZil) : 0;

        public decimal TotalValueUsd => TokensValueUsd;

        public void RaiseAfterChanged()
        {
            _afterChangedAction(this);
        }

        public void CancelBackgroundTasks()
        {
            _cancellationTokenSource.Cancel();
            if (_transactionEventNotificator != null)
            {
                var tableTransactions = RepositoryManager.Instance.DatabaseRepository.Database.GetTable<Transaction>();
                tableTransactions.RemoveEventNotificator(_transactionEventNotificator);
            }
        }

        private void InitialiseData(CancellationToken cancellationToken)
        {
            var tableTransactions = RepositoryManager.Instance.DatabaseRepository.Database.GetTable<Transaction>();
            var addressHex = Address.GetBase16(false);
            var transactionsFilter = new FilterCombination
            {
                Method = FilterQueryCombinationMethod.Or,
                Queries = new List<IFilterQuery>
                {
                    new FilterQueryField("SenderAddress", addressHex),
                    new FilterQueryField("ToAddress", addressHex),
                    new FilterQueryField("TokenTransferSender", addressHex),
                    new FilterQueryField("TokenTransferRecipient", addressHex)
                }
            };
            Task.Run(() =>
            {
                var addressTransactions = tableTransactions.FindRecords(transactionsFilter);
                foreach (var transaction in addressTransactions)
                {
                    if (cancellationToken.IsCancellationRequested)
                    {
                        return;
                    }

                    OnAddedRecord(transaction);
                }

                if (!cancellationToken.IsCancellationRequested)
                {
                    _transactionEventNotificator = tableTransactions.AddEventNotificator(record =>
                            record.SenderAddress == addressHex
                            || record.ToAddress == addressHex
                            || record.TokenTransferSender() == addressHex
                            || record.TokenTransferRecipient() == addressHex,
                        OnAddedRecord);
                }
            }, cancellationToken);
        }

        private void OnAddedRecord(Transaction record)
        {
            if (record.TransactionTypeEnum == TransactionType.Payment)
            {
                ZilTransactions.Add(new AccountZilTransactionRowViewModel(this, record));
            }
            else if (record.TransactionTypeEnum == TransactionType.ContractCall)
            {
                var tokenModel = TokenDataService.Instance.FindTokenByAddress(record.ToAddress);
                if (tokenModel != null)
                {
                    var tokenTransaction = new AccountTokenTransactionRowViewModel(this, record, tokenModel);
                    TokenTransactions.Add(tokenTransaction);
                    var tokenBalance = TokenBalances.FirstOrDefault(t => t.Symbol == tokenModel.Symbol);
                    if (tokenBalance == null)
                    {
                        tokenBalance = new AccountTokenBalanceRowViewModel(tokenModel);
                        TokenBalances.Add(tokenBalance);
                    }

                    tokenBalance.Transactions += 1;
                    if (tokenTransaction.Direction == TransactionDirection.ReceiveFrom)
                    {
                        tokenBalance.Balance += tokenTransaction.Amount;
                    }
                    else
                    {
                        tokenBalance.Balance -= tokenTransaction.Amount;
                    }
                }
            }

            RaiseAfterChanged();
        }
    }
}
