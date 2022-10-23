using Zilligraph.Database.Storage;
using Zilliqa.DesktopWallet.Core.Repository;
using Zilliqa.DesktopWallet.Core.ZilligraphDb;
using Zilliqa.DesktopWallet.DatabaseSchema;

namespace Zilliqa.DesktopWallet.Core.Services
{
    public class StartupService
    {
        public static StartupService Instance { get; } = new();

        private readonly List<IZilligraphTable> _zilligraphTables = new();
        
        private StartupService()
        {
            var database = RepositoryManager.Instance.DatabaseRepository.Database;
            _zilligraphTables.Add(database.GetTable<Block>());
            _zilligraphTables.Add(database.GetTable<Transaction>());
            _zilligraphTables.Add(database.GetTable<SmartContract>());
        }

        public event EventHandler<StatusEventArgs>? StatusChanged;

        public bool StartupCompleted { get; private set; }

        public string StartupStatus { get; private set; } = "";

        public void Startup()
        {
            Task.Run(async () =>
            {
                var upgareTables = _zilligraphTables.Where(t => !t.InitialisationCompleted).ToList();
                foreach (var upgareTable in upgareTables)
                {
                    upgareTable.EnsureInitialisationIsStarted();
                    while (upgareTable.InitialisationCompletedPercent < 100)
                    {
                        if (upgareTable.InitialisationCompletedPercent > 0)
                        {
                            SetStartupStatus($"Upgrading Database Table '{upgareTable.TableName}' : {upgareTable.InitialisationCompletedPercent:0.00}%");
                            await Task.Delay(1000);
                        }
                        else
                        {
                            await Task.Delay(500);
                        }
                    }
                }

                SetStartupStatus("Startup Coingecko price services");
                RepositoryManager.Instance.CoingeckoRepository.Startup(true);
                while (!RepositoryManager.Instance.CoingeckoRepository.StartupCompleted)
                {
                    await Task.Delay(500);
                }

                SetStartupStatus("Downloading Cryptometa data");
                CryptometaDownloadService.Instance.LoadOrRefresh();
                var cryptoMetaLoadingStatus = CryptometaDownloadService.Instance.LoadingStatus;
                while (!CryptometaDownloadService.Instance.LoadCompleted)
                {
                    await Task.Delay(500);
                    if (cryptoMetaLoadingStatus != CryptometaDownloadService.Instance.LoadingStatus)
                    {
                        cryptoMetaLoadingStatus = CryptometaDownloadService.Instance.LoadingStatus;
                        SetStartupStatus($"Downloading Cryptometa data\n{cryptoMetaLoadingStatus}");
                    }
                }
                var tokenDataLoadingStatus = TokenDataService.Instance.LoadingStatus;
                while (!TokenDataService.Instance.LoadCompleted)
                {
                    await Task.Delay(500);
                    if (tokenDataLoadingStatus != TokenDataService.Instance.LoadingStatus)
                    {
                        tokenDataLoadingStatus = TokenDataService.Instance.LoadingStatus;
                        SetStartupStatus($"Starting Token data service\n{tokenDataLoadingStatus}");
                    }
                }

                KnownAddressService.Instance.EnsureInitialized();

                if (ZilliqaBlockchainCrawler.Instance.RunningState == RunningState.Stopped)
                {
                    SetStartupStatus("Starting Blockchain Sync");
                    ZilliqaBlockchainCrawler.Instance.Start();
                    await Task.Delay(1500);
                }

                StakingService.Instance.GetStakingSeedNodeRewards();

                StartupCompleted = true;
                SetStartupStatus("", true);
            });
        }

        public void Shutdown()
        {
            ZilliqaBlockchainCrawler.Instance.Stop(true);
            RepositoryManager.Instance.Shutdown();
        }

        private void SetStartupStatus(string statusText, bool isCompleted = false)
        {
            StartupStatus = statusText;
            StatusChanged?.Invoke(this, new StatusEventArgs(true, isCompleted, statusText));
        }

        public class StatusEventArgs : EventArgs
        {
            public StatusEventArgs(bool isStartup, bool isCompleted, string statusText)
            {
                IsStartup = isStartup;
                IsCompleted = isCompleted;
                StatusText = statusText;
            }
            public bool IsStartup { get; }
            public bool IsCompleted { get; }
            public string StatusText { get; }
        }
    }
}
