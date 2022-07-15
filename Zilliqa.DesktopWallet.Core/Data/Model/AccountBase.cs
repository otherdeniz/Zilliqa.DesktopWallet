using Newtonsoft.Json;
using Zilliqa.DesktopWallet.ApiClient;
using Zilliqa.DesktopWallet.ApiClient.Utils;

namespace Zilliqa.DesktopWallet.Core.Data.Model
{
    public class AccountBase
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        [JsonIgnore] 
        public string AddressBech32 => Address.Base16ToBech32Address();
    }
}
