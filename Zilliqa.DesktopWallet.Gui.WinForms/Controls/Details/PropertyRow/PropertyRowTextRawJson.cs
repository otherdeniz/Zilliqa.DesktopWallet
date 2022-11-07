using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Zilliqa.DesktopWallet.Gui.WinForms.Forms;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Details.PropertyRow
{
    public partial class PropertyRowTextRawJson : PropertyRowBase
    {
        private string? _rawJsonText;

        public PropertyRowTextRawJson()
        {
            InitializeComponent();
        }

        public void LoadValue(string title, string valueDisplay, JToken rawJson)
        {
            labelName.Text = title;
            textValue.Text = valueDisplay;
            _rawJsonText = rawJson.ToString(Formatting.Indented);
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_rawJsonText))
            {
                DisplayRawJsonForm.ExecuteShow(this.ParentForm!, _rawJsonText);
            }
        }
    }
}
