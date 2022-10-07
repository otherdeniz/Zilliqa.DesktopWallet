using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    public partial class AddressConverterToolForm : Form
    {
        public AddressConverterToolForm()
        {
            InitializeComponent();
        }

        private void textInput_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textInput.Text))
            {
                labelNotValid.Visible = false;
                bech32AddressLabel.Visible = false;
                textBech32.Text = "";
                textHex.Text = "";
            }
            else
            {
                if (AddressValue.TryParse(textInput.Text, out var addressValue))
                {
                    labelNotValid.Visible = false;
                    bech32AddressLabel.Visible = true;
                    bech32AddressLabel.Bech32Address = addressValue!.Address.GetBech32();
                    textBech32.Text = addressValue!.Address.GetBech32();
                    textHex.Text = addressValue!.Address.GetBase16(true);
                }
                else
                {
                    labelNotValid.Visible = true;
                    bech32AddressLabel.Visible = false;
                    textBech32.Text = "";
                    textHex.Text = "";
                }
            }
        }
    }
}
