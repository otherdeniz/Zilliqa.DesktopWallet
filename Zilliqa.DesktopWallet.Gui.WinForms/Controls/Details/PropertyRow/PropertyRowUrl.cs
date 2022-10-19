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
            if (title.ToLower() == "facebook")
            {
                return $"https://www.facebook.com/{value}";
            }
            if (title.ToLower() == "linkedin")
            {
                return $"https://www.linkedin.com/company/{value}";
            }
            if (title.ToLower() == "telegram")
            {
                return $"https://t.me/{value}";
            }
            if (title.ToLower() == "github")
            {
                return $"https://github.com/{value}";
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
