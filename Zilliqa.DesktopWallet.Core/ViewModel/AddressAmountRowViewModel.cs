using System.ComponentModel;
using Zilliqa.DesktopWallet.ApiClient;
using Zilliqa.DesktopWallet.ApiClient.Utils;
using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;
using Zilliqa.DesktopWallet.ViewModelAttributes;

namespace Zilliqa.DesktopWallet.Core.ViewModel
{
    public class AddressAmountRowViewModel : IDetailsLabel, IDetailsViewModel
    {
        public AddressAmountRowViewModel(string addressHex, decimal amount, decimal share)
        {
            AddressHex = addressHex;
            AddressText = new AddressValue(addressHex).ToString();
            Amount = amount;
            Share = share;
        }

        [Browsable(false)] 
        public string AddressHex { get; }

        [DisplayName("Address")] 
        public string AddressText { get; }

        [GridViewFormat("#,##0.0000")] 
        public decimal Amount { get; }

        [GridViewFormat("0.000 '%'")]
        public decimal Share { get; }

        public object GetViewModel()
        {
            return new AccountViewModel(WatchedAccount.Create(new Address(AddressHex)));
        }

        public string GetUniqueId()
        {
            return $"Addr-{AddressHex.FromBase16ToBech32Address()}";
        }

        public string GetDisplayTitle()
        {
            return $"Address: {new Address(AddressHex)}";
        }
    }
}
