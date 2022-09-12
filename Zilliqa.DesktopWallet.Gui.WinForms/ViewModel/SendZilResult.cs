using Zilliqa.DesktopWallet.Core.ViewModel;
using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;

namespace Zilliqa.DesktopWallet.Gui.WinForms.ViewModel
{
    public class SendZilResult
    {
        public PasswordInfo Password { get; set; }

        public AddressValue ToAddress { get; set; }

        public decimal Amount { get; set; }

    }
}
