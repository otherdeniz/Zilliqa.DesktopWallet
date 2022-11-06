using System.Text;

namespace Zillifriends.Shared.Common
{
    public static class StringExtensions
    {
        private const long MB_VALUE = 1048576;
        private const long GB_VALUE = 1073741824;

        public static string BytesToReadable(this long byteCount)
        {
            if (byteCount < 1024)
            {
                return $"{byteCount} Bytes";
            }

            if (byteCount < MB_VALUE)
            {
                var kb = Convert.ToDouble(byteCount) / 1024d;
                return $"{kb:0.00} KB";
            }

            if (byteCount < GB_VALUE)
            {
                var mb = Convert.ToDouble(byteCount) / Convert.ToDouble(MB_VALUE);
                return $"{mb:0.00} MB";
            }

            var gb = Convert.ToDouble(byteCount) / Convert.ToDouble(GB_VALUE);
            return $"{gb:#,##0.000} GB";
        }

        public static DateTime UnixTimestampToDateTime(this string timestamp)
        {
            if (long.TryParse(timestamp, out var longValue))
            {
                var date = DateTimeOffset.FromUnixTimeMilliseconds(longValue / 1000);
                return date.DateTime;
            }

            return DateTime.UnixEpoch;
        }

        public static string FromBech32ToShortReadable(this string bech32)
        {
            if (bech32.Length > 10)
            {
                return $"{bech32.Substring(0, 4)} {bech32.Substring(4, 3)}...{bech32.Substring(bech32.Length - 3, 3)}";
            }

            return bech32;
        }


        public static string GetTimeAgoText(this DateTime localDateTime)
        {
            var diffTime = DateTime.Now - localDateTime;
            string timeAgoText;
            if (diffTime.TotalDays > 1)
            {
                timeAgoText = $"{diffTime.TotalDays:0.0} days";
            }
            else if (diffTime.TotalHours > 1)
            {
                timeAgoText = $"{diffTime.TotalHours:0.0} hours";
            }
            else if (diffTime.TotalMinutes > 1)
            {
                timeAgoText = $"{diffTime.TotalMinutes:0.0} minutes";
            }
            else
            {
                timeAgoText = $"{diffTime.TotalSeconds:0} seconds";
            }
            return timeAgoText;
        }

        public static string FromTransactionHexToShortReadable(this string transactionHex)
        {
            if (transactionHex.Length == 64)
            {
                return $"{transactionHex.Substring(0, 4)}...{transactionHex.Substring(transactionHex.Length - 4, 4)}";
            }

            return transactionHex;
        }

        public static string? TokenNameShort(this string? tokenName)
        {
            if (tokenName?.Length > 20)
            {
                return $"{tokenName[..20]}...";
            }
            return tokenName;
        }

        public static string? TokenSymbolShort(this string? tokenSymbol)
        {
            if (tokenSymbol?.Length > 8)
            {
                return $"{tokenSymbol[..8]}...";
            }
            return tokenSymbol;
        }

    }
}
