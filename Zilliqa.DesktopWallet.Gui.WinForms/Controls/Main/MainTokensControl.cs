using Zilliqa.DesktopWallet.Core.Services;
using Zilliqa.DesktopWallet.Gui.WinForms.Controls.DrillDown;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Main
{
    public partial class MainTokensControl : DrillDownMasterPanelControl
    {
        public MainTokensControl()
        {
            InitializeComponent();
        }

        private void MainTokensControl_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                timerStartLoading.Enabled = true;
            }
        }

        private void timerStartLoading_Tick(object sender, EventArgs e)
        {
            timerStartLoading.Enabled = false;
            var dataSource = TokenDataService.Instance.GetTokensDataSource();
            gridViewTokens.LoadData(dataSource);
            groupBoxTokensList.Tag ??= groupBoxTokensList.Text;
            groupBoxTokensList.Text = $"{groupBoxTokensList.Tag} ({dataSource.RecordCount:#,##0})";
        }
    }
}
