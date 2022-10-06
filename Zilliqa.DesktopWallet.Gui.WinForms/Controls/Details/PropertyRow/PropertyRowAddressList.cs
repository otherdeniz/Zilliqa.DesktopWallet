using Zilliqa.DesktopWallet.ApiClient;
using Zilliqa.DesktopWallet.Gui.WinForms.Controls.Values;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Details.PropertyRow
{
    public partial class PropertyRowAddressList : PropertyRowBase
    {
        public PropertyRowAddressList()
        {
            InitializeComponent();
        }

        public void LoadValue(string title, string[] value)
        {
            labelName.Text = title;
            var textHeigth = 0;
            foreach (var text in value.Reverse())
            {
                var addressValue = new Address(text);
                var bech32AddressLabel = new Bech32AddressLabel
                {
                    Dock = DockStyle.Top,
                    BorderStyle = BorderStyle.None,
                    BackColor = BackColor,
                    Bech32Address = addressValue.GetBech32()
                };
                panelValue.Controls.Add(bech32AddressLabel);
                textHeigth += bech32AddressLabel.Height;
            }
            Height = textHeigth + 4;
        }

    }
}
