using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using Zilliqa.DesktopWallet.ApiClient;
using Zilliqa.DesktopWallet.Core.Annotations;
using Zilliqa.DesktopWallet.Core.Extensions;
using Zilliqa.DesktopWallet.Core.Repository;
using Zilliqa.DesktopWallet.Core.ViewModel.Attributes;
using Zilliqa.DesktopWallet.DatabaseSchema;

namespace Zilliqa.DesktopWallet.Core.ViewModel
{
    public class ZilTransactionRowViewModel : INotifyPropertyChanged
    {
        private readonly Transaction _transactionModel;
        private Image? _directionIcon;
        private string? _otherAddress;
        private decimal? _zilAmount;
        private decimal? _fee;
        private string? _date;
        private decimal? _valueUsdToday;
        private decimal? _valueUsdThen;
        private decimal? _changeUsd;
        private decimal? _changeUsdPercent;
        private decimal? _valueBtcToday;
        private decimal? _valueBtcThen;
        private decimal? _changeBtc;
        private decimal? _changeBtcPercent;

        public ZilTransactionRowViewModel(Address thisAddress, Transaction transactionModel)
        {
            _transactionModel = transactionModel;
            ThisAddress = thisAddress;
            Direction = thisAddress.Equals(transactionModel.SenderAddress)
                ? TransactionDirection.SendTo
                : TransactionDirection.ReceiveFrom;
        }

        [Browsable(false)] 
        public Transaction Transaction => _transactionModel;

        [Browsable(false)]
        public TransactionDirection Direction { get; }

        [Browsable(false)]
        public Address ThisAddress { get; }

        [DisplayName(" ")]
        public Image? DirectionIcon => _directionIcon ??= Direction == TransactionDirection.SendTo
            ? IconResources.ArrowRight16
            : IconResources.ArrowLeft16;

        [DisplayName("Direction")]
        public string DirectionLabel => Direction == TransactionDirection.SendTo 
            ? "send to" 
            : "receive from";

        [DisplayName("Address")]
        public string OtherAddress => _otherAddress ??= Direction == TransactionDirection.SendTo
            ? GetAddressDisplay(_transactionModel.ToAddress)
            : GetAddressDisplay(_transactionModel.SenderAddress);

        [GridViewFormat("#,##0.0000 ZIL")]
        public decimal Amount => _zilAmount ??= _transactionModel.Amount.ZilSatoshisToZil();

        [GridViewFormat("0.0000 ZIL")]
        public decimal Fee => _fee ??= _transactionModel.GasPrice.ZilSatoshisToZil();

        //public decimal Fee
        public string Date => _date ??= _transactionModel.Timestamp.ToLocalTime().ToString("g");

        [DisplayName("USD Today")]
        [GridViewFormat("#,##0.00 $")]
        [GridViewBackground(KnownColor.LightBlue)]
        public decimal? ValueUsdToday
        {
            get
            {
                if (_valueUsdToday == null)
                {
                    var coinHistory = RepositoryManager.Instance.CoingeckoRepository.GetCoinHistory(DateTime.Today, "ZIL", ch =>
                    {
                        _valueUsdToday = ch.MarketData.CurrentPrice.Usd * Amount;
                        _valueBtcToday = ch.MarketData.CurrentPrice.Btc * Amount;
                        OnPropertyChanged(nameof(ValueUsdToday));
                        OnPropertyChanged(nameof(ValueBtcToday));
                        _changeUsd = null;
                        _changeBtc = null;
                        OnPropertyChanged(nameof(ChangeUsd));
                        OnPropertyChanged(nameof(ChangeBtc));
                        _changeUsdPercent = null;
                        _changeBtcPercent = null;
                        OnPropertyChanged(nameof(ChangeUsdPercent));
                        OnPropertyChanged(nameof(ChangeBtcPercent));
                    });
                    if (coinHistory != null)
                    {
                        _valueUsdToday = coinHistory.MarketData.CurrentPrice.Usd * Amount;
                        _valueBtcToday = coinHistory.MarketData.CurrentPrice.Btc * Amount;
                    }
                }
                return _valueUsdToday;
            }
        }

