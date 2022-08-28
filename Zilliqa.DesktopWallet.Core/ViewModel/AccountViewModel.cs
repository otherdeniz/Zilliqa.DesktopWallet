using System.ComponentModel;
using Zillifriends.Shared.Common;
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
            RefreshBalances();
            LoadTransactions(_cancellationTokenSource.Token);
        }

        public Address Address => AccountData.Address;

        public string AddressBech32 => AccountData.GetAddressBech32();

        public string AddressHex => AccountData.GetAddressHex();

        public AccountBase AccountData { get; }

        public BindingList<ZilTransactionRowViewModel> ZilTransactions { get; }

        public BindingList<TokenTransactionRowViewModel> TokenTransactions { get; }

        public BindingList<TokenBalanceRowViewModel> TokenBalances { get; }

        public decimal ZilLiquidBalance => _zilLiquidBalance ?? 0m;

        public decimal ZilTotalBalance => ZilLiquidBalance; // + Staked Balance + Liquidity Pools Balances

        public decimal ZilTotalValueUsd => _zilValueUsd ?? 0m;

        public decimal TokensValueUsd => _tokensValueUsd ?? 0m;

        public decimal TokensValueZil => _tokensValueZil ?? 0m;

        public decimal TotalValueUsd => ZilTotalValueUsd + TokensValueUsd;

        private void OnTransactionsChanged()
        {
            _zilLiquidBalance = null;
            _zilValueUsd = null;
            _tokensValueUsd = null;
            _tokensValueZil = null;
            RefreshBalances();
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

        private void RefreshBalances()
        {
            Task.Run(async () =>
            {
                for (int i = 1; i <= 3; i++)
                {
                    try
                    {
                        _zilLiquidBalance = (await ZilliqaClient.DefaultInstance.GetBalance(Address))?.GetBalance(Unit.ZIL);
                        var coingeckoRepo = RepositoryManager.Instance.CoingeckoRepository;
                        _zilValueUsd = coingeckoRepo.ZilCoinPrice?.MarketData.CurrentPrice.Usd * ZilTotalBalance;
                        _tokensValueUsd = TokenBalances.Any() ? TokenBalances.Sum(t => t.ValueUsd) : 0;
                        _tokensValueZil = TokenBalances.Any() ? TokenBalances.Sum(t => t.ValueZil) : 0;
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
        }

        private void LoadTransactions(CancellationToken cancellationToken)
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
                var transactionViewModels = new List<TransactionRowViewModelBase>();
                try
                {
                    var addressTransactions = tableTransactions.FindRecords(transactionsFilter)
                        .OrderByDescending(t => t.Timestamp).ToList();
                    foreach (var transaction in addressTransactions)
                    {
                        if (cancellationToken.IsCancellationRequested)
                        {
                            return;
                        }

                        var vm = AddRecordViewModel(transaction, false, false, false);
                        if (vm != null)
                        {
                            transactionViewModels.Add(vm);
                        }
                    }
                    if (addressTransactions.Any())
                    {
                        OnTransactionsChanged();
                    }
                    if (!cancellationToken.IsCancellationRequested)
                    {
                        _transactionEventNotificator = tableTransactions.AddEventNotificator(record =>
                                record.SenderAddress == addressHex
                                || record.ToAddress == addressHex
                                || record.TokenTransferSender() == addressHex
                                || record.TokenTransferRecipient() == addressHex,
                            OnAddedRecordEventNotified);
                    }
                }
                catch (TaskCanceledException)
                {
                    // expected
                }
                catch (Exception e)
                {
                    Logging.LogError("Account View Model LoadTransactions failed", e);
                }

                var loadPropertiesState = transactionViewModels.Select(vm => vm.LoadValuesProperties(false)).ToList();
                try
                {
                    for (int i = 0; i < 60; i++) // wait max 2 minutes
                    {
                        if (loadPropertiesState.All(l => l.IsCompleted))
                        {
                            WinFormsSynchronisationContext.ExecuteSynchronized(() =>
                            {
                                ZilTransactions.ResetBindings();
                                TokenTransactions.ResetBindings();
                                TokenBalances.ResetBindings();
                            });
                            break;
                        }

                        Task.Run(async () => await Task.Delay(2000, cancellationToken), cancellationToken).GetAwaiter()
                            .GetResult();
                    }
                }
                catch (TaskCanceledException)
                {
                    // expected
                }
            }, cancellationToken);
        }

        private void OnAddedRecordEventNotified(Transaction record)
        {
            AddRecordViewModel(record, true, true, true);
        }

        private TransactionRowViewModelBase? AddRecordViewModel(Transaction record, bool raiseOnRecordsChanged, bool loadCurrencyValues, bool notifiyPropertyChanged)
        {
            TransactionRowViewModelBase? result = null;
            try
            {
                if (record.TransactionTypeEnum == TransactionType.Payment)
                {
                    var transactionViewModel = new ZilTransactionRowViewModel(Address, record);
                    if (loadCurrencyValues)
                    {
                        transactionViewModel.LoadValuesProperties(notifiyPropertyChanged);
                    }
                    if (ZilTransactions.FirstOrDefault()?.Transaction.Timestamp < record.Timestamp)
                    {
                        // add to beginning
                        ZilTransactions.Insert(0, transactionViewModel);
                    }
                    else
                    {
                        // add to end
                        ZilTransactions.Add(transactionViewModel);
                    }
                    result = transactionViewModel;
                }
                else if (record.TransactionTypeEnum == TransactionType.ContractCall)
                {
                    var tokenModel = TokenDataService.Instance.FindTokenByAddress(record.ToAddress);
                    if (tokenModel != null)
                    {
                        var tokenTransaction = new TokenTransactionRowViewModel(Address, record, tokenModel);
                        if (TokenTransactions.FirstOrDefault()?.Transaction.Timestamp < record.Timestamp)
                        {
                            // add to beginning
                            TokenTransactions.Insert(0, tokenTransaction);
                        }
                        else
                        {
                            // add to end
                            TokenTransactions.Add(tokenTransaction);
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

                if (raiseOnRecordsChanged)
                {
                    OnTransactionsChanged();
                }
            }
            catch (Exception e)
            {
                Logging.LogError("Account View Model OnAddedRecord failed.", e, record);
            }

            return result;
        }
    }
}
