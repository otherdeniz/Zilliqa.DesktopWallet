using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using Zilliqa.DesktopWallet.Core.Annotations;
using Zilliqa.DesktopWallet.Core.ViewModel.Attributes;
using Zilliqa.DesktopWallet.DatabaseSchema;

namespace Zilliqa.DesktopWallet.Core.ViewModel
{
    public class TransactionRowViewModelBase : INotifyPropertyChanged
    {
        private readonly Transaction _transactionModel;
        //USD
        private decimal? _valueUsdToday;
        private decimal? _valueUsdThen;
        private ValueNumberDisplay? _changeUsd;
        //EUR
        private decimal? _valueEurToday;
        private decimal? _valueEurThen;
        private ValueNumberDisplay? _changeEur;
        //CHF
        private decimal? _valueChfToday;
        private decimal? _valueChfThen;
        private ValueNumberDisplay? _changeChf;
        //GBP
        private decimal? _valueGbpToday;
        private decimal? _valueGbpThen;
        private ValueNumberDisplay? _changeGbp;
        //BTC
        private decimal? _valueBtcToday;
        private decimal? _valueBtcThen;
        private ValueNumberDisplay? _changeBtc;
        //ETH
        private decimal? _valueEthToday;
        private decimal? _valueEthThen;
        private ValueNumberDisplay? _changeEth;
        //LTC
        private decimal? _valueLtcToday;
        private decimal? _valueLtcThen;
        private ValueNumberDisplay? _changeLtc;

        public TransactionRowViewModelBase(Transaction transactionModel)
        {
            _transactionModel = transactionModel;
        }


        public event PropertyChangedEventHandler? PropertyChanged;


        [Browsable(false)]
        public Transaction Transaction => _transactionModel;

        [Browsable(false)] 
        public virtual decimal Amount => 0;

        [Browsable(false)] 
        public virtual string Symbol => "ZIL";

        [DisplayName("USD Today")]
        [GridViewFormat("#,##0.00 $")]
        [GridViewBackground(KnownColor.Gainsboro)]
        public decimal? ValueUsdToday => _valueUsdToday;
        //{
        //    get
        //    {
        //        if (_valueUsdToday == null)
        //        {
        //            var coinHistory = RepositoryManager.Instance.CoingeckoRepository.GetCoinHistory(DateTime.Today, "ZIL", ch =>
        //            {
        //                _valueUsdToday = ch.MarketData.CurrentPrice.Usd * Amount;
        //                _valueBtcToday = ch.MarketData.CurrentPrice.Btc * Amount;
        //                OnPropertyChanged(nameof(ValueUsdToday));
        //                OnPropertyChanged(nameof(ValueBtcToday));
        //                _changeUsd = null;
        //                _changeBtc = null;
        //                OnPropertyChanged(nameof(ChangeUsd));
        //                OnPropertyChanged(nameof(ChangeBtc));
        //                _changeUsdPercent = null;
        //                _changeBtcPercent = null;
        //                OnPropertyChanged(nameof(ChangeUsdPercent));
        //                OnPropertyChanged(nameof(ChangeBtcPercent));
        //            });
        //            if (coinHistory != null)
        //            {
        //                _valueUsdToday = coinHistory.MarketData.CurrentPrice.Usd * Amount;
        //                _valueBtcToday = coinHistory.MarketData.CurrentPrice.Btc * Amount;
        //            }
        //        }
        //        return _valueUsdToday;
        //    }
        //}

        [DisplayName("USD Then")]
        [GridViewFormat("#,##0.00 $")]
        [GridViewBackground(KnownColor.Gainsboro)]
        public decimal? ValueUsdThen => _valueUsdThen;
        //{
        //    get
        //    {
        //        if (_valueUsdThen == null)
        //        {
        //            var coinHistory = RepositoryManager.Instance.CoingeckoRepository.GetCoinHistory(_transactionModel.Timestamp, "ZIL", ch =>
        //            {
        //                _valueUsdThen = ch.MarketData.CurrentPrice.Usd * Amount;
        //                _valueBtcThen = ch.MarketData.CurrentPrice.Btc * Amount;
        //                OnPropertyChanged(nameof(ValueUsdThen));
        //                OnPropertyChanged(nameof(ValueBtcThen));
        //                _changeUsd = null;
        //                _changeBtc = null;
        //                OnPropertyChanged(nameof(ChangeUsd));
        //                OnPropertyChanged(nameof(ChangeBtc));
        //                _changeUsdPercent = null;
        //                _changeBtcPercent = null;
        //                OnPropertyChanged(nameof(ChangeUsdPercent));
        //                OnPropertyChanged(nameof(ChangeBtcPercent));
        //            });
        //            if (coinHistory != null)
        //            {
        //                _valueUsdThen = coinHistory.MarketData.CurrentPrice.Usd * Amount;
        //                _valueBtcThen = coinHistory.MarketData.CurrentPrice.Btc * Amount;
        //            }
        //        }
        //        return _valueUsdThen;
        //    }
        //}

