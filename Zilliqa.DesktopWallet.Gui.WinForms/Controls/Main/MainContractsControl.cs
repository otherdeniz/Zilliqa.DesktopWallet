namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Main
{
    public partial class MainContractsControl : UserControl
    {
        public MainContractsControl()
        {
            InitializeComponent();
        }

        private void timerLoading_Tick(object sender, EventArgs e)
        {
            timerLoading.Enabled = false;

        }

        private void MainContractsControl_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                timerLoading.Enabled = true;
            }
        }
    }
}
