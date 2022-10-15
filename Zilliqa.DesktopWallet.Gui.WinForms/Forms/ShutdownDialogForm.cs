using Zilliqa.DesktopWallet.Core.Services;

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
            StartupService.Instance.Shutdown();
            Close();
        }
    }
}
