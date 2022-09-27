using Zillifriends.Shared.Common;
using Zilliqa.DesktopWallet.Core.Data.Model;

namespace Zilliqa.DesktopWallet.Core.Data.Files
{
    [DatFileName("settings.json")]
    public class SettingsFile : DatFileBase
    {
        private static SettingsFile? _instance;

        public static SettingsFile Instance => _instance ??= Load<SettingsFile>();

        #region Fields

        public bool UseCustomViewBlockApiKey { get; set; }

        public string ViewBlockApiKey { get; set; } = string.Empty;

        public DisplayCurrenciesModel DisplayCurrencies { get; set; } = new();

        #endregion

    }
}
