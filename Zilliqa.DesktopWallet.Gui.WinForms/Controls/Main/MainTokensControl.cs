using Zilliqa.DesktopWallet.Core.Extensions;
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
            var tokensList = TokenRepository.Instance.GetTokens()
                .OrderByDescending(t => t.Symbol == "ZIL" ? decimal.MaxValue : t.MarketData.FullyDilutedValuationUsd)
                .Select(t => new TokenGridRowViewModel(t)).ToList();
            gridViewTokens.LoadData(tokensList, typeof(TokenGridRowViewModel));
            panelLoading.Visible = false;
            panelLoaded.Visible = true;
        }

        private void gridViewTokens_RowSelected(object sender, GridView.GridViewControl.RowSelectionEventArgs e)
        {
            groupBoxTokenDetails.Visible = true;
            var token = (TokenGridRowViewModel)e.SelectedRow;
            pictureBoxIcon.Image = token.Model.GetTokenIcon().Icon48;
            labelName.Text = token.Name;
            labelSymbol.Text = token.Symbol;
        }
    }
}
