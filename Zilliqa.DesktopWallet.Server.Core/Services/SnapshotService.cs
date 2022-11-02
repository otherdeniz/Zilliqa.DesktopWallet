using System.IO.Compression;
using Zillifriends.Shared.Common;
using Zilliqa.DesktopWallet.Core;
using Zilliqa.DesktopWallet.Core.Data.Files;
using Zilliqa.DesktopWallet.Core.ZilligraphDb;
using Zilliqa.DesktopWallet.Server.Core.Files;
using Zilliqa.DesktopWallet.Server.Core.Model;

namespace Zilliqa.DesktopWallet.Server.Core.Services
{
    public class SnapshotService
    {
        private const int SNAPSHOT_INTERVALL_HOURS = 8;

        public static SnapshotService Instance { get; } = new();

        private readonly CancellationTokenSource _timerCancellationTokenSource = new();
        private bool _timerStarted;
        private Task? _snapshotTimerTask;
        private Task? _createSnapshotTask;

        private SnapshotService()
        {
        }

        public bool SnapshotCreationRunning => _createSnapshotTask != null;

        public void StartSnapshotTimer()
        {
            _timerStarted = true;
            _snapshotTimerTask = Task.Run(async () =>
            {
                var cancellationToken = _timerCancellationTokenSource.Token;
                try
                {
                    await Task.Delay(TimeSpan.FromSeconds(30), cancellationToken);
                    while (!cancellationToken.IsCancellationRequested)
                    {
                        var snapshotVersionsFile = SnapshotVersionsFile.Load();
                        var snapshotEntries = snapshotVersionsFile.Snapshots;
                        if (snapshotEntries.Count >= 3)
                        {
                            var zipFilePath = DataPathBuilder.AppDataRoot.GetFilePath(snapshotEntries[0].ZipFilename);
                            try
                            {
                                File.Delete(zipFilePath);
                                snapshotEntries.RemoveAt(0);
                                snapshotVersionsFile.Save();
                            }
                            catch (Exception e)
                            {
                                Logging.LogError($"Failed to delete Snapshot '{zipFilePath}'", e);
                            }
                        }
                        if (snapshotEntries.Any(s => s.AppVersion == ApplicationInfo.ApplicationVersion
                                                     && s.TimestampUtc > DateTime.UtcNow.AddHours(0 - SNAPSHOT_INTERVALL_HOURS))
                            || SnapshotCreationRunning
                            || !ZilliqaBlockchainCrawler.Instance.IsCompleted)
                        {
                            await Task.Delay(TimeSpan.FromMinutes(10), cancellationToken);
                        }
                        else
                        {
                            CreateSnapshot();
                            await Task.Delay(TimeSpan.FromMinutes(1), cancellationToken);
                        }
                    }
                }
                catch (TaskCanceledException)
                {
                    // task canceled
                }
                catch (Exception e)
                {
                    Logging.LogError("SnapshotTimer error", e);
                }
                _snapshotTimerTask = null;
                _timerStarted = false;
            });
        }

        public void EndSnapshotTimer()
        {
            _timerStarted = false;
            _timerCancellationTokenSource.Cancel();
            while (SnapshotCreationRunning)
            {
                Task.Run(async () => await Task.Delay(2000)).GetAwaiter().GetResult();
            }
        }

        public void CreateSnapshot()
        {
            if (_createSnapshotTask != null) return;
            _createSnapshotTask = Task.Run(() =>
            {
                ZilliqaBlockchainCrawler.Instance.Stop(true);

                try
                {
                    Logging.LogInfo("CreateSnapshot begin...");
                    var zipTimestamp = DateTime.UtcNow;
                    var zipFileInfo = CreateZipSnapshotFile();

                    var snapshotEntry = new SnapshotEntry
                    {
                        Id = Guid.NewGuid().ToString("N"),
                        AppVersion = ApplicationInfo.ApplicationVersion,
                        BlockHeight = CrawlerStateDat.Instance.TransactionCrawler.HighestBlock,
                        TimestampUtc = zipTimestamp,
                        ZipFilename = zipFileInfo.Name,
                        ZipFileSize = zipFileInfo.Length
                    };
                    var snapshotVersionsFile = SnapshotVersionsFile.Load();
                    snapshotVersionsFile.Snapshots.Add(snapshotEntry);
                    snapshotVersionsFile.Save();
                    Logging.LogInfo($"CreateSnapshot created file: {zipFileInfo.Name}");
                }
                catch (Exception e)
                {
                    Logging.LogError("CreateSnapshot failed", e);
                }

                if (_timerStarted)
                {
                    ZilliqaBlockchainCrawler.Instance.Start();
                }
                _createSnapshotTask = null;
            });
        }

        private FileInfo CreateZipSnapshotFile()
        {
            var zipFileName =
                $"Snapshot_{CrawlerStateDat.Instance.TransactionCrawler.HighestBlock}_{ApplicationInfo.ApplicationVersion:0.00}_{DateTime.UtcNow:yyyyMMdd-HHmm}.zip";
            var zipFilePath = DataPathBuilder.AppDataRoot.GetFilePath(zipFileName);
            using (var fileStream = new FileStream(zipFilePath, FileMode.CreateNew))
            {
                using (var zipArchive = new ZipArchive(fileStream, ZipArchiveMode.Create, true))
                {
                    AddToArchive(zipArchive, "",
                        new FileInfo(Path.Combine(DataPathBuilder.AppDataRoot.FullPath, "cryptometa.json")));
                    AddToArchive(zipArchive, "",
                        new FileInfo(Path.Combine(DataPathBuilder.AppDataRoot.FullPath, "token-prices.json")));
                    AddToArchive(zipArchive, "",
                        new DirectoryInfo(Path.Combine(DataPathBuilder.AppDataRoot.FullPath, "Images")));
                    AddToArchive(zipArchive, "",
                        new DirectoryInfo(Path.Combine(DataPathBuilder.AppDataRoot.FullPath, "ZilliqaDB")));
                }
            }
            return new FileInfo(zipFilePath);
        }

        private void AddToArchive(ZipArchive zipArchive, string zipPath, DirectoryInfo folder)
        {
            var zipFolderPath = Path.Combine(zipPath, folder.Name);
            foreach (var fileInfo in folder.GetFiles())
            {
                AddToArchive(zipArchive, zipFolderPath, fileInfo);
            }
            foreach (var subDirectory in folder.GetDirectories())
            {
                AddToArchive(zipArchive, zipFolderPath, subDirectory);
            }
        }

        private void AddToArchive(ZipArchive zipArchive, string zipPath, FileInfo file)
        {
            var zipEntry = zipArchive.CreateEntry(Path.Combine(zipPath, file.Name));
            using (var fileStream = file.OpenRead())
            {
                using (var zipStream = zipEntry.Open())
                {
                    fileStream.CopyTo(zipStream);
                }
            }
        }
    }
}
