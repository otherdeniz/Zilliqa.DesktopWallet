namespace Zilliqa.DesktopWallet.Core.Data.Model
{
    public class WatchedAccount : AccountBase
    {
        public static WatchedAccount Add(string name, string addressBech32, bool isMyAccount)
        {
            var result = new WatchedAccount
            {
                Id = Guid.NewGuid().ToString(),
                Name = name,
                AddressBech32 = addressBech32,
                IsMyAccount = isMyAccount
            };
            return result;
        }

        public string AddressBech32 { get; set; }

        public bool IsMyAccount { get; set; }

        public override string GetAddressBech32()
        {
            return AddressBech32;
        }
    }
}
