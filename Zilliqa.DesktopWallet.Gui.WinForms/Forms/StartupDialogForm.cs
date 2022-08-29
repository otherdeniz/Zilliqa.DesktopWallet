using Zilliqa.DesktopWallet.Core.Repository;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    public partial class StartupDialogForm : Form
    {
        public StartupDialogForm()
        {
            InitializeComponent();
        }

        public static bool Execute(Form parent)
        {
            using (var form = new StartupDialogForm())
            {
                return form.ShowDialog(parent) == DialogResult.OK;
            }
        }

        private void timerRefreshStatus_Tick(object sender, EventArgs e)
        {
            if (!RepositoryManager.Instance.CoingeckoRepository.StartupCompleted)
            {
                labelStatus.Text = "Starting Services...";
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
