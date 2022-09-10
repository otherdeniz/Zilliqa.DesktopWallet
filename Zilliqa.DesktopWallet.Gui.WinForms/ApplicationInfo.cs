namespace Zilliqa.DesktopWallet.Gui.WinForms
{
    public static class ApplicationInfo
    {
        public static readonly string ApplicationName = "Zilliqa Desktop Wallet";

        public static readonly decimal ApplicationVersion = 1.17m;

        public static readonly bool IsBeta = true;

        public static bool IsTestnet { get; set; }

        public static string ApplicationVersionText => 
            ApplicationVersion.ToString("0.00") 
            + (IsBeta ? "-BETA" : "");

        public static string NetworkTitle => IsTestnet ? "TESTNET" : "MAINNET";

        public static string MainFormTitle => 
            $"{ApplicationName} (v{ApplicationVersionText}) - {NetworkTitle}";
    }
}
