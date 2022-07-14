namespace Zilliqa.DesktopWallet.Core.Data.Files
{
    public static class DataPathBuilder
    {
        private const string ApplicationFolderName = "ZilliqaDesktopWallet";

        public static string GetFilePath(string filename)
        {
            var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ApplicationFolderName);
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            return Path.Combine(filePath, filename);
        }
    }
}
