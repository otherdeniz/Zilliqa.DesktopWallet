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
                var bech32Address = new Bech32AddressLabel
                {
                    Dock = DockStyle.Top,
                    BorderStyle = BorderStyle.None,
                    BackColor = BackColor,
                    Bech32Address = text
                };
                panelValue.Controls.Add(bech32Address);
                textHeigth += bech32Address.Height;
            }
            Height = textHeigth + 4;
        }

    }
}
