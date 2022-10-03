using Zilliqa.DesktopWallet.Core.ViewModel;
using Zilliqa.DesktopWallet.Gui.WinForms.Controls.DrillDown;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Main
{
    public partial class MainStakingNodesControl : DrillDownMasterPanelControl
    {
        public MainStakingNodesControl()
        {
            InitializeComponent();
        }

        private void timerLoading_Tick(object sender, EventArgs e)
        {
            timerLoading.Enabled = false;
            var dataSource = StakingNodeRowViewModel.CreateViewModel();
            groupBoxGrid.Tag ??= groupBoxGrid.Text;
            groupBoxGrid.Text = $"{groupBoxGrid.Tag} ({dataSource.Count:#,##0})";
            gridViewStakingNodes.LoadData(dataSource, typeof(StakingNodeRowViewModel));
        }

        private void MainStakingNodesControl_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                timerLoading.Enabled = true;
            }
        }

    }
}
