using Zilliqa.DesktopWallet.Core;
using Zilliqa.DesktopWallet.Core.Repository;
using Zilliqa.DesktopWallet.Core.Services;
using Zilliqa.DesktopWallet.Gui.WinForms.Controls.DrillDown;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Main
{
    public partial class MainContractsControl : DrillDownMasterPanelControl
    {
        public MainContractsControl()
        {
            InitializeComponent();
            gridViewContracts.Dock = DockStyle.Fill;
            gridViewFungibleTokens.Dock = DockStyle.Fill;
            gridViewNfts.Dock = DockStyle.Fill;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void timerLoading_Tick(object sender, EventArgs e)
        {
            timerLoading.Enabled = false;
            Task.Run(() =>
            {
                try
                {
                    var dataSourceSmartContracts = RepositoryManager.Instance.DatabaseRepository.ReadSmartContractViewModelsPaged();
                    WinFormsSynchronisationContext.ExecuteSynchronized(() =>
                    {
                        tabButtonSmartContracts.Tag ??= tabButtonSmartContracts.Text;
                        tabButtonSmartContracts.Text = $"{tabButtonSmartContracts.Tag} ({dataSourceSmartContracts.RecordCount:#,##0})";
                        gridViewContracts.LoadData(dataSourceSmartContracts);
                    });
                    var dataSourceFungibleTokens = TokenDataService.Instance.GetTokensDataSource();
                    WinFormsSynchronisationContext.ExecuteSynchronized(() =>
                    {
                        gridViewFungibleTokens.LoadData(dataSourceFungibleTokens);
                        tabButtonFungibleTokens.Tag ??= tabButtonFungibleTokens.Text;
                        tabButtonFungibleTokens.Text = $"{tabButtonFungibleTokens.Tag} ({dataSourceFungibleTokens.RecordCount:#,##0})";
                    });
                    var dataSourceNfts = TokenDataService.Instance.GetNftsDataSource();
                    WinFormsSynchronisationContext.ExecuteSynchronized(() =>
                    {
                        gridViewNfts.LoadData(dataSourceNfts);
                        tabButtonNfts.Tag ??= tabButtonNfts.Text;
                        tabButtonNfts.Text = $"{tabButtonNfts.Tag} ({dataSourceNfts.RecordCount:#,##0})";
                    });
                }
                catch (Exception)
                {
                    // control was disposed during load
                }
            });
        }

        private void MainContractsControl_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                timerLoading.Enabled = true;
                TabButtonClick(tabButtonSmartContracts, gridViewContracts);
            }
        }

        private void TabButtonClick(ToolStripButton button, Control tabPageControl)
        {
            foreach (var item in toolStripTabs.Items)
            {
                if (item is ToolStripButton itemButton)
                {
                    itemButton.Checked = false;
                    itemButton.Font = new Font(itemButton.Font, FontStyle.Regular);
                }
            }
            button.Checked = true;
            button.Font = new Font(button.Font, FontStyle.Bold);

            foreach (Control pageControl in panelTabs.Controls)
            {
                pageControl.Visible = false;
            }
            tabPageControl.Visible = true;
        }

        private void tabButtonSmartContracts_Click(object sender, EventArgs e)
        {
            TabButtonClick(tabButtonSmartContracts, gridViewContracts);
        }

        private void tabButtonFungibleTokens_Click(object sender, EventArgs e)
        {
            TabButtonClick(tabButtonFungibleTokens, gridViewFungibleTokens);
        }

        private void tabButtonNfts_Click(object sender, EventArgs e)
        {
            TabButtonClick(tabButtonNfts, gridViewNfts);
        }
    }
}
