using System.IO.Compression;
using Zillifriends.Shared.Common;
using Zilliqa.DesktopWallet.Core;
using Zilliqa.DesktopWallet.Core.Data.Files;
using Zilliqa.DesktopWallet.Core.Repository;
using Zilliqa.DesktopWallet.Core.ZilligraphDb;
using Zilliqa.DesktopWallet.WebContract;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Forms
{
    public partial class DownloadSnapshotForm : Form
    {
        public static bool Execute(Form parentForm, SnapshotInfo snapshotInfo)
        {
            using (var form = new DownloadSnapshotForm())
            {
                form.LoadSnapshotInfo(snapshotInfo);
                return form.ShowDialog(parentForm) == DialogResult.OK;
            }
        }

        private SnapshotInfo _snapshotInfo = null!;
        private long _downloadedBytes;
        private long _downloadedBytesBefore;
        private DateTime? _downloadStart;
        private int _extractFilesTotal;
        private int _extractFilesDone;
        private Stream? _extractStream;
        private bool _cancelDownload;

        public DownloadSnapshotForm()
        {
            InitializeComponent();
            panelQuestion.Dock = DockStyle.Fill;
            panelDownloadStatus.Dock = DockStyle.Fill;
        }

        private void LoadSnapshotInfo(SnapshotInfo snapshotInfo)
        {
            _snapshotInfo = snapshotInfo;
            var ageText = "stone age :D";
            if (CrawlerStateDat.Instance.NewestBlockDate != null)
            {
                var ageTimespan = DateTime.UtcNow - CrawlerStateDat.Instance.NewestBlockDate.Value;
                ageText = ageTimespan.TotalDays > 1 
                    ? $"{ageTimespan.TotalDays:0.0} Days" 
                    : $"{ageTimespan.TotalHours:0.0} Hours";
            }
            labelLocalStateValue.Text = CrawlerStateDat.Instance.TransactionCrawler.LowestBlock != 1
                ? "Incomplete, recommended to download snapshot."
                : $"Block height: {CrawlerStateDat.Instance.TransactionCrawler.HighestBlock:#,##0} / Age: {ageText}";
            labelSnapshotHeight.Text = snapshotInfo.BlockHeight.ToString("#,##0");
            labelSnapshotDate.Text = snapshotInfo.TimestampUtc.ToLocalTime().ToString("g");
            labelSnapshotSize.Text = snapshotInfo.Size.BytesToReadable();
        }

        private void StartDownload()
        {
            timerDownload.Enabled = true;
            panelDownloadStatus.Visible = true;
            Task.Run(() =>
            {
                var downloadFile = DataPathBuilder.AppDataRoot.GetFilePath("snapshot_download.zip");
                if (File.Exists(downloadFile))
                {
                    File.Delete(downloadFile);
                }
                try
                {
                    // download file
                    var downloadStream = RepositoryManager.Instance.WalletWebClient.DownloadSnapshotStream(_snapshotInfo.Id);
                    if (downloadStream == null)
                    {
                        WinFormsSynchronisationContext.ExecuteSynchronized(() =>
                        {
                            MessageBox.Show("Error", "Download failed, response was not OK.", MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                            Close();
                        });
                        return;
                    }
                    _downloadStart = DateTime.Now;
                    using (var targetStream = File.Create(downloadFile))
                    {
                        var buffer = new byte[4096];
                        bool isCompleted = false;
                        do
                        {
                            var readBytes = downloadStream.Read(buffer, 0, buffer.Length);
                            if (readBytes > 0)
                            {
                                _downloadedBytes += readBytes;
                                targetStream.Write(buffer, 0, readBytes);
                            }
                            else
                            {
                                isCompleted = true;
                            }
                        } while (!_cancelDownload && !isCompleted);
                        downloadStream.Close();
                    }
                    if (_cancelDownload)
                    {
                        File.Delete(downloadFile);
                        WinFormsSynchronisationContext.ExecuteSynchronized(() =>
                        {
                            DialogResult = DialogResult.OK;
                            Close();
                        });
                        return;
                    }

                    // extract file
                    WinFormsSynchronisationContext.ExecuteSynchronized(() =>
                    {
                        timerDownload.Enabled = false;
                        timerExtract.Enabled = true;
                        buttonCancelDownload.Enabled = false;
                        labelDownloadTitle.Text = "Extracting snapshot...";
                        panelDownloadDetails.Visible = false;
                        panelExtractDetails.Visible = true;
                    });
                    CleanupDirectory("Images");
                    CleanupDirectory("ZilliqaDB");
                    var extractionPath = DataPathBuilder.AppDataRoot.FullPath;
                    var archiveAndStream = OpenZipArchive(downloadFile);
                    _extractStream = archiveAndStream.Stream;
                    using (var archive = archiveAndStream.Archive)
                    {
                        _extractFilesTotal = archive.Entries.Count;
                        foreach (var entry in archive.Entries)
                        {
                            var targetFile = Path.Combine(extractionPath, entry.FullName);
                            var targetDirectory = new FileInfo(targetFile).Directory;
                            if (targetDirectory != null 
                                && !targetDirectory.Exists)
                            {
                                targetDirectory.Create();
                            }
                            entry.ExtractToFile(targetFile, true);
                            _extractFilesDone++;
                        }
                        _extractStream = null;
                    }
                    File.Delete(downloadFile);

                    // reload blockchain data
                    CrawlerStateDat.ReloadInstance();
                    ZilliqaBlockchainCrawler.Instance.ReloadBlockchainStatusFromDisk();

                    // finished
                    WinFormsSynchronisationContext.ExecuteSynchronized(() =>
                    {
                        DialogResult = DialogResult.OK;
                        Close();
                    });
                }
                catch (Exception e)
                {
                    _extractStream = null;
                    if (File.Exists(downloadFile))
                    {
                        File.Delete(downloadFile);
                    }
                    Logging.LogError("Snapshot download failed", e);
                    WinFormsSynchronisationContext.ExecuteSynchronized(() =>
                    {
                        MessageBox.Show("Error", $"Download failed: {e.Message}", MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                        Close();
                    });
                }
            });
        }

        private (ZipArchive Archive, Stream Stream) OpenZipArchive(string archiveFileName)
        {
            var fs = new FileStream(archiveFileName, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 0x1000, useAsync: false);
            var archive = new ZipArchive(fs, ZipArchiveMode.Read, leaveOpen: false);
            return (archive, fs);
        }

        private void CleanupDirectory(string folderName)
        {
            var fullPath = Path.Combine(DataPathBuilder.AppDataRoot.FullPath, folderName);
            if (Directory.Exists(fullPath))
            {
                Directory.Delete(fullPath, true);
            }
        }

        private void buttonDownload_Click(object sender, EventArgs e)
        {
            panelQuestion.Visible = false;
            panelDownloadStatus.Visible = true;
            StartDownload();
        }

        private void buttonSkip_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancelDownload_Click(object sender, EventArgs e)
        {
            buttonCancelDownload.Enabled = false;
            _cancelDownload = true;
        }

        private void timerDownload_Tick(object sender, EventArgs e)
        {
            labelDownloadedSize.Text = $"{_downloadedBytes.BytesToReadable()} / {_snapshotInfo.Size.BytesToReadable()}";
            labelDownloadedProgress.Text =
                $"{(100m / Convert.ToDecimal(_snapshotInfo.Size) * Convert.ToDecimal(_downloadedBytes)):0.00} %";
            if (_downloadedBytesBefore > 0)
            {
                labelDownloadedSpeed.Text = $"{(_downloadedBytes-_downloadedBytesBefore).BytesToReadable()} / s";
            }
            _downloadedBytesBefore = _downloadedBytes;
            if (_downloadStart != null && _downloadedBytes > 0)
            {
                try
                {
                    var timeLeft = TimeSpan.FromSeconds((DateTime.Now - _downloadStart.Value).TotalSeconds /
                        Convert.ToDouble(_downloadedBytes) * Convert.ToDouble(_snapshotInfo.Size - _downloadedBytes));
                    labelDownloadedTimeLeft.Text = timeLeft.TotalMinutes > 1
                        ? $"{timeLeft.TotalMinutes:0.0} minutes"
                        : $"{timeLeft.TotalSeconds:0} seconds";
                }
                catch (Exception)
                {
                    // ignore
                }
            }
        }

        private void timerExtract_Tick(object sender, EventArgs e)
        {
            labelExtractedFiles.Text = $"{_extractFilesDone:#,##0} / {_extractFilesTotal:#,##0}";
            if (_extractFilesTotal > 0 && _extractStream != null)
            {
                labelExtractedProgress.Text =
                    $"{100m / Convert.ToDecimal(_extractStream.Length) * Convert.ToDecimal(_extractStream.Position):0.00} %";
            }
        }
    }
}