        [DisplayName("USD Then")]
        [GridViewFormat("#,##0.00 $")]
        [GridViewBackground(KnownColor.LightBlue)]
        public decimal? ValueUsdThen
        {
            get
            {
                if (_valueUsdThen == null)
                {
                    var coinHistory = RepositoryManager.Instance.CoingeckoRepository.GetCoinHistory(_transactionModel.Timestamp, "ZIL", ch =>
                    {
                        _valueUsdThen = ch.MarketData.CurrentPrice.Usd * Amount;
                        _valueBtcThen = ch.MarketData.CurrentPrice.Btc * Amount;
                        OnPropertyChanged(nameof(ValueUsdThen));
                        OnPropertyChanged(nameof(ValueBtcThen));
                        _changeUsd = null;
                        _changeBtc = null;
                        OnPropertyChanged(nameof(ChangeUsd));
                        OnPropertyChanged(nameof(ChangeBtc));
                        _changeUsdPercent = null;
                        _changeBtcPercent = null;
                        OnPropertyChanged(nameof(ChangeUsdPercent));
                        OnPropertyChanged(nameof(ChangeBtcPercent));
                    });
                    if (coinHistory != null)
                    {
                        _valueUsdThen = coinHistory.MarketData.CurrentPrice.Usd * Amount;
                        _valueBtcThen = coinHistory.MarketData.CurrentPrice.Btc * Amount;
                    }
                }
                return _valueUsdThen;
            }
        }

        [DisplayName("USD Change")]
        [GridViewFormat("#,##0.00 $", UseGreenOrRedNumbers = true)]
        [GridViewBackground(KnownColor.LightBlue)]
        public decimal? ChangeUsd => _changeUsd ??= 
            _valueUsdToday != null && _valueUsdThen != null 
                ? _valueUsdToday - _valueUsdThen 
                : null;

        [DisplayName("USD Change %")]
        [GridViewFormat("0.00 '%'", UseGreenOrRedNumbers = true)]
        [GridViewBackground(KnownColor.LightBlue)]
        public decimal? ChangeUsdPercent => _changeUsdPercent ??=
            _valueUsdThen != null && _changeUsd != null
                ? 100m / _valueUsdThen * _changeUsd
                : null;

        [DisplayName("BTC Today")]
        [GridViewFormat("#,##0.00000 BTC")]
        [GridViewBackground(KnownColor.Bisque)]
        public decimal? ValueBtcToday => _valueBtcToday;

        [DisplayName("BTC Then")]
        [GridViewFormat("#,##0.00000 BTC")]
        [GridViewBackground(KnownColor.Bisque)]
        public decimal? ValueBtcThen => _valueBtcThen;

        [DisplayName("BTC Change")]
        [GridViewFormat("#,##0.00000 BTC", UseGreenOrRedNumbers = true)]
        [GridViewBackground(KnownColor.Bisque)]
        public decimal? ChangeBtc => _changeBtc ??=
            _valueBtcToday != null && _valueBtcThen != null
                ? _valueBtcToday - _valueBtcThen
                : null;

        [DisplayName("BTC Change %")]
        [GridViewFormat("0.00 '%'", UseGreenOrRedNumbers = true)]
        [GridViewBackground(KnownColor.Bisque)]
        public decimal? ChangeBtcPercent => _changeBtcPercent ??=
            _valueBtcThen != null && _changeBtc != null
                ? 100m / _valueBtcThen * _changeBtc
                : null;

        private string GetAddressDisplay(string rawAddress)
        {
            return new Address(rawAddress).GetBech32().FromBech32ToShortReadable();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            WinFormsSynchronisationContext.ExecuteSynchronized(() =>
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            });
        }
    }

    public enum TransactionDirection
    {
        SendTo = 1,
        ReceiveFrom = 2
    }
}
