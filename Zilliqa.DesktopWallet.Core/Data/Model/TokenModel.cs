namespace Zilliqa.DesktopWallet.Core.Data.Model
{
    public class TokenModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Symbol { get; set; }

        public string AddressBech32 { get; set; }

        public string IconUrl { get; set; }

        public int Decimals { get; set; }

        public string WebsiteUrl { get; set; }

        public string TelegramUrl { get; set; }

        public string WhitepaperUrl { get; set; }

        public int Score { get; set; }

        public bool Bridged { get; set; }

        public string SupplySkipAddresses { get; set; }

        public TokenMarketDataModel MarketData { get; set; }

        public decimal AmountToDecimal(decimal? amountNumber)
        {
            if (amountNumber == null)
            {
                return 0;
            }
            if (Decimals > 0)
            {
                var divident = Convert.ToDecimal(Math.Pow(10, Decimals));
                return amountNumber.Value / divident;
            }
            return amountNumber.Value;
        }
    }
}
