using System.Drawing;

namespace Zilliqa.DesktopWallet.Core.Data
{
    public class DataPathBuilder
    {
        private const string ApplicationFolderName = "ZilliqaDesktopWallet";
        private readonly string _subPath;

        public DataPathBuilder(string subFolderName)
        {
            SubFolderName = subFolderName;

            var appdataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ApplicationFolderName);
            if (!Directory.Exists(appdataPath))
            {
                Directory.CreateDirectory(appdataPath);
            }

            _subPath = Path.Combine(appdataPath, subFolderName);
            if (!Directory.Exists(_subPath))
            {
                Directory.CreateDirectory(_subPath);
            }
        }

        public string SubFolderName { get; }

        public static string GetFilePath(string filename)
        {
            var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ApplicationFolderName);
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            return Path.Combine(filePath, filename);
        }

        public string GetSubFolderFilePath(string filename)
        {
            return Path.Combine(_subPath, filename);
        }
    }
}
