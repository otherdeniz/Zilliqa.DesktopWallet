namespace Zilliqa.DesktopWallet.WebClient
{
    public class FileDownloadInfo
    {
        private readonly Stream _sourceStream;

        public FileDownloadInfo(string filePath, Stream sourceStream)
        {
            _sourceStream = sourceStream;
            FilePath = filePath;
        }

        public string FilePath { get; }

    }
}