        [DisplayName("USD Change")]
        [GridViewFormat("#,##0.00 $", UseGreenOrRedNumbers = true)]
        [GridViewBackground(KnownColor.Gainsboro)]
        public ValueNumberDisplay? ChangeUsd => _changeUsd;
        //_changeUsd ??=
        //_valueUsdToday != null && _valueUsdThen != null
        //    ? _valueUsdToday - _valueUsdThen
        //    : null;

        [DisplayName("BTC Today")]
        [GridViewFormat("#,##0.00000 BTC")]
        [GridViewBackground(KnownColor.Bisque)]
        [GridViewDynamicColumn(DynamicColumnCategory.CurrencyBtc)]
        public decimal? ValueBtcToday => _valueBtcToday;

        [DisplayName("BTC Then")]
        [GridViewFormat("#,##0.00000 BTC")]
        [GridViewBackground(KnownColor.Bisque)]
        [GridViewDynamicColumn(DynamicColumnCategory.CurrencyBtc)]
        public decimal? ValueBtcThen => _valueBtcThen;

        [DisplayName("BTC Change")]
        [GridViewFormat("#,##0.00000 BTC", UseGreenOrRedNumbers = true)]
        [GridViewBackground(KnownColor.Bisque)]
        [GridViewDynamicColumn(DynamicColumnCategory.CurrencyBtc)]
        public ValueNumberDisplay? ChangeBtc => _changeBtc;
        //_changeBtc ??=
        //_valueBtcToday != null && _valueBtcThen != null
        //    ? _valueBtcToday - _valueBtcThen
        //    : null;

        [DisplayName("ETH Today")]
        [GridViewFormat("#,##0.00000 ETH")]
        [GridViewBackground(KnownColor.SkyBlue)]
        [GridViewDynamicColumn(DynamicColumnCategory.CurrencyEth)]
        public decimal? ValueEthToday => _valueEthToday;

        [DisplayName("ETH Then")]
        [GridViewFormat("#,##0.00000 ETH")]
        [GridViewBackground(KnownColor.SkyBlue)]
        [GridViewDynamicColumn(DynamicColumnCategory.CurrencyEth)]
        public decimal? ValueEthThen => _valueEthThen;

        [DisplayName("ETH Change")]
        [GridViewFormat("#,##0.00000 ETH", UseGreenOrRedNumbers = true)]
        [GridViewBackground(KnownColor.SkyBlue)]
        [GridViewDynamicColumn(DynamicColumnCategory.CurrencyEth)]
        public ValueNumberDisplay? ChangeEth => _changeEth;

        [DisplayName("LTC Today")]
        [GridViewFormat("#,##0.00000 LTC")]
        [GridViewBackground(KnownColor.LightGray)]
        [GridViewDynamicColumn(DynamicColumnCategory.CurrencyLtc)]
        public decimal? ValueLtcToday => _valueLtcToday;

        [DisplayName("LTC Then")]
        [GridViewFormat("#,##0.00000 LTC")]
        [GridViewBackground(KnownColor.LightGray)]
        [GridViewDynamicColumn(DynamicColumnCategory.CurrencyLtc)]
        public decimal? ValueLtcThen => _valueLtcThen;

        [DisplayName("LTC Change")]
        [GridViewFormat("#,##0.00000 LTC", UseGreenOrRedNumbers = true)]
        [GridViewBackground(KnownColor.LightGray)]
        [GridViewDynamicColumn(DynamicColumnCategory.CurrencyLtc)]
        public ValueNumberDisplay? ChangeLtc => _changeLtc;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            WinFormsSynchronisationContext.ExecuteSynchronized(() =>
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            });
        }

    }
}
