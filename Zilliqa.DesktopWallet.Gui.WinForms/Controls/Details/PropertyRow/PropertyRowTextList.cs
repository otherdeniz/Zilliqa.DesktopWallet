namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Details.PropertyRow
{
    public partial class PropertyRowTextList : PropertyRowBase
    {
        public PropertyRowTextList()
        {
            InitializeComponent();
        }

        public void LoadValue(string title, string[] value)
        {
            labelName.Text = title;
            var textHeigth = 0;
            foreach (var text in value.Reverse())
            {
                var textBox = new TextBox
                {
                    Dock = DockStyle.Top,
                    BorderStyle = BorderStyle.None,
                    ReadOnly = true,
                    BackColor = BackColor,
                    Text = text
                };
                panelValue.Controls.Add(textBox);
                textHeigth += textBox.Height;
            }
            Height = textHeigth == 0 
                ? 24 
                : textHeigth + 8;
        }
    }
}
