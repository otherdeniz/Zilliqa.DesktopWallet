namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Details.PropertyRow
{
    public partial class PropertyRowButton : PropertyRowBase
    {
        public PropertyRowButton()
        {
            InitializeComponent();
        }

        public void LoadValue(string title, string buttonLabel, Action clickAction)
        {
            labelName.Text = title;
            buttonAction.Text = buttonLabel;
            buttonAction.Click += (sender, args) => clickAction();
        }
    }
}
