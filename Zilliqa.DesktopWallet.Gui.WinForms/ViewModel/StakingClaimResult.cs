using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;

namespace Zilliqa.DesktopWallet.Gui.WinForms.ViewModel;

public class StakingClaimResult : DialogWithPasswordResult
{
    public List<AddressValue> SsnAddressList { get; set; }

}