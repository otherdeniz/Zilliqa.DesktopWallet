using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Values.Arguments
{
    public partial class ArgumentEditAddressControl : ArgumentEditBaseControl
    {
        public ArgumentEditAddressControl()
        {
            InitializeComponent();
        }

        public override string ArgumentValue
        {
            get => addressTextBox.Address?.Address.GetBase16(true) ?? "";
            set => addressTextBox.Address = AddressValue.TryParse(value, out var addressValue) ? addressValue : null;
        }

        private void addressTextBox_AddressChanged(object sender, EventArgs e)
        {
            IsValid = addressTextBox.Address != null;
            RaiseArgumentValueChanged();
        }
    }
}
