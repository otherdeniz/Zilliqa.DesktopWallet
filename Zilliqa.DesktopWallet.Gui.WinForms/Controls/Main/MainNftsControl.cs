using Zilliqa.DesktopWallet.Core.Services;
using Zilliqa.DesktopWallet.Gui.WinForms.Controls.DrillDown;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Main
{
    public partial class MainNftsControl : DrillDownMasterPanelControl
    {
        public MainNftsControl()
        {
            InitializeComponent();
        }

        private void MainNftsControl_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                timerStartLoading.Enabled = true;
            }
        }

        private void timerStartLoading_Tick(object sender, EventArgs e)
        {
            timerStartLoading.Enabled = false;
            var dataSource = TokenDataService.Instance.GetNftsDataSource();
            gridViewTokens.LoadData(dataSource);
            groupBoxTokensList.Tag ??= groupBoxTokensList.Text;
            groupBoxTokensList.Text = $"{groupBoxTokensList.Tag} ({dataSource.RecordCount:#,##0})";
        }
    }
}
