namespace Zilliqa.DesktopWallet.WebClient
{
    public class WalletWebClient
    {
        public WalletWebClient(string serverUrl)
        {
            ServerUrl = serverUrl;
        }

        public string ServerUrl { get; }

    }
}