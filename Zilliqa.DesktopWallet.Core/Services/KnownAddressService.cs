namespace Zilliqa.DesktopWallet.Core.Services
{
    public class KnownAddressService
    {
        public static readonly KnownAddressService Instance = new();

        private KnownAddressService()
        {
        }

        public Dictionary<string, string> Bech32AddressNames { get; } = new();

        public void AddUnique(string bech32, string name)
        {
            if (!Bech32AddressNames.ContainsKey(bech32))
            {
                Bech32AddressNames.Add(bech32, name);
            }
        }
    }
}
