using System.ComponentModel;
using Zilligraph.Database.Storage;
using Zilligraph.Database.Storage.FilterQuery;
using Zilliqa.DesktopWallet.ApiClient;
using Zilliqa.DesktopWallet.ApiClient.Enums;
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
        private readonly CancellationTokenSource _cancellationTokenSource = new();
        private decimal? _zilLiquidBalance;
        private decimal? _zilValueUsd;
        private decimal? _tokensValueUsd;
        private decimal? _tokensValueZil;

        public AccountViewModel(AccountBase accountData, Action<AccountViewModel> afterChangedAction) 
        {
            AccountData = accountData;
            TokenBalances = new BindingList<TokenBalanceRowViewModel>();
            TokenTransactions = new BindingList<TokenTransactionRowViewModel>();
            ZilTransactions = new BindingList<ZilTransactionRowViewModel>();
            _afterChangedAction = afterChangedAction;
            InitialiseData(_cancellationTokenSource.Token);
        }

        public Address Address => AccountData.Address;

        public string AddressBech32 => AccountData.GetAddressBech32();

        public string AddressHex => AccountData.GetAddressHex();

        public AccountBase AccountData { get; }

        public BindingList<ZilTransactionRowViewModel> ZilTransactions { get; }

        public BindingList<TokenTransactionRowViewModel> TokenTransactions { get; }

        public BindingList<TokenBalanceRowViewModel> TokenBalances { get; }

        public decimal ZilLiquidBalance => _zilLiquidBalance ??= GetZilLiquidBalance();

        public decimal ZilTotalBalance => ZilLiquidBalance; // + Staked Balance + Liquidity Pools Balances

        public decimal? ZilTotalValueUsd => _zilValueUsd;
        //{
        //    get
        //    {
        //        if (_zilValueUsd == null)
        //        {
        //            try
        //            {
        //                var coinHistory = RepositoryManager.Instance.CoingeckoRepository.GetCoinHistory(DateTime.Today, "ZIL", ch =>
        //                {
        //                    _zilValueUsd = ch.MarketData.CurrentPrice.Usd * ZilTotalBalance;
        //                    OnPropertyChanged();
        //                });
        //                if (coinHistory != null)
        //                {
        //                    _zilValueUsd = coinHistory.MarketData.CurrentPrice.Usd * ZilTotalBalance;
        //                }
        //            }
        //            catch (Exception e)
        //            {
        //                Logging.LogError("get_ZilTotalValueUsd failed", e);
        //            }
        //        }
        //        return _zilValueUsd;
        //    }
        //}

        public decimal TokensValueUsd => _tokensValueUsd ??= TokenBalances.Any() ? TokenBalances.Sum(t => t.ValueUsd) : 0;

        public decimal TokensValueZil => _tokensValueZil ??= TokenBalances.Any() ? TokenBalances.Sum(t => t.ValueZil) : 0;

        public decimal TotalValueUsd => ZilTotalValueUsd.GetValueOrDefault() + TokensValueUsd;

        private void OnTransactionsChanged()
        {
            _zilLiquidBalance = null;
            _tokensValueUsd = null;
            _tokensValueZil = null;
            WinFormsSynchronisationContext.ExecuteSynchronized(() =>
            {
                _afterChangedAction(this);
            });
        }

        private void OnPropertyChanged()
        {
            WinFormsSynchronisationContext.ExecuteSynchronized(() =>
            {
                _afterChangedAction(this);
            });
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

        private decimal GetZilLiquidBalance()
        {
            Task.Run(async () =>
            {
                for (int i = 1; i <= 3; i++)
                {
                    try
                    {
                        _zilLiquidBalance = (await ZilliqaClient.DefaultInstance.GetBalance(Address))?.GetBalance(Unit.ZIL);
                        _zilValueUsd = null;
                        OnPropertyChanged();
                        return;
                    }
                    catch (Exception e)
                    {
                        Logging.LogError($"GetZilLiquidBalance({Address.GetBech32()}) failed", e);
                    }
                    // retry after a few seconds
                    await Task.Delay(Random.Shared.Next(1000, 2000) * i);
                }
            });
            return 0m;
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
                try
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
                }
                catch (TaskCanceledException)
                {
                    // expected
                }
                catch (Exception e)
                {
                    Logging.LogError("Account View Model InitialiseData failed", e);
                }
            }, cancellationToken);
        }

        private void OnAddedRecord(Transaction record)
        {
            try
            {
                if (record.TransactionTypeEnum == TransactionType.Payment)
                {
                    if (ZilTransactions.LastOrDefault()?.Transaction.Timestamp > record.Timestamp)
                    {
                        // add to end
                        ZilTransactions.Add(new ZilTransactionRowViewModel(Address, record));
                    }
                    else
                    {
                        // add to beginning
                        ZilTransactions.Insert(0, new ZilTransactionRowViewModel(Address, record));
                    }
                }
                else if (record.TransactionTypeEnum == TransactionType.ContractCall)
                {
                    var tokenModel = TokenDataService.Instance.FindTokenByAddress(record.ToAddress);
                    if (tokenModel != null)
                    {
                        var tokenTransaction = new TokenTransactionRowViewModel(Address, record, tokenModel);
                        if (TokenTransactions.LastOrDefault()?.Transaction.Timestamp > record.Timestamp)
                        {
                            // add to end
                            TokenTransactions.Add(tokenTransaction);
                        }
                        else
                        {
                            // add to beginning
                            TokenTransactions.Insert(0, tokenTransaction);
                        }
                        var tokenBalance = TokenBalances.FirstOrDefault(t => t.Symbol == tokenModel.Symbol);
                        if (tokenBalance == null)
                        {
                            tokenBalance = new TokenBalanceRowViewModel(tokenModel);
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

                OnTransactionsChanged();
            }
            catch (Exception e)
            {
                Logging.LogError("Account View Model OnAddedRecord failed.", e, record);
            }
        }
    }
}
