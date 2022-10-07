using System.ComponentModel;
using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;
using Zilliqa.DesktopWallet.ViewModelAttributes;

namespace Zilliqa.DesktopWallet.Core.ViewModel
{
    public class AddressAmountRowViewModel
    {
        public AddressAmountRowViewModel(string addressHex, decimal amount)
        {
            AddressHex = addressHex;
            AddressText = new AddressValue(addressHex).ToString();
            Amount = amount;
        }

        [Browsable(false)]
        public string AddressHex { get; }

        [DisplayName("Address")]
        public string AddressText { get; }

        [GridViewFormat("#,##0.0000")]
        public decimal Amount { get; }
    }
}
