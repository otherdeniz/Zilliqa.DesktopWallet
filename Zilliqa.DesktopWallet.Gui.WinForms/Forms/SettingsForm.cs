using Zilliqa.DesktopWallet.Core.Data.Files;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    public partial class SettingsForm : DialogBaseForm
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        public static void Execute(Form parentForm)
        {
            using (var form = new SettingsForm())
            {
                form.ShowDialog(parentForm);
            }
        }

        private void LoadSettings()
        {
            textViewblockApiKey.Text = SettingsFile.Instance.ViewBlockApiKey;
        }

        protected override bool OnOk()
        {
            SettingsFile.Instance.ViewBlockApiKey = textViewblockApiKey.Text;
            SettingsFile.Instance.Save();
            return base.OnOk();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            LoadSettings();
        }
    }
}
