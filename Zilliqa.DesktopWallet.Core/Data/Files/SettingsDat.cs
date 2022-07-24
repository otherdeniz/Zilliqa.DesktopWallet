namespace Zilliqa.DesktopWallet.Core.Data.Files
{
    [DatFileName("settings.dat")]
    public class SettingsDat : DatFileBase
    {
        private static SettingsDat? _instance;

        public static SettingsDat Instance => _instance ??= Load<SettingsDat>();

        #region Fields

        public bool UseCustomViewBlockApiKey { get; set; }

        public string ViewBlockApiKey { get; set; } = string.Empty;

        #endregion

    }
}
