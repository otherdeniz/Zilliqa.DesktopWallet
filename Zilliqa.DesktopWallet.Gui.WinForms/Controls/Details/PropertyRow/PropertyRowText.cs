namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Details.PropertyRow
{
    public partial class PropertyRowText : PropertyRowBase
    {
        public PropertyRowText()
        {
            InitializeComponent();
        }

        public void LoadValue(string title, string value)
        {
            labelName.Text = title;
            textValue.Text = value;
        }
    }
}
