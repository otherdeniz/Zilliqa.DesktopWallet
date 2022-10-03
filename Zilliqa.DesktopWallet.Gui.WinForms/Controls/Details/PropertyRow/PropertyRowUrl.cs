using System.Diagnostics;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Details.PropertyRow
{
    public partial class PropertyRowUrl : PropertyRowBase
    {
        public PropertyRowUrl()
        {
            InitializeComponent();
        }

        public void LoadValue(string title, string value)
        {
            labelName.Text = title;
            linkLabelUrl.Text = FixUrl(title, value);
        }

        private string FixUrl(string title, string value)
        {
            if (value.StartsWith("http")) return value;
            if (title.ToLower() == "twitter")
            {
                return $"https://twitter.com/{value}";
            }
            return value;
        }

        private void linkLabelUrl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (linkLabelUrl.Text.StartsWith("http"))
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = linkLabelUrl.Text,
                    UseShellExecute = true
                });
            }
        }
    }
}
