namespace Zilliqa.DesktopWallet.Server.Core.Model;

public class SnapshotEntry
{
    public string Id { get; set; }

    public decimal AppVersion { get; set; }

    public DateTime TimestampUtc { get; set; }

    public int BlockHeight { get; set; }

    public string ZipFilename { get; set; }

    public long ZipFileSize { get; set; }
}