using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using Zillifriends.Shared.Common;
using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.Repository;
using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;
using Zilliqa.DesktopWallet.ViewModelAttributes;

namespace Zilliqa.DesktopWallet.Core.ViewModel
{
    public class TokenBalanceRowViewModel : INotifyPropertyChanged, IDetailsLabel, IDetailsViewModel
    {
        private Image? _icon;

        public TokenBalanceRowViewModel(TokenModelByAddress tokenModelByAddress)
        {
            Model = tokenModelByAddress;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        [Browsable(false)]
        public TokenModelByAddress Model { get; }

        [DisplayName(" ")]
        public Image? Icon => _icon ??= Model.TokenModel.Icon.Icon16;

        [DisplayName("Token")]
        public string TokenTitle =>
            $"{Model.TokenModel.Name.TokenNameShort()} ({Model.TokenModel.Symbol.TokenSymbolShort()})"
            + (Model.TokenIndex > 1
                ? $" #{Model.TokenIndex}"
                : "");

        public AddressValue Address => new AddressValue(Model.ContractAddressBech32, false);

        [Browsable(false)]
        public decimal Balance { get; set; }

        [Browsable(false)] 
        public decimal BalanceValue => (Balance < 0 ? 0 : Balance);

        [DisplayName("Balance")]
        public string BalanceDisplay => $"{BalanceValue:#,##0.0000} {Model.TokenModel.Symbol.TokenSymbolShort()}";

        public int Transactions { get; set; }

        //[DisplayName("Value ZIL")]
        //[GridViewFormat("#,##0.00 ZIL")]
        //[GridViewBackground(243, 255, 243)]
        //public decimal? ValueZil { get; private set; }

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

        public void UpdateValuesProperties(bool notifiyPropertyChanged, Action? propertiesChangedAction = null)
        {
            //ValueZil = Model.MarketData.RateZil * BalanceValue;
            RepositoryManager.Instance.CoingeckoRepository.GetCoinPrice(Model.TokenModel.Symbol, cp =>
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
                        //OnPropertyChanged(nameof(ValueZil));
                        OnPropertyChanged(nameof(ValueUsd));
                        OnPropertyChanged(nameof(ValueChf));
                        OnPropertyChanged(nameof(ValueEur));
                        OnPropertyChanged(nameof(ValueGbp));
                        OnPropertyChanged(nameof(ValueBtc));
                        OnPropertyChanged(nameof(ValueEth));
                        OnPropertyChanged(nameof(ValueLtc));
                    });
                }
                propertiesChangedAction?.Invoke();
            });
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string GetUniqueId()
        {
            return $"Token-{Model.TokenModel.Symbol}";
        }

        public string GetDisplayTitle()
        {
            return $"Token: {Model.TokenModel.Name.TokenNameShort()} ({Model.TokenModel.Symbol.TokenSymbolShort()})";
        }

        public object GetViewModel()
        {
            return new TokenDetailsViewModel(Model.TokenModel);
        }
    }
}
