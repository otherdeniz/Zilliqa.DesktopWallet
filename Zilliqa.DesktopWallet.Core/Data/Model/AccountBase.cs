using Newtonsoft.Json;
using Zilliqa.DesktopWallet.ApiClient;

namespace Zilliqa.DesktopWallet.Core.Data.Model
{
    public abstract class AccountBase
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public virtual bool PlaySoundOnIncomingTransaction => true;

        [JsonIgnore]
        public abstract Address Address { get; }

        public abstract string GetAddressBech32();

        public abstract string GetAddressHex();

    }
}
