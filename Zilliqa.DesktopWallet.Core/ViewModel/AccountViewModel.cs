using System.ComponentModel;
using Zillifriends.Shared.Common;
using Zilligraph.Database.Storage;
using Zilligraph.Database.Storage.FilterQuery;
using Zilliqa.DesktopWallet.ApiClient;
using Zilliqa.DesktopWallet.ApiClient.Enums;
using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.Repository;
using Zilliqa.DesktopWallet.Core.Services;
using Zilliqa.DesktopWallet.Core.ViewModel.DataSource;
using Zilliqa.DesktopWallet.DatabaseSchema;
using Zilliqa.DesktopWallet.DatabaseSchema.ParsedData;

namespace Zilliqa.DesktopWallet.Core.ViewModel
{
    public class AccountViewModel : IDisposable
    {
        private Action<AccountViewModel>? _afterChangedAction;
        private readonly bool _loadCurrencyValues;
        private ZilligraphTableEventNotificator<Transaction>? _transactionEventNotificator;
        private readonly CancellationTokenSource _cancellationTokenSource = new();
        private decimal? _zilLiquidBalance;
        private decimal? _zilStakedBalance;
        private decimal? _zilValueUsd;
        private decimal? _tokensValueUsd;
        private decimal? _tokensValueZil;
        private long? _refreshedBalancesRecordCount;
        private List<StakingDelegatorAmount>? _stakingDelegatorAmounts;

        public AccountViewModel(AccountBase accountData, Action<AccountViewModel>? afterChangedAction = null, bool loadCurrencyValues = false) 
        {
            AccountData = accountData;
            _afterChangedAction = afterChangedAction;
            _loadCurrencyValues = loadCurrencyValues;
            RefreshBalances(true);
            LoadTransactions(_cancellationTokenSource.Token);
        }

        public Address Address => AccountData.Address;

        public string AddressBech32 => AccountData.GetAddressBech32();

        public string AddressHex => AccountData.GetAddressHex();

        public AccountBase AccountData { get; }

        public DateTime CreatedDate { get; private set; } = DateTime.MinValue;

        public BindingList<TokenBalanceRowViewModel> TokenBalances { get; } = new();

        public PageableDataSource<CommonTransactionRowViewModel> AllTransactions { get; } = new();

        public PageableDataSource<ZilTransactionRowViewModel> ZilTransactions { get; } = new();

        public PageableDataSource<TokenTransactionRowViewModel> TokenTransactions { get; } = new();

        public decimal ZilLiquidBalance => _zilLiquidBalance ?? 0m;

        public decimal ZilStakedBalance => _zilStakedBalance ?? 0m;

        public decimal ZilTotalBalance => ZilLiquidBalance + ZilStakedBalance; // + Staked Balance + Liquidity Pools Balances

        public decimal ZilTotalValueUsd => _zilValueUsd ?? 0m;

        public decimal TokensValueUsd => _tokensValueUsd ?? 0m;

        public decimal TokensValueZil => _tokensValueZil ?? 0m;

        public decimal TotalValueUsd => ZilTotalValueUsd + TokensValueUsd;

        public bool HasFunds => ZilTotalBalance > 0 || TotalValueUsd > 0;

        private void OnTransactionsChanged(bool callPublicApi)
        {
            RefreshBalances(callPublicApi);
        }

        private void RaiseAfterChange()
        {
            WinFormsSynchronisationContext.ExecuteSynchronized(() =>
            {
                _afterChangedAction?.Invoke(this);
            });
        }

        public void Dispose()
        {
            _afterChangedAction = null;
            _cancellationTokenSource.Cancel();
            //TODO: check if _cancellationTokenSource.Dispose() must be called
            if (_transactionEventNotificator != null)
            {
                var tableTransactions = RepositoryManager.Instance.DatabaseRepository.Database.GetTable<Transaction>();
                tableTransactions.RemoveEventNotificator(_transactionEventNotificator);
            }

            _transactionEventNotificator = null;
        }

