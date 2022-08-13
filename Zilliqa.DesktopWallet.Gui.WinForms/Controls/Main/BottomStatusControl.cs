namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Main
{
    public partial class BottomStatusControl : UserControl
    {
        public BottomStatusControl()
        {
            InitializeComponent();
        }

        public void StopRefresh()
        {
            timerRefresh.Enabled = false;
        }

    }

}
