using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;

namespace Zilliqa.DesktopWallet.Gui.WinForms.ViewModel
{
    public class StakingStakeResult : DialogWithPasswordResult
    {
        public AddressValue SsnAddress { get; set; }

        public decimal Amount { get; set; }

    }
}
