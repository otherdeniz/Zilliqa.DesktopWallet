using Zilliqa.DesktopWallet.Core.Repository;
using Zilliqa.DesktopWallet.Gui.WinForms.ViewModel;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Main
{
    public partial class MainTokensControl : UserControl
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
            var tokensList = TokenRepository.Instance.GetTokens().Select(t => new TokenGridRowViewModel(t)).ToList();
            dataGridViewTokens.DataSource = tokensList;
            panelLoading.Visible = false;
            panelLoaded.Visible = true;
        }

    }
}
