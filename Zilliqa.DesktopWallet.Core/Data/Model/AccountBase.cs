namespace Zilliqa.DesktopWallet.Core.Data.Model
{
    public abstract class AccountBase
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public abstract string GetAddressBech32();

    }
}
