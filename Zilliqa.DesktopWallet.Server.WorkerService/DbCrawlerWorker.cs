using Zillifriends.Shared.Common;
using Zilliqa.DesktopWallet.Core;
using Zilliqa.DesktopWallet.Core.Repository;
using Zilliqa.DesktopWallet.Core.Services;
using Zilliqa.DesktopWallet.Core.ZilligraphDb;
using Zilliqa.DesktopWallet.Server.Core.Services;

namespace Zilliqa.DesktopWallet.Server.WorkerService
{
    public class DbCrawlerWorker : BackgroundService
    {
        private readonly ILogger<DbCrawlerWorker> _logger;

        public DbCrawlerWorker(ILogger<DbCrawlerWorker> logger)
        {
            _logger = logger;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            var rootPathEnvVariable = Environment.GetEnvironmentVariable("ZILSERVERPATH");
            var rootPath = string.IsNullOrEmpty(rootPathEnvVariable)
                ? "ZilliqaDesktopWallet"
                : rootPathEnvVariable;
            DataPathBuilder.Setup(Path.Combine(rootPath, "Server-Mainnet"), true);
            Logging.Setup(Path.Combine(DataPathBuilder.UserDataRoot.FullPath, "Log"));

            var archivePathEnvVariable = Environment.GetEnvironmentVariable("ZILARCHIVEPATH");
            if (!string.IsNullOrEmpty(archivePathEnvVariable))
            {
                SnapshotService.Instance.ArchiveRootFolder = new DataPathBuilder(archivePathEnvVariable);
            }

            Logging.LogInfo("Service startup");

            AppDomain.CurrentDomain.UnhandledException +=
                (sender, args) => Logging.LogError("Unhandled Thread Exception!", (Exception)args.ExceptionObject);

            // Startup Services
            StartupService.Instance.Startup();
            while (!StartupService.Instance.StartupCompleted)
            {
                Task.Run(async () => await Task.Delay(1000)).GetAwaiter().GetResult();
            }

            // start Snapshot Timer
            SnapshotService.Instance.StartSnapshotTimer();

            return Task.CompletedTask;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            Logging.LogInfo("Service Shutdown");
            SnapshotService.Instance.EndSnapshotTimer();
            ZilliqaBlockchainCrawler.Instance.Stop(true);
            RepositoryManager.Instance.Shutdown();

            return Task.CompletedTask;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // nothing to do
            return Task.CompletedTask;
        }
    }
}