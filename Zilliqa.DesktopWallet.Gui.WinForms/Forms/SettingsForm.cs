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
            textViewblockApiKey.Text = SettingsDat.Instance.ViewBlockApiKey;
        }

        protected override bool OnOk()
        {
            SettingsDat.Instance.ViewBlockApiKey = textViewblockApiKey.Text;
            SettingsDat.Instance.Save();
            return base.OnOk();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            LoadSettings();
        }
    }
}
