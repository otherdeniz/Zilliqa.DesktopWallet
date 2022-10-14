using Zilliqa.DesktopWallet.Core.ViewModel;
using Zilliqa.DesktopWallet.Gui.WinForms.Controls.DrillDown;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Main
{
    public partial class MainEcosystemControl : DrillDownMasterPanelControl
    {
        public MainEcosystemControl()
        {
            InitializeComponent();
        }

        private void timerLoading_Tick(object sender, EventArgs e)
        {
            timerLoading.Enabled = false;
            var dataSource = EcosystemViewModel.CreateViewModelList();
            groupBoxGrid.Tag ??= groupBoxGrid.Text;
            groupBoxGrid.Text = $"{groupBoxGrid.Tag} ({dataSource.RecordCount:#,##0})";
            gridViewEcosystem.LoadData(dataSource);
        }

        private void MainEcosystemControl_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                timerLoading.Enabled = true;
            }
        }

    }
}
