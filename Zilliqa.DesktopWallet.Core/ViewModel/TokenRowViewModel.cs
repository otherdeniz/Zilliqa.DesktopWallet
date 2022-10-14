using System.ComponentModel;
using System.Drawing;
using Zillifriends.Shared.Common;
using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;
using Zilliqa.DesktopWallet.ViewModelAttributes;

namespace Zilliqa.DesktopWallet.Core.ViewModel
{
    [GridSearchable(nameof(SearchTerm))]
    public class TokenRowViewModel : IDetailsLabel, IDetailsViewModel
    {
        private readonly TokenModel _model;
        private Image? _icon;

        public TokenRowViewModel(TokenModel model)
        {
            _model = model;
        }

        [Browsable(false)]
        public TokenModel Model => _model;

        [Browsable(false)] 
        public string SearchTerm => $"{Name?.ToLower()}|{Symbol?.ToLower()}";

        [DisplayName(" ")]
        public Image? Icon => _icon ??= _model.Icon.Icon16;

        [DisplayName("Name")]
        [ColumnWidth(120)]
        public string Name => _model.Name;

        [DisplayName("Symbol")]
        [ColumnWidth(60)]
        public string Symbol => _model.Symbol;

        [DisplayName("Created")]
        [GridViewFormat("d")]
        public DateTime? CreatedDate => _model.CreatedDate;

        [DisplayName("Score")]
        public int? Score => _model.CryptometaAsset?.Gen.Score;

        [DisplayName("Price ZIL")]
        [GridViewFormat("#,##0.0000 ZIL")]
        public decimal? PriceZil => _model.PriceZil;

        [DisplayName("Price USD")]
        [GridViewFormat("0.0000 $")]
        [GridViewBackground(KnownColor.Gainsboro)]
        [GridViewDynamicColumn(DynamicColumnCategory.CurrencyUsd)]
        public decimal? PriceUsd => _model.PriceUsd;

        [DisplayName("Market Cap USD")]
        [GridViewFormat("#,##0 $")]
        [GridViewBackground(KnownColor.Gainsboro)]
        [GridViewDynamicColumn(DynamicColumnCategory.CurrencyUsd)]
        public decimal? MarketCapUsd => _model.MarketCapUsd;

        [DisplayName("Price CHF")]
        [GridViewFormat("0.0000 CHF")]
        [GridViewBackground(KnownColor.AliceBlue)]
        [GridViewDynamicColumn(DynamicColumnCategory.CurrencyChf)]
        public decimal? PriceChf => _model.CoinPrice?.MarketData.CurrentPrice.Chf;

        [DisplayName("Price EUR")]
        [GridViewFormat("0.0000 EUR")]
        [GridViewBackground(KnownColor.AliceBlue)]
        [GridViewDynamicColumn(DynamicColumnCategory.CurrencyEur)]
        public decimal? PriceEur => _model.CoinPrice?.MarketData.CurrentPrice.Eur;

        [DisplayName("Price GBP")]
        [GridViewFormat("0.0000 GBP")]
        [GridViewBackground(KnownColor.AliceBlue)]
        [GridViewDynamicColumn(DynamicColumnCategory.CurrencyGbp)]
        public decimal? PriceGbp => _model.CoinPrice?.MarketData.CurrentPrice.Gbp;

        [DisplayName("Price BTC")]
        [GridViewFormat("0.00000000 BTC")]
        [GridViewBackground(KnownColor.Bisque)]
        [GridViewDynamicColumn(DynamicColumnCategory.CurrencyBtc)]
        public decimal? PriceBtc => _model.CoinPrice?.MarketData.CurrentPrice.Btc;

        [DisplayName("Price ETH")]
        [GridViewFormat("0.00000 ETH")]
        [GridViewBackground(KnownColor.SkyBlue)]
        [GridViewDynamicColumn(DynamicColumnCategory.CurrencyEth)]
        public decimal? PriceEth => _model.CoinPrice?.MarketData.CurrentPrice.Eth;

        [DisplayName("Price LTC")]
        [GridViewFormat("0.00000 LTC")]
        [GridViewBackground(KnownColor.LightGray)]
        [GridViewDynamicColumn(DynamicColumnCategory.CurrencyLtc)]
        public decimal? PriceLtc => _model.CoinPrice?.MarketData.CurrentPrice.Ltc;

        [DisplayName("Max Supply")]
        [GridViewFormat("#,##0")]
        public decimal? MaxSupply => _model.MaxSupply;

        [DisplayName("Change 24h")]
        [GridViewFormat("0.00 '%'", UseGreenOrRedNumbers = true)]
        public decimal? ChangePercent24H => _model.CoinPrice?.MarketData.PriceChangePercentage24H;

        [DisplayName("Change 7D")]
        [GridViewFormat("0.00 '%'", UseGreenOrRedNumbers = true)]
        public decimal? ChangePercent7D => _model.CoinPrice?.MarketData.PriceChangePercentage7D;

        [DisplayName("Change 30D")]
        [GridViewFormat("0.00 '%'", UseGreenOrRedNumbers = true)]
        public decimal? ChangePercent30D => _model.CoinPrice?.MarketData.PriceChangePercentage30D;

        [DisplayName("Change 1Y")]
        [GridViewFormat("0.00 '%'", UseGreenOrRedNumbers = true)]
        public decimal? ChangePercent1Y => _model.CoinPrice?.MarketData.PriceChangePercentage1Y;

        public string GetUniqueId()
        {
            return $"Token-{Model.Symbol}";
        }

        public string GetDisplayTitle()
        {
            return $"Token: {Model.Name.TokenNameShort()} ({Model.Symbol.TokenSymbolShort()})";
        }

        public object GetViewModel()
        {
            return new TokenDetailsViewModel(Model);
        }
    }
}
