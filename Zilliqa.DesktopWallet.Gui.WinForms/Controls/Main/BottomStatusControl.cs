using Zilliqa.DesktopWallet.Gui.WinForms.Forms;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Main
{
    public partial class BottomStatusControl : HighlitableBaseControl
    {
        public BottomStatusControl()
        {
            InitializeComponent();
        }

        public void StopRefresh()
        {
            timerRefresh.Enabled = false;
        }

        protected override void ClickAction()
        {
            BlockchainStatusForm.DisplayForm(this.ParentForm);
        }
    }

}
