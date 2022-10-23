namespace Zilliqa.DesktopWallet.Server.Core
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

        public static decimal ApplicationVersion => ApplicationVersionLazy.Value;

    }
}
