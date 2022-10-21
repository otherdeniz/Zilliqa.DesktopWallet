namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Values.Arguments
{
    public partial class ArgumentEditAddressControl : ArgumentEditBaseControl
    {
        public ArgumentEditAddressControl()
        {
            InitializeComponent();
        }

        private void addressTextBox_AddressChanged(object sender, EventArgs e)
        {
            IsValid = addressTextBox.Address != null;
            RaiseArgumentValueChanged();
        }
    }
}
