using Newtonsoft.Json;
using Zillifriends.Shared.Common;
using Zilliqa.DesktopWallet.ApiClient;
using Zilliqa.DesktopWallet.ApiClient.Utils;
using Zilliqa.DesktopWallet.Core.Repository;

namespace Zilliqa.DesktopWallet.Core.Data.Model
{
    public class WatchedAccount : AccountBase
    {
        private Address? _address;
        private string? _addressHex;

        public static WatchedAccount Create(Address address)
        {
            var result = new WatchedAccount
            {
                Id = Guid.NewGuid().ToString(),
                Name = address.GetBech32().FromBech32ToShortReadable(),
                AddressBech32 = address.GetBech32(),
                IsMyAccount = false
            };
            result._address = address;
            return result;
        }

        public static WatchedAccount Create(string name, string addressBech32, bool isMyAccount)
        {
            return new WatchedAccount
            {
                Id = Guid.NewGuid().ToString(),
                Name = name,
                AddressBech32 = addressBech32,
                IsMyAccount = isMyAccount
            };
        }

        public string AddressBech32 { get; set; }

        public bool IsMyAccount { get; set; }

        public override bool PlaySoundOnIncomingTransaction => IsMyAccount;

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
