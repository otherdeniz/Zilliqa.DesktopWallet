using System.ComponentModel;
using Zilligraph.Database.Storage;
using Zilligraph.Database.Storage.FilterQuery;
using Zilliqa.DesktopWallet.ApiClient;
using Zilliqa.DesktopWallet.ApiClient.Enums;
using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.Repository;
using Zilliqa.DesktopWallet.Core.Services;
using Zilliqa.DesktopWallet.Core.ViewModel.DataSource;
using Zilliqa.DesktopWallet.DatabaseSchema;

namespace Zilliqa.DesktopWallet.Core.ViewModel
{
    public class AccountViewModel
    {
        private readonly Action<AccountViewModel> _afterChangedAction;
        private readonly bool _loadCurrencyValues;
        private ZilligraphTableEventNotificator<Transaction>? _transactionEventNotificator;
        private readonly CancellationTokenSource _cancellationTokenSource = new();
        private decimal? _zilLiquidBalance;
        private decimal? _zilValueUsd;
        private decimal? _tokensValueUsd;
        private decimal? _tokensValueZil;

        public AccountViewModel(AccountBase accountData, Action<AccountViewModel> afterChangedAction, bool loadCurrencyValues) 
        {
            AccountData = accountData;
            _afterChangedAction = afterChangedAction;
            _loadCurrencyValues = loadCurrencyValues;
            RefreshBalances();
            LoadTransactions(_cancellationTokenSource.Token);
        }

        public Address Address => AccountData.Address;

        public string AddressBech32 => AccountData.GetAddressBech32();

        public string AddressHex => AccountData.GetAddressHex();

        public AccountBase AccountData { get; }

        public BindingList<TokenBalanceRowViewModel> TokenBalances { get; } = new();

        public PageableDataSource<CommonTransactionRowViewModel> AllTransactions { get; } = new();

        public PageableDataSource<ZilTransactionRowViewModel> ZilTransactions { get; } = new();

        public PageableDataSource<TokenTransactionRowViewModel> TokenTransactions { get; } = new();

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
        }

        private void RaiseAfterChange()
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
                        RaiseAfterChange();
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
                try
                {
                    var transactionViewModels = tableTransactions.FindRecords(transactionsFilter)
                        .OrderByDescending(t => t.Timestamp)
                        .Select(t => new TransactionViewModels(Address, t))
                        .ToList();

                    AllTransactions.Load(transactionViewModels
                        .Select(t => t.CommonTransaction)
                        .ToList()
                    );

                    ZilTransactions.Load(transactionViewModels
                        .Where(t => t.ZilTransaction != null)
                        .Select(t => t.ZilTransaction!)
                        .ToList()
                    );

                    TokenTransactions.Load(transactionViewModels
                        .Where(t => t.TokenTransaction != null)
                        .Select(t => t.TokenTransaction!)
                        .ToList()
                    );

                    if (_loadCurrencyValues)
                    {
                        transactionViewModels.ForEach(t => t.CommonTransaction.LoadValuesProperties(false));
                    }

                    if (!cancellationToken.IsCancellationRequested)
                    {
                        _transactionEventNotificator = tableTransactions.AddEventNotificator(r => 
                                r.SenderAddress == addressHex
                                || r.ToAddress == addressHex
                                || r.TokenTransferSender() == addressHex
                                || r.TokenTransferRecipient() == addressHex
                            , OnAddedRecordEventNotified);
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

                //if (_loadCurrencyValues 
                //    && !cancellationToken.IsCancellationRequested)
                //{
                //    transactionViewModels.ForEach(vm =>
                //    {
                //        if (!cancellationToken.IsCancellationRequested)
                //        {
                //            vm.LoadValuesProperties(false);
                //        }
                //    });
                //    //TODO: check if re-binding is necessary after all Values loaded
                //    //var loadPropertiesState = transactionViewModels.Select(vm => vm.LoadValuesProperties(false)).ToList();
                //    //try
                //    //{
                //    //    for (int i = 0; i < 60; i++) // wait max 2 minutes
                //    //    {
                //    //        if (loadPropertiesState.All(l => l.IsCompleted))
                //    //        {
                //    //            WinFormsSynchronisationContext.ExecuteSynchronized(() =>
                //    //            {

                //    //                AllTransactions.ResetBindings();
                //    //                ZilTransactions.ResetBindings();
                //    //                TokenTransactions.ResetBindings();
                //    //                TokenBalances.ResetBindings();
                //    //            });
                //    //            break;
                //    //        }

                //    //        Task.Run(async () => await Task.Delay(2000, cancellationToken), cancellationToken).GetAwaiter()
                //    //            .GetResult();
                //    //    }
                //    //}
                //    //catch (TaskCanceledException)
                //    //{
                //    //    // expected
                //    //}
                //}
            }, cancellationToken);
        }

        private void OnAddedRecordEventNotified(Transaction record)
        {
            var viewModel = new TransactionViewModels(Address, record);
            AllTransactions.InsertRecordToTop(viewModel.CommonTransaction);
            if (viewModel.ZilTransaction != null)
            {
                ZilTransactions.InsertRecordToTop(viewModel.ZilTransaction);
            }
            if (viewModel.TokenTransaction != null)
            {
                TokenTransactions.InsertRecordToTop(viewModel.TokenTransaction);
                AddTokenBalanceTransaction(viewModel.TokenTransaction);
            }
            OnTransactionsChanged();
        }

        private void AddTokenBalanceTransaction(TokenTransactionRowViewModel viewModel)
        {
            var tokenBalance = TokenBalances.FirstOrDefault(t => t.Model.Symbol == viewModel.Symbol);
            if (tokenBalance == null)
            {
                tokenBalance = new TokenBalanceRowViewModel(viewModel.TokenModel);
                WinFormsSynchronisationContext.ExecuteSynchronized(() =>
                {
                    TokenBalances.Add(tokenBalance);
                });
            }

            tokenBalance.Transactions += 1;
            if (viewModel.Direction == TransactionDirection.ReceiveFrom)
            {
                tokenBalance.Balance += viewModel.Amount;
            }
            else
            {
                tokenBalance.Balance -= viewModel.Amount;
            }
        }

        private class TransactionViewModels
        {
            public TransactionViewModels(Address thisAddress, Transaction transaction)
            {
                Transaction = transaction;
                TransactionRowViewModelBase? innerViewModel = null;
                if (transaction.TransactionTypeEnum == TransactionType.Payment)
                {
                    ZilTransaction = new ZilTransactionRowViewModel(thisAddress, transaction);
                    innerViewModel = ZilTransaction;
                }
                else if (transaction.TransactionTypeEnum == TransactionType.ContractCall
                         && transaction.DataContractCall.Tag == "Transfer")
                {
                    var tokenModel = TokenDataService.Instance.FindTokenByAddress(transaction.ToAddress);
                    if (tokenModel != null)
                    {
                        TokenTransaction = new TokenTransactionRowViewModel(thisAddress, transaction, tokenModel);
                        innerViewModel = TokenTransaction;
                    }
                }

                CommonTransaction = new CommonTransactionRowViewModel(thisAddress, transaction, innerViewModel);
            }

            public Transaction Transaction { get; }

            public CommonTransactionRowViewModel CommonTransaction { get; }

            public ZilTransactionRowViewModel? ZilTransaction { get; }

            public TokenTransactionRowViewModel? TokenTransaction { get; }
        }
    }
}
