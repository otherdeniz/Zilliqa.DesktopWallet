using Zillifriends.Shared.Common;
using Zilliqa.DesktopWallet.Core.Data.Model;

namespace Zilliqa.DesktopWallet.Core.Data.Files
{
    [DatFileName("settings.json")]
    public class SettingsFile : DatFileBase
    {
        private static SettingsFile? _instance;

        public static SettingsFile Instance => _instance ??= Load<SettingsFile>(DataPathBuilder.UserDataRoot);

        #region Fields

        public DisplayCurrenciesModel DisplayCurrencies { get; set; } = new();

        public string IncomingSound { get; set; } = IncomingSounds.MoneyCounter;

        public int WhaleNotificationUsd { get; set; } = 10000;

        #endregion

        public static class IncomingSounds
        {
            public static readonly string MoneyCounter = "money-counter";
            public static readonly string KaChing = "ka-ching";
            public static readonly string CoinsInJar = "coins-in-jar";
            public static readonly string CoinDrop = "coin-drop";
        }
    }
}
