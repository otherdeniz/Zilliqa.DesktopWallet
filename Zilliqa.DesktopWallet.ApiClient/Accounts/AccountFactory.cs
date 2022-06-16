namespace Zilliqa.DesktopWallet.ApiClient.Accounts
{
    public static class AccountFactory
    {
        public static Account New(string pk)
        {
            return new Account(pk);
        }
        public static Account FromJsonFile(string file, string passPhrase)
        {
            return new Account(file, passPhrase);
        }
    }
}
