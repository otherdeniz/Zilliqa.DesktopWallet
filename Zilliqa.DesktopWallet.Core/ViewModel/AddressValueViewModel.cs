using Zilliqa.DesktopWallet.ApiClient;
using Zilliqa.DesktopWallet.Core.Extensions;

namespace Zilliqa.DesktopWallet.Core.ViewModel
{
    public class AddressValueViewModel
    {
        public AddressValueViewModel(Address? address)
        {
            Address = address;
        }

        public AddressValueViewModel(string? address)
        {
            if (address != null)
            {
                Address = new Address(address);
            }
        }

        public Address? Address { get; }

        public override string ToString()
        {
            return Address?.GetBech32().FromBech32ToShortReadable() 
                   ?? "";
        }
    }
}
