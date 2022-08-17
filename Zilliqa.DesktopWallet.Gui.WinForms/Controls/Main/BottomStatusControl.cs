using Zillifriends.Shared.Common;
using Zilliqa.DesktopWallet.Core.Repository;
using Zilliqa.DesktopWallet.Core.ZilligraphDb;

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
                textStatus.Text = ZilliqaBlockchainCrawler.Instance.IsCompleted
                    ? "Completed"
                    : $"Downloading ({ZilliqaBlockchainCrawler.Instance.NumberOfBlocksProcessed:#,##0}/{ZilliqaBlockchainCrawler.Instance.NumberOfBlocksOnChain:#,##0})";
            }
            else
            {
                textStatus.Text = ZilliqaBlockchainCrawler.Instance.RunningState == RunningState.Stopping
                    ? "Stopping"
                    : "Idle";
            }

            textDbSize.Text = RepositoryManager.Instance.ZilliqaBlockchainDbRepository.Database
                .GetDbSize().BytesToReadable();
            textBlocksCount.Text = RepositoryManager.Instance.BlockchainBrowserRepository.BlockchainInfo.NumberOfBlocks
                .ToString("#,##0");
            textTransactionsCount.Text = RepositoryManager.Instance.BlockchainBrowserRepository.BlockchainInfo.NumberOfTransactions
                .ToString("#,##0");

            RefreshButtons();
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
