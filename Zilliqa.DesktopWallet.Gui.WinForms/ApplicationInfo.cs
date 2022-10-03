using Zilliqa.DesktopWallet.ApiClient;

namespace Zilliqa.DesktopWallet.Gui.WinForms
{
    public static class ApplicationInfo
    {
        private static readonly Lazy<decimal> ApplicationVersionLazy = new Lazy<decimal>(() =>
        {
            var assemblyName = typeof(ApplicationInfo).Assembly.GetName();
            return assemblyName.Version == null 
                ? 0.01m 
                : decimal.Parse($"{assemblyName.Version.Major}.{assemblyName.Version.Minor:00}");
        });

        public static string ApplicationName => "Zilliqa Desktop Wallet";

        public static decimal ApplicationVersion => ApplicationVersionLazy.Value;

        public static bool IsBeta => true;

        public static bool IsTestnet => ZilliqaClient.UseTestnet;

        public static string ApplicationVersionText => 
            ApplicationVersion.ToString("0.00") 
            + (IsBeta ? "-BETA" : "");

        public static string NetworkTitle => IsTestnet ? "TESTNET" : "MAINNET";

        public static string MainFormTitle => 
            $"{ApplicationName} by Zillifriends (v{ApplicationVersionText}) - {NetworkTitle}";
    }
}
