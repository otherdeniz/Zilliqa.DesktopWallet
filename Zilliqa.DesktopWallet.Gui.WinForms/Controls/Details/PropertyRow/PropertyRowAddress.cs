using Zilliqa.DesktopWallet.ApiClient;
using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Details.PropertyRow
{
    public partial class PropertyRowAddress : PropertyRowBase
    {
        public PropertyRowAddress()
        {
            InitializeComponent();
        }

        public void LoadValue(string title, string value)
        {
            LoadValue(title, new Address(value));
        }

        public void LoadValue(string title, AddressValue address)
        {
            LoadValue(title, address.Address);
        }

        public void LoadValue(string title, Address address)
        {
            labelName.Text = title;
            bech32Address.Bech32Address = address.GetBech32();
        }

    }
}
