using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.Extensions;
using Zilliqa.DesktopWallet.Core.Repository;
using Zilliqa.DesktopWallet.Core.ViewModel.Attributes;

namespace Zilliqa.DesktopWallet.Core.ViewModel
{
    public class TokenBalanceRowViewModel : INotifyPropertyChanged
    {
        private Image? _icon;
        private decimal _balance;
        private int _transactions;

        public TokenBalanceRowViewModel(TokenModel tokenModel)
        {
            Model = tokenModel;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        [Browsable(false)]
        public TokenModel Model { get; }

        [DisplayName(" ")]
        public Image? Icon => _icon ??= Model.GetTokenIcon().Icon16;

        public string Token => $"{Model.Name} ({Model.Symbol})";

        [Browsable(false)]
        public decimal Balance
        {
            get => _balance;
            set
            {
                _balance = value;
            }
        }

        [Browsable(false)] 
        public decimal BalanceValue => (Balance < 0 ? 0 : Balance);

        [DisplayName("Balance")]
        public string BalanceDisplay => $"{BalanceValue:#,##0.0000} {Model.Symbol}";

        public int Transactions
        {
            get => _transactions;
            set
            {
                _transactions = value;
            }
        }

        [DisplayName("Value ZIL")]
        [GridViewFormat("#,##0.00 ZIL")]
        [GridViewBackground(243, 255, 243)]
        public decimal? ValueZil { get; private set; }

        [DisplayName("Value USD")]
        [GridViewFormat("#,##0.00 $")]
        [GridViewBackground(KnownColor.Gainsboro)]
        public decimal? ValueUsd { get; private set; }

        [DisplayName("Value CHF")]
        [GridViewFormat("#,##0.00 CHF")]
        [GridViewBackground(KnownColor.AliceBlue)]
        [GridViewDynamicColumn(DynamicColumnCategory.CurrencyChf)]
        public decimal? ValueChf { get; private set; }

        [DisplayName("Value EUR")]
        [GridViewFormat("#,##0.00 EUR")]
        [GridViewBackground(KnownColor.AliceBlue)]
        [GridViewDynamicColumn(DynamicColumnCategory.CurrencyEur)]
        public decimal? ValueEur { get; private set; }

        [DisplayName("Value GBP")]
        [GridViewFormat("#,##0.00 GBP")]
        [GridViewBackground(KnownColor.AliceBlue)]
        [GridViewDynamicColumn(DynamicColumnCategory.CurrencyGbp)]
        public decimal? ValueGbp { get; private set; }

        [DisplayName("Value BTC")]
        [GridViewFormat("#,##0.00000000 BTC")]
        [GridViewBackground(KnownColor.Bisque)]
        [GridViewDynamicColumn(DynamicColumnCategory.CurrencyBtc)]
        public decimal? ValueBtc { get; private set; }

        [DisplayName("Value EUR")]
        [GridViewFormat("#,##0.00000 ETH")]
        [GridViewBackground(KnownColor.SkyBlue)]
        [GridViewDynamicColumn(DynamicColumnCategory.CurrencyEth)]
        public decimal? ValueEth { get; private set; }

        [DisplayName("Value LTC")]
        [GridViewFormat("#,##0.00000 LTC")]
        [GridViewBackground(KnownColor.LightGray)]
        [GridViewDynamicColumn(DynamicColumnCategory.CurrencyLtc)]
        public decimal? ValueLtc { get; private set; }

        public void UpdateValuesProperties(bool notifiyPropertyChanged)
        {
            ValueZil = Model.MarketData.RateZil * BalanceValue;
            RepositoryManager.Instance.CoingeckoRepository.GetCoinPrice(Model.Symbol, cp =>
            {
                ValueUsd = cp.MarketData.CurrentPrice.Usd * BalanceValue;
                ValueChf = cp.MarketData.CurrentPrice.Chf * BalanceValue;
                ValueEur = cp.MarketData.CurrentPrice.Eur * BalanceValue;
                ValueGbp = cp.MarketData.CurrentPrice.Gbp * BalanceValue;
                ValueBtc = cp.MarketData.CurrentPrice.Btc * BalanceValue;
                ValueEth = cp.MarketData.CurrentPrice.Eth * BalanceValue;
                ValueLtc = cp.MarketData.CurrentPrice.Ltc * BalanceValue;
                if (notifiyPropertyChanged)
                {
                    WinFormsSynchronisationContext.ExecuteSynchronized(() =>
                    {
                        OnPropertyChanged(nameof(Transactions));
                        OnPropertyChanged(nameof(BalanceDisplay));
                        OnPropertyChanged(nameof(ValueZil));
                        OnPropertyChanged(nameof(ValueUsd));
                        OnPropertyChanged(nameof(ValueChf));
                        OnPropertyChanged(nameof(ValueEur));
                        OnPropertyChanged(nameof(ValueGbp));
                        OnPropertyChanged(nameof(ValueBtc));
                        OnPropertyChanged(nameof(ValueEth));
                        OnPropertyChanged(nameof(ValueLtc));
                    });
                }
            });
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
