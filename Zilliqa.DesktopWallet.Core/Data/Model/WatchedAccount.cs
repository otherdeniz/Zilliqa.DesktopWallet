using Newtonsoft.Json;
using Zilliqa.DesktopWallet.ApiClient;
using Zilliqa.DesktopWallet.ApiClient.Utils;

namespace Zilliqa.DesktopWallet.Core.Data.Model
{
    public class WatchedAccount : AccountBase
    {
        private Address? _address;
        private string? _addressHex;

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

        [JsonIgnore] 
        public override Address Address => _address ??= new Address(AddressBech32);

        public override string GetAddressBech32()
        {
            return AddressBech32;
        }

        public override string GetAddressHex()
        {
            return _addressHex ??= MusBech32.FromBech32ToBase16Address(AddressBech32, false);
        }
    }
}
