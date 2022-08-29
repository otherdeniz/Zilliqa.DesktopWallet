using Zilliqa.DesktopWallet.ApiClient;
using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.ViewModel;
using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;
using Zilliqa.DesktopWallet.Gui.WinForms.Controls.Wallet;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.DrillDown
{
    public static class DrillDownControlFactory
    {
        public static bool IsSelectableCell(Type valueType)
        {
            return valueType == typeof(Address)
                   || valueType == typeof(Zrc2TokenValue)
                   || valueType == typeof(BlockNumberValue);
        }

        public static Control CreateDisplayControl(object viewModel)
        {
            if (viewModel is Address addressObject)
            {
                var control = new AddressDetailsControl();
                var vm = new AccountViewModel(WatchedAccount.Create(addressObject),
                    _ => control.RefreshAccountSummaries());
                control.BindAccountViewModel(vm, true);
            }

            return new DrillDownObjectControl();
        }
    }
}
