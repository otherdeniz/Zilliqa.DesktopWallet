using Zilliqa.DesktopWallet.Core.Repository;
using Zilliqa.DesktopWallet.Core.ZilligraphDb;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    public partial class ShutdownDialogForm : Form
    {
        public ShutdownDialogForm()
        {
            InitializeComponent();
        }

        private void timerShutdown_Tick(object sender, EventArgs e)
        {
            timerShutdown.Enabled = false;
            ZilliqaBlockchainCrawler.Instance.Stop(true);
            RepositoryManager.Instance.Shutdown();
            Close();
        }
    }
}