        private void RefreshBalances(bool callPublicApi)
        {
            if (_refreshedBalancesRecordCount == AllTransactions.RecordCount) return;
            _refreshedBalancesRecordCount = AllTransactions.RecordCount;
            Task.Run(async () =>
            {
                if (callPublicApi)
                {
                    _stakingDelegatorAmounts = StakingService.Instance.GetStakedAmounts(Address);
                    _zilStakedBalance = _stakingDelegatorAmounts.Count > 0
                        ? _stakingDelegatorAmounts.Sum(s => s.StakeAmount)
                        : 0;
                    _zilLiquidBalance = (await ZilliqaClient.DefaultInstance.GetBalance(Address))?.GetBalance(Unit.ZIL);
                }
                for (int i = 1; i <= 3; i++)
                {
                    try
                    {
                        var coingeckoRepo = RepositoryManager.Instance.CoingeckoRepository;
                        _zilValueUsd = coingeckoRepo.ZilCoinPrice?.MarketData.CurrentPrice.Usd * ZilTotalBalance;
                        if (AllTransactions.Records?.Count > 0)
                        {
                            CreatedDate = AllTransactions.Records.Min(t => t.Transaction.Timestamp);
                        }
                        break;
                    }
                    catch (Exception e)
                    {
                        Logging.LogError($"GetZilLiquidBalance({Address.GetBech32()}) failed", e);
                    }
                    // retry after a few seconds
                    await Task.Delay(Random.Shared.Next(1000, 2000) * i);
                }

                RefreshTokenBalances();
            });
        }

        private void RefreshTokenBalances()
        {
            _tokensValueUsd = TokenBalances.Any() ? TokenBalances.Sum(t => t.ValueUsd) : 0;
            _tokensValueZil = 0; // TokenBalances.Any() ? TokenBalances.Sum(t => t.ValueZil) : 0;
            RaiseAfterChange();
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
                    var transactionViewModels = tableTransactions.EnumerateRecords(transactionsFilter)
                        .OrderByDescending(t => t.Timestamp)
                        .Select(t =>
                        {
                            AddTokenBalanceFromContract(t, false);
                            return new TransactionViewModels(Address, t);
                        })
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
                        .Select(t =>
                        {
                            AddTokenBalanceTransaction(t.TokenTransaction!, false);
                            return t.TokenTransaction!;
                        })
                        .ToList()
                    );

                    TokenBalances.ForEach(t => t.UpdateValuesProperties(true, RefreshTokenBalances));

                    if (_loadCurrencyValues)
                    {
                        transactionViewModels.ForEach(t => t.CommonTransaction.LoadValuesProperties(false));
                    }

