using Zillifriends.Shared.Common;
using Zilliqa.DesktopWallet.Core.Repository;
using Zilliqa.DesktopWallet.Core.ZilligraphDb;
using Zilliqa.DesktopWallet.DatabaseSchema;

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
            timerRefreshDbSize.Enabled = false;
            Application.DoEvents();
        }

        //protected override void ClickAction()
        //{
        //    BlockchainStatusForm.DisplayForm(this.ParentForm);
        //}

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            if (ZilliqaBlockchainCrawler.Instance.RunningState == RunningState.Running)
            {
                if (ZilliqaBlockchainCrawler.Instance.IsCompleted)
                {
                    textStatus.Text = "Completed";
                }
                else
                {
                    var percentage = 100d 
                                      / Convert.ToDouble(ZilliqaBlockchainCrawler.Instance.NumberOfBlocksOnChain) 
                                      * Convert.ToDouble(ZilliqaBlockchainCrawler.Instance.NumberOfBlocksProcessed);
                    textStatus.Text = $"Downloading ({percentage:0.000}%)";
                    // ({ZilliqaBlockchainCrawler.Instance.NumberOfBlocksProcessed:#,##0}/{ZilliqaBlockchainCrawler.Instance.NumberOfBlocksOnChain:#,##0})"
                }
            }
            else
            {
                textStatus.Text = ZilliqaBlockchainCrawler.Instance.RunningState == RunningState.Stopping
                    ? "Stopping"
                    : "Idle";
            }

            textBlocksCount.Text = ZilliqaBlockchainCrawler.Instance
                .NumberOfBlocksOnChain.ToString("#,##0");

            textDbBlocksCount.Text = ZilliqaBlockchainCrawler.Instance
                .NumberOfBlocksProcessed.ToString("#,##0"); 
            //RepositoryManager.Instance.ZilliqaBlockchainDbRepository.Database.GetTable<Block>().RecordCount.ToString("#,##0")

            textTransactionsCount.Text = RepositoryManager.Instance.BlockchainBrowserRepository.BlockchainInfo
                .NumberOfTransactions.ToString("#,##0");

            textDbTransactionsCount.Text = RepositoryManager.Instance.DatabaseRepository.Database.GetTable<Transaction>()
                .RecordCount.ToString("#,##0");

            labelLastBlockdate.Text = ZilliqaBlockchainCrawler.Instance
                                          .LastDownloadedBlockdate?.ToString("g")
                                      ?? "-";

            RefreshButtons();
        }

        private void timerRefreshDbSize_Tick(object sender, EventArgs e)
        {
            timerRefreshDbSize.Interval = 60000;
            textDbSize.Text = RepositoryManager.Instance.DatabaseRepository.Database
                .GetDbSize().BytesToReadable();
        }

        private void RefreshButtons()
        {
            buttonStart.Enabled = ZilliqaBlockchainCrawler.Instance.RunningState == RunningState.Stopped;
            buttonStop.Enabled = ZilliqaBlockchainCrawler.Instance.RunningState == RunningState.Running;
        }

        private void BottomStatusControl_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                timerRefresh.Enabled = true;
                timerRefreshDbSize.Enabled = true;
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            buttonStart.Enabled = false;
            ZilliqaBlockchainCrawler.Instance.Start();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            buttonStop.Enabled = false;
            ZilliqaBlockchainCrawler.Instance.Stop();
        }

    }

}
