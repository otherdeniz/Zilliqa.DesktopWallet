using Zillifriends.Shared.Common;
using Zilliqa.DesktopWallet.Core.Data.Files;
using Zilliqa.DesktopWallet.Core.ZilligraphDb;
using Zilliqa.DesktopWallet.Server.Core.Model;

namespace Zilliqa.DesktopWallet.Server.Core.Services
{
    public class SnapshotService
    {
        public static SnapshotService Instance { get; } = new();

        private Task? _createSnapshotTask;

        private SnapshotService()
        {
        }

        public bool SnapshotCreationRunning => _createSnapshotTask != null;

        public void CreateSnapshot()
        {
            if (_createSnapshotTask != null)
            {
                throw new RuntimeException("Snapshot creation already running");
            }
            if (ZilliqaBlockchainCrawler.Instance.RunningState != RunningState.Stopped)
            {
                throw new RuntimeException("Blockchain crawler not in stopped state");
            }
            _createSnapshotTask = Task.Run(() =>
            {
                ZilliqaBlockchainCrawler.Instance.Stop(true);

                var snapshotEntry = new SnapshotEntry
                {
                    AppVersion = ApplicationInfo.ApplicationVersion,
                    BlockHeight = CrawlerStateDat.Instance.TransactionCrawler.HighestBlock

                };

                ZilliqaBlockchainCrawler.Instance.Start();
                _createSnapshotTask = null;
            });
        }
    }
}