                    OnTransactionsChanged(false);

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
            }, cancellationToken);
        }

        private void OnAddedRecordEventNotified(Transaction record)
        {
            WinFormsSynchronisationContext.ExecuteSynchronized(() =>
            {
                AddTokenBalanceFromContract(record, false);
                var viewModel = new TransactionViewModels(Address, record);
                var insertToTop = AllTransactions.GetFirstItem()?.Transaction.Timestamp < record.Timestamp;
                AllTransactions.InsertRecord(viewModel.CommonTransaction, insertToTop);
                if (viewModel.ZilTransaction != null)
                {
                    ZilTransactions.InsertRecord(viewModel.ZilTransaction, insertToTop);
                }
                if (viewModel.TokenTransaction != null)
                {
                    TokenTransactions.InsertRecord(viewModel.TokenTransaction, insertToTop);
                    AddTokenBalanceTransaction(viewModel.TokenTransaction, true);
                }
                viewModel.CommonTransaction.LoadValuesProperties(true);
                OnTransactionsChanged(true);
            });
        }

        private void AddTokenBalanceTransaction(TokenTransactionRowViewModel viewModel, bool updateValueProperties)
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

            if (updateValueProperties)
            {
                tokenBalance.UpdateValuesProperties(true, RefreshTokenBalances);
            }
        }

        private void AddTokenBalanceFromContract(Transaction transaction, bool updateValueProperties)
        {
            if (transaction.TransactionTypeEnum != TransactionType.ContractCall) return;

            // TODO: get Minted from Transition as well (is better)
            // Event "Minted"
            if (transaction.Receipt.EventLogs?.FirstOrDefault(e => e.Eventname == "Minted")
                is { } mintedEvent
                && mintedEvent.Params.FirstOrDefault(p => p.Vname == "amount")?.ResolvedValue 
                    is ParamValueUInt128 paramValueMintedAmount)
            {
                var tokenByAddress = TokenDataService.Instance.FindTokenByAddress(mintedEvent.Address);
                if (tokenByAddress != null)
                {
                    var tokenBalance = GetOrAddTokenBalance(tokenByAddress.TokenModel);
                    tokenBalance.Transactions += 1;
                    tokenBalance.Balance += tokenByAddress.SmartContract.AmountToDecimal(paramValueMintedAmount.Number128);
                    if (updateValueProperties)
                    {
                        tokenBalance.UpdateValuesProperties(true, RefreshTokenBalances);
                    }
                }

            }
            // Transition "Transfer"
            else if (transaction.Receipt.Transitions?.FirstOrDefault(t => t.Msg.Tag == "Transfer")
                         is { } transferTransition
                     && transferTransition.Msg.Params?.FirstOrDefault(t => t.Vname == "amount")?.ResolvedValue
                         is ParamValueUInt128 paramTokenAmount)
            {
                var tokenByAddress = TokenDataService.Instance.FindTokenByAddress(transferTransition.Msg.Recipient);
                if (tokenByAddress != null)
                {
                    var tokenBalance = GetOrAddTokenBalance(tokenByAddress.TokenModel);
                    tokenBalance.Transactions += 1;
                    tokenBalance.Balance += tokenByAddress.SmartContract.AmountToDecimal(paramTokenAmount.Number128);
                    if (updateValueProperties)
                    {
                        tokenBalance.UpdateValuesProperties(true, RefreshTokenBalances);
                    }
                }
            }
        }

        private TokenBalanceRowViewModel GetOrAddTokenBalance(TokenModel tokenModel)
        {
            var tokenBalance = TokenBalances.FirstOrDefault(t => t.Model.Symbol == tokenModel.Symbol);
            if (tokenBalance == null)
            {
                tokenBalance = new TokenBalanceRowViewModel(tokenModel);
                WinFormsSynchronisationContext.ExecuteSynchronized(() =>
                {
                    TokenBalances.Add(tokenBalance);
                });
            }
            return tokenBalance;
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
                else if (transaction.TransactionTypeEnum == TransactionType.ContractCall)
                {
                    var tokenModel = TokenDataService.Instance.FindTokenByAddress(transaction.ToAddress);
                    if (transaction.DataContractCall.Tag == "Transfer")
                    {
                        if (tokenModel != null)
                        {
                            TokenTransaction = new TokenTransactionRowViewModel(thisAddress, transaction, tokenModel);
                            innerViewModel = TokenTransaction;
                        }
                    }
                    else
                    {
                        ContractCallTransaction = new ContractCallTransactionRowViewModel(thisAddress, transaction);
                        innerViewModel = ContractCallTransaction;
                    }
                }

                CommonTransaction = new CommonTransactionRowViewModel(thisAddress, transaction, innerViewModel);
            }

            public Transaction Transaction { get; }

            public CommonTransactionRowViewModel CommonTransaction { get; }

            public ZilTransactionRowViewModel? ZilTransaction { get; }

            public TokenTransactionRowViewModel? TokenTransaction { get; }

            public ContractCallTransactionRowViewModel? ContractCallTransaction { get; }
        }

    }
}
