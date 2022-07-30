namespace Zillifriends.Shared.Common
{
    public class DataPathBuilder
    {

#region Static Code

        private static string? _applicationFolderName;
        private static DataPathBuilder? _rootDataPathBuilder;

        public static void Setup(string applicationFolderName)
        {
            _applicationFolderName = applicationFolderName;
            var appdataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), _applicationFolderName);
            _rootDataPathBuilder = new DataPathBuilder(appdataPath);
        }

        public static DataPathBuilder Root => _rootDataPathBuilder ?? throw new MissingCodeException("DataPathBuilder.Setup not executed");

#endregion

        private readonly string _fullPath;

        public DataPathBuilder(string fullPath)
        {
            _fullPath = fullPath;
            if (!Directory.Exists(_fullPath))
            {
                Directory.CreateDirectory(_fullPath);
            }
        }

        public string FullPath => _fullPath;

        public string GetFilePath(string filename)
        {
            return Path.Combine(_fullPath, filename);
        }

        public DataPathBuilder GetSubFolder(string subFolderName)
        {
            return new DataPathBuilder(Path.Combine(_fullPath, subFolderName));
        }
    }
}
