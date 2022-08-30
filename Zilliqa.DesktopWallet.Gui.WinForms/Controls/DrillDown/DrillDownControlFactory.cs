using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.ViewModel;
using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;
using Zilliqa.DesktopWallet.Gui.WinForms.Controls.Details;
using Zilliqa.DesktopWallet.Gui.WinForms.Controls.Wallet;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.DrillDown
{
    public static class DrillDownControlFactory
    {
        public static Control CreateDisplayControl(object value)
        {
            if (value is AddressValue addressValue)
            {
                var control = new AddressDetailsControl();
                var vm = new AccountViewModel(WatchedAccount.Create(addressValue.Address),
                    _ => control.RefreshAccountSummaries(),
                    false);
                control.BindAccountViewModel(vm, true);
                return control;
            }

            var genericControl = new GenericObjectControl();
            genericControl.LoadGenericViewModel(value);
            return genericControl;
        }
    }
}
