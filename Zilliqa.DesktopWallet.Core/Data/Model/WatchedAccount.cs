namespace Zilliqa.DesktopWallet.Core.Data.Model
{
    public class WatchedAccount : AccountBase
    {
        public static WatchedAccount Add(string name, string address, bool isMyAccount)
        {
            var result = new WatchedAccount
            {
                Id = Guid.NewGuid().ToString()
            };
            result.Name = name;
            result.Address = address;
            return result;
        }

        public bool IsMyAccount { get; set; }


    }
}
