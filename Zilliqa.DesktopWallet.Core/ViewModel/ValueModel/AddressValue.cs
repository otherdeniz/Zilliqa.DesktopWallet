using Zilliqa.DesktopWallet.ApiClient;
using Zilliqa.DesktopWallet.Core.Services;

namespace Zilliqa.DesktopWallet.Core.ViewModel.ValueModel
{
    public class AddressValue
    {
        public static AddressValue? Create(string? address)
        {
            if (address == null)
            {
                return null;
            }
            return new AddressValue(address);
        }
        public static AddressValue? Create(Address? address)
        {
            if (address == null)
            {
                return null;
            }
            return new AddressValue(address);
        }

        public AddressValue(string address)
        {
            Address = new Address(address);
        }
        public AddressValue(Address address)
        {
            Address = address;
        }

        public Address Address { get; }

        public override string ToString()
        {
            if (KnownAddressService.Instance.Bech32AddressNames.TryGetValue(Address.GetBech32(), out var addressName))
            {
                if (addressName.Length > 12)
                {
                    addressName = addressName.Substring(0, 12);
                }
                return $"{addressName} ({Address})";
            }
            return Address.ToString();
        }
    }
}
