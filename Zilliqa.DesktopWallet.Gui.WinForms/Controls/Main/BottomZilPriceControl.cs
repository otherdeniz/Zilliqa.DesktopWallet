using Zilliqa.DesktopWallet.Core.Api.Coingecko.Model;
using Zilliqa.DesktopWallet.Core.Extensions;
using Zilliqa.DesktopWallet.Core.Repository;
using Zilliqa.DesktopWallet.Core.Services;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Main
{
    public partial class BottomZilPriceControl : DesignableUserControl
    {
        private DateTime? _lastRefreshTimestamp;

        public BottomZilPriceControl()
        {
            InitializeComponent();
        }

        public void StartRefresh()
        {
            timerRefresh.Enabled = true;
        }
        
        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            timerRefresh.Interval = 5000;
            if (_lastRefreshTimestamp == null || _lastRefreshTimestamp.Value < DateTime.Now.AddHours(-1))
            {
                var currentZilPrice = RepositoryManager.Instance.CoingeckoRepository.ZilCoinPrice;
                if (currentZilPrice != null)
                {
                    LoadPrice(currentZilPrice);
                    timerRefresh.Interval = 60000;
                    _lastRefreshTimestamp = DateTime.Now;
                }
            }
        }

        private void LoadPrice(CoinPrice currentZilPrice)
        {
            var priceText = $"{currentZilPrice.MarketData.CurrentPrice.Usd:#,##0.0000} USD";
            var pricePanelHeight = 20;
            if (SettingsService.Instance.CurrentDisplayedCurrencies.DisplayChf)
            {
                priceText += $"\n{currentZilPrice.MarketData.CurrentPrice.Chf:#,##0.0000} CHF";
                pricePanelHeight += 15;
            }
            else if (SettingsService.Instance.CurrentDisplayedCurrencies.DisplayEur)
            {
                priceText += $"\n{currentZilPrice.MarketData.CurrentPrice.Eur:#,##0.0000} EUR";
                pricePanelHeight += 15;
            }
            else if (SettingsService.Instance.CurrentDisplayedCurrencies.DisplayGbp)
            {
                priceText += $"\n{currentZilPrice.MarketData.CurrentPrice.Gbp:#,##0.0000} GBP";
                pricePanelHeight += 15;
            }
            if (SettingsService.Instance.CurrentDisplayedCurrencies.DisplayBtc)
            {
                priceText += $"\n{currentZilPrice.MarketData.CurrentPrice.Btc:0.00000000} BTC";
                pricePanelHeight += 15;
            }
            else if (SettingsService.Instance.CurrentDisplayedCurrencies.DisplayEth)
            {
                priceText += $"\n{currentZilPrice.MarketData.CurrentPrice.Eth:0.00000000} ETH";
                pricePanelHeight += 15;
            }
            else if (SettingsService.Instance.CurrentDisplayedCurrencies.DisplayLtc)
            {
                priceText += $"\n{currentZilPrice.MarketData.CurrentPrice.Ltc:0.00000000} LTC";
                pricePanelHeight += 15;
            }
            textPrice.Text = priceText;
            panelRowPrice.Height = pricePanelHeight;
            textMarketCap.Text = $"{currentZilPrice.MarketData.MarketCap.Usd / 1000000:#,##0}M USD";
            textRank.Text = currentZilPrice.MarketData.MarketCapRank?.ToString();
            pictureSparkline.Image =
                RepositoryManager.Instance.CoingeckoRepository.GetZilSparklineImage();
        }

        private void ServiceOnDisplayCurrenciesChanged(object? sender, EventArgs e)
        {
            var currentZilPrice = RepositoryManager.Instance.CoingeckoRepository.ZilCoinPrice;
            if (currentZilPrice != null)
            {
                LoadPrice(currentZilPrice);
            }
        }

        private void BottomZilPriceControl_Load(object sender, EventArgs e)
        {
            if (!InDesignMode())
            {
                SettingsService.Instance.DisplayCurrenciesChanged += ServiceOnDisplayCurrenciesChanged;
            }
        }

    }
}
