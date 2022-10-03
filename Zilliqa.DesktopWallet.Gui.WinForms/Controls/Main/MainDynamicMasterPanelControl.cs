using Zilliqa.DesktopWallet.Gui.WinForms.Controls.DrillDown;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Main
{
    public partial class MainDynamicMasterPanelControl : DrillDownMasterPanelControl
    {
        public MainDynamicMasterPanelControl()
        {
            InitializeComponent();
        }

        public void LoadLeftControl(Control leftControl)
        {
            leftControl.Dock = DockStyle.Fill;
            panelLeft.Controls.Add(leftControl);
        }
    }
}
