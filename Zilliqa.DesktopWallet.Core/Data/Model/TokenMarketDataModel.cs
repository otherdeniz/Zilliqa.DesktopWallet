namespace Zilliqa.DesktopWallet.Core.Data.Model
{
    public class TokenMarketDataModel
    {
        public decimal RateZil { get; set; }

        public decimal RateUsd { get; set; }

        public decimal InitSupply { get; set; }

        public decimal MaxSupply { get; set; }

        public decimal DailyVolumeZil { get; set; }

        public decimal DailyVolumeUsd { get; set; }

        public decimal FullyDilutedValuationZil { get; set; }

        public decimal FullyDilutedValuationUsd { get; set; }

        public decimal CurrentLiquidityZil { get; set; }

        public decimal CurrentLiquidityUsd { get; set; }

        public decimal ChangePercentage24H { get; set; }

        public decimal ChangePercentage7D { get; set; }

    }
}
