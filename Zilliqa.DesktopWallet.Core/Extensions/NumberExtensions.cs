namespace Zilliqa.DesktopWallet.Core.Extensions
{
    public static class NumberExtensions
    {
        public static decimal ZilSatoshisToZil(this decimal zilSatoshis)
        {
            return zilSatoshis / 1000000000000m;
        }

        public static decimal ZilSatoshisToZil(this long zilSatoshis)
        {
            return Convert.ToDecimal(zilSatoshis) / 1000000000000m;
        }

        public static long ZilToZilSatoshis(this decimal zil)
        {
            return Convert.ToInt64(zil * 1000000000000m);
        }
    }
}
