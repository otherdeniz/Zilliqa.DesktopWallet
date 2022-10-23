namespace Zilliqa.DesktopWallet.WebContract
{
    public class SnapshotInfo
    {
        public string Id { get; set; }

        public DateTime TimestampUtc { get; set; }

        public decimal AppVersion { get; set; }

        public int BlockHeight { get; set; }

        public long Size { get; set; }

    }
}