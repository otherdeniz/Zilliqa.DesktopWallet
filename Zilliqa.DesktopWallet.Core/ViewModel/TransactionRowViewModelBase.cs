using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using Zilliqa.DesktopWallet.ApiClient;
using Zilliqa.DesktopWallet.Core.Annotations;
using Zilliqa.DesktopWallet.Core.Extensions;
using Zilliqa.DesktopWallet.Core.Repository;
using Zilliqa.DesktopWallet.Core.ViewModel.Attributes;
using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;
using Zilliqa.DesktopWallet.DatabaseSchema;

namespace Zilliqa.DesktopWallet.Core.ViewModel
{
    public class TransactionRowViewModelBase : INotifyPropertyChanged
    {
        private readonly Transaction _transactionModel;
        private BlockNumberValue? _blockNumber;
        private Image? _directionIcon;
        private AddressValue? _otherAddress;
        private decimal? _fee;

        public TransactionRowViewModelBase(Address thisAddress, Transaction transactionModel)
        {
            ThisAddress = thisAddress;
            _transactionModel = transactionModel;
            Direction = thisAddress.Equals(transactionModel.SenderAddress)
                ? TransactionDirection.SendTo
                : TransactionDirection.ReceiveFrom;
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        [Browsable(false)]
        public Transaction Transaction => _transactionModel;

        [Browsable(false)] 
        public virtual BlockNumberValue Block => _blockNumber ??= new BlockNumberValue(Transaction.BlockNumber);

        [Browsable(false)]
        public virtual TransactionDirection Direction { get; }

        [Browsable(false)]
        public virtual Image? DirectionIcon => _directionIcon ??= Direction == TransactionDirection.SendTo
            ? IconResources.ArrowRightGray16
            : IconResources.ArrowLeftGray16;

        [Browsable(false)]
        public Address ThisAddress { get; }

        [Browsable(false)]
        [ColumnWidth(150)]
        public virtual AddressValue? OtherAddress => _otherAddress ??= Direction == TransactionDirection.SendTo
            ? new AddressValue(Transaction.ToAddress)
            : new AddressValue(Transaction.SenderAddress);

        [Browsable(false)] 
        public virtual decimal Amount => 0;

        [Browsable(false)] 
        public virtual string Symbol => "ZIL";

        [Browsable(false)]
        [GridViewFormat("0.0000 ZIL")]
        public virtual decimal Fee => _fee ??= (Transaction.Receipt.CumulativeGas * Transaction.GasPrice).ZilSatoshisToZil();

        [DisplayName("USD Today")]
        [GridViewFormat("#,##0.00 $")]
        [GridViewBackground(KnownColor.Gainsboro)]
        [GridViewDynamicColumn(DynamicColumnCategory.CurrencyUsd)]
        public virtual decimal? ValueUsdToday { get; private set; }

        [DisplayName("USD Then")]
        [GridViewFormat("#,##0.00 $")]
        [GridViewBackground(KnownColor.Gainsboro)]
        [GridViewDynamicColumn(DynamicColumnCategory.CurrencyUsd)]
        public virtual decimal? ValueUsdThen { get; private set; }

        [DisplayName("USD Change")]
        [GridViewFormat(null, UseGreenOrRedNumbers = true)]
        [GridViewBackground(KnownColor.Gainsboro)]
        [GridViewDynamicColumn(DynamicColumnCategory.CurrencyUsd)]
        public virtual ValueNumberDisplay? ChangeUsd { get; private set; }

        [DisplayName("CHF Today")]
        [GridViewFormat("#,##0.00 CHF")]
        [GridViewBackground(KnownColor.AliceBlue)]
        [GridViewDynamicColumn(DynamicColumnCategory.CurrencyChf)]
        public virtual decimal? ValueChfToday { get; private set; }

        [DisplayName("CHF Then")]
        [GridViewFormat("#,##0.00 CHF")]
        [GridViewBackground(KnownColor.AliceBlue)]
        [GridViewDynamicColumn(DynamicColumnCategory.CurrencyChf)]
        public virtual decimal? ValueChfThen { get; private set; }

        [DisplayName("CHF Change")]
        [GridViewFormat(null, UseGreenOrRedNumbers = true)]
        [GridViewBackground(KnownColor.AliceBlue)]
        [GridViewDynamicColumn(DynamicColumnCategory.CurrencyChf)]
        public virtual ValueNumberDisplay? ChangeChf { get; private set; }

        [DisplayName("EUR Today")]
        [GridViewFormat("#,##0.00 EUR")]
        [GridViewBackground(KnownColor.AliceBlue)]
        [GridViewDynamicColumn(DynamicColumnCategory.CurrencyEur)]
        public virtual decimal? ValueEurToday { get; private set; }

        [DisplayName("EUR Then")]
        [GridViewFormat("#,##0.00 EUR")]
        [GridViewBackground(KnownColor.AliceBlue)]
        [GridViewDynamicColumn(DynamicColumnCategory.CurrencyEur)]
        public virtual decimal? ValueEurThen { get; private set; }

        [DisplayName("EUR Change")]
        [GridViewFormat(null, UseGreenOrRedNumbers = true)]
        [GridViewBackground(KnownColor.AliceBlue)]
        [GridViewDynamicColumn(DynamicColumnCategory.CurrencyEur)]
        public virtual ValueNumberDisplay? ChangeEur { get; private set; }

        [DisplayName("GBP Today")]
        [GridViewFormat("#,##0.00 GBP")]
        [GridViewBackground(KnownColor.AliceBlue)]
        [GridViewDynamicColumn(DynamicColumnCategory.CurrencyGbp)]
        public virtual decimal? ValueGbpToday { get; private set; }

        [DisplayName("GBP Then")]
        [GridViewFormat("#,##0.00 GBP")]
        [GridViewBackground(KnownColor.AliceBlue)]
        [GridViewDynamicColumn(DynamicColumnCategory.CurrencyGbp)]
        public virtual decimal? ValueGbpThen { get; private set; }

        [DisplayName("GBP Change")]
        [GridViewFormat(null, UseGreenOrRedNumbers = true)]
        [GridViewBackground(KnownColor.AliceBlue)]
        [GridViewDynamicColumn(DynamicColumnCategory.CurrencyGbp)]
        public virtual ValueNumberDisplay? ChangeGbp { get; private set; }

        [DisplayName("BTC Today")]
        [GridViewFormat("#,##0.00000000 BTC")]
        [GridViewBackground(KnownColor.Bisque)]
        [GridViewDynamicColumn(DynamicColumnCategory.CurrencyBtc)]
        public virtual decimal? ValueBtcToday { get; private set; }

        [DisplayName("BTC Then")]
        [GridViewFormat("#,##0.00000000 BTC")]
        [GridViewBackground(KnownColor.Bisque)]
        [GridViewDynamicColumn(DynamicColumnCategory.CurrencyBtc)]
        public virtual decimal? ValueBtcThen { get; private set; }

        [DisplayName("BTC Change")]
        [GridViewFormat(null, UseGreenOrRedNumbers = true)]
        [GridViewBackground(KnownColor.Bisque)]
        [GridViewDynamicColumn(DynamicColumnCategory.CurrencyBtc)]
        public virtual ValueNumberDisplay? ChangeBtc { get; private set; }

        [DisplayName("ETH Today")]
        [GridViewFormat("#,##0.00000 ETH")]
        [GridViewBackground(KnownColor.SkyBlue)]
        [GridViewDynamicColumn(DynamicColumnCategory.CurrencyEth)]
        public virtual decimal? ValueEthToday { get; private set; }

        [DisplayName("ETH Then")]
        [GridViewFormat("#,##0.00000 ETH")]
        [GridViewBackground(KnownColor.SkyBlue)]
        [GridViewDynamicColumn(DynamicColumnCategory.CurrencyEth)]
        public virtual decimal? ValueEthThen { get; private set; }

        [DisplayName("ETH Change")]
        [GridViewFormat(null, UseGreenOrRedNumbers = true)]
        [GridViewBackground(KnownColor.SkyBlue)]
        [GridViewDynamicColumn(DynamicColumnCategory.CurrencyEth)]
        public virtual ValueNumberDisplay? ChangeEth { get; private set; }

        [DisplayName("LTC Today")]
        [GridViewFormat("#,##0.00000 LTC")]
        [GridViewBackground(KnownColor.LightGray)]
        [GridViewDynamicColumn(DynamicColumnCategory.CurrencyLtc)]
        public virtual decimal? ValueLtcToday { get; private set; }

        [DisplayName("LTC Then")]
        [GridViewFormat("#,##0.00000 LTC")]
        [GridViewBackground(KnownColor.LightGray)]
        [GridViewDynamicColumn(DynamicColumnCategory.CurrencyLtc)]
        public virtual decimal? ValueLtcThen { get; private set; }

        [DisplayName("LTC Change")]
        [GridViewFormat(null, UseGreenOrRedNumbers = true)]
        [GridViewBackground(KnownColor.LightGray)]
        [GridViewDynamicColumn(DynamicColumnCategory.CurrencyLtc)]
        public virtual ValueNumberDisplay? ChangeLtc { get; private set; }

        public virtual void LoadValuesProperties(bool notifiyPropertyChanged)
        {
            if (Symbol == "") return;
            try
            {
                RepositoryManager.Instance.CoingeckoRepository.GetCoinPrice(Symbol, cp =>
                {
                    ValueUsdToday = cp.MarketData.CurrentPrice.Usd * Amount;
                    ValueChfToday = cp.MarketData.CurrentPrice.Chf * Amount;
                    ValueEurToday = cp.MarketData.CurrentPrice.Eur * Amount;
                    ValueGbpToday = cp.MarketData.CurrentPrice.Gbp * Amount;
                    ValueBtcToday = cp.MarketData.CurrentPrice.Btc * Amount;
                    ValueEthToday = cp.MarketData.CurrentPrice.Eth * Amount;
                    ValueLtcToday = cp.MarketData.CurrentPrice.Ltc * Amount;
                    if (notifiyPropertyChanged)
                    {
                        WinFormsSynchronisationContext.ExecuteSynchronized(() =>
                        {
                            OnPropertyChanged(nameof(ValueUsdToday));
                            OnPropertyChanged(nameof(ValueChfToday));
                            OnPropertyChanged(nameof(ValueEurToday));
                            OnPropertyChanged(nameof(ValueGbpToday));
                            OnPropertyChanged(nameof(ValueBtcToday));
                            OnPropertyChanged(nameof(ValueEthToday));
                            OnPropertyChanged(nameof(ValueLtcToday));
                        });
                    }
                });

                RepositoryManager.Instance.CoingeckoRepository.GetCoinHistory(Transaction.Timestamp, Symbol, ch =>
                {
                    try
                    {
                        ValueUsdThen = ch.MarketData.CurrentPrice.Usd * Amount;
                        ValueChfThen = ch.MarketData.CurrentPrice.Chf * Amount;
                        ValueEurThen = ch.MarketData.CurrentPrice.Eur * Amount;
                        ValueGbpThen = ch.MarketData.CurrentPrice.Gbp * Amount;
                        ValueBtcThen = ch.MarketData.CurrentPrice.Btc * Amount;
                        ValueEthThen = ch.MarketData.CurrentPrice.Eth * Amount;
                        ValueLtcThen = ch.MarketData.CurrentPrice.Ltc * Amount;

                        if (ValueUsdToday != null && ValueUsdThen > 0)
                        {
                            var changeValue = ValueUsdToday - ValueUsdThen;
                            var changePercent = changeValue != 0
                                ? 100m / ValueUsdThen * changeValue
                                : 0;
                            ChangeUsd = new ValueNumberDisplay(changeValue.GetValueOrDefault(),
                                $"{changePercent:0.00} % ({changeValue:#,##0.00} $)");
                        }
                        if (ValueChfToday != null && ValueChfThen > 0)
                        {
                            var changeValue = ValueChfToday - ValueChfThen;
                            var changePercent = changeValue != 0
                                ? 100m / ValueChfThen * changeValue
                                : 0;
                            ChangeChf = new ValueNumberDisplay(changeValue.GetValueOrDefault(),
                                $"{changePercent:0.00} % ({changeValue:#,##0.00} CHF)");
                        }
                        if (ValueEurToday != null && ValueEurThen > 0)
                        {
                            var changeValue = ValueEurToday - ValueEurThen;
                            var changePercent = changeValue != 0
                                ? 100m / ValueEurThen * changeValue
                                : 0;
                            ChangeEur = new ValueNumberDisplay(changeValue.GetValueOrDefault(),
                                $"{changePercent:0.00} % ({changeValue:#,##0.00} EUR)");
                        }
                        if (ValueGbpToday != null && ValueGbpThen > 0)
                        {
                            var changeValue = ValueGbpToday - ValueGbpThen;
                            var changePercent = changeValue != 0
                                ? 100m / ValueGbpThen * changeValue
                                : 0;
                            ChangeGbp = new ValueNumberDisplay(changeValue.GetValueOrDefault(),
                                $"{changePercent:0.00} % ({changeValue:#,##0.00} GBP)");
                        }
                        if (ValueBtcToday != null && ValueBtcThen > 0)
                        {
                            var changeValue = ValueBtcToday - ValueBtcThen;
                            var changePercent = changeValue != 0
                                ? 100m / ValueBtcThen * changeValue
                                : 0;
                            ChangeBtc = new ValueNumberDisplay(changeValue.GetValueOrDefault(),
                                $"{changePercent:0.00} % ({changeValue:#,##0.00000000} BTC)");
                        }
                        if (ValueEthToday != null && ValueEthThen > 0)
                        {
                            var changeValue = ValueEthToday - ValueEthThen;
                            var changePercent = changeValue != 0
                                ? 100m / ValueEthThen * changeValue
                                : 0;
                            ChangeEth = new ValueNumberDisplay(changeValue.GetValueOrDefault(),
                                $"{changePercent:0.00} % ({changeValue:#,##0.00000} ETH)");
                        }
                        if (ValueLtcToday != null && ValueLtcThen > 0)
                        {
                            var changeValue = ValueLtcToday - ValueLtcThen;
                            var changePercent = changeValue != 0
                                ? 100m / ValueLtcThen * changeValue
                                : 0;
                            ChangeLtc = new ValueNumberDisplay(changeValue.GetValueOrDefault(),
                                $"{changePercent:0.00} % ({changeValue:#,##0.00000} LTC)");
                        }

                        if (notifiyPropertyChanged)
                        {
                            WinFormsSynchronisationContext.ExecuteSynchronized(() =>
                            {
                                OnPropertyChanged(nameof(ValueUsdThen));
                                OnPropertyChanged(nameof(ValueChfThen));
                                OnPropertyChanged(nameof(ValueEurThen));
                                OnPropertyChanged(nameof(ValueGbpThen));
                                OnPropertyChanged(nameof(ValueBtcThen));
                                OnPropertyChanged(nameof(ValueEthThen));
                                OnPropertyChanged(nameof(ValueLtcThen));
                                OnPropertyChanged(nameof(ChangeUsd));
                                OnPropertyChanged(nameof(ChangeChf));
                                OnPropertyChanged(nameof(ChangeEur));
                                OnPropertyChanged(nameof(ChangeGbp));
                                OnPropertyChanged(nameof(ChangeBtc));
                                OnPropertyChanged(nameof(ChangeEth));
                                OnPropertyChanged(nameof(ChangeLtc));
                            });
                        }
                    }
                    catch (Exception)
                    {
                        // ignore
                    }
                });
            }
            catch (Exception e)
            {
                Logging.LogError($"TransactionRowViewModelBase.LoadValuesProperties of Coin {Symbol} failed", e);
            }
        }

        public override string ToString()
        {
            var arrowText = Direction == TransactionDirection.ReceiveFrom ? "<-" : "->";
            return $"{Transaction.TransactionTypeEnum} Transaction {arrowText} {OtherAddress}";
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
