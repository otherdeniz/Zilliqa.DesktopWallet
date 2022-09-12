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

        public bool HasFiles => Directory.EnumerateFiles(_fullPath).Any();

        public string GetFilePath(string filename)
        {
            var filePath = Path.Combine(_fullPath, filename);

            var fileDirectory = new FileInfo(filePath).Directory;
            if (fileDirectory?.Exists == false)
            {
                fileDirectory.Create();
            }

            return filePath;
        }

        public DataPathBuilder GetSubFolder(string subFolderName)
        {
            return new DataPathBuilder(Path.Combine(_fullPath, subFolderName));
        }

        public void DeleteFolderContents()
        {
            Directory.Delete(_fullPath, true);
            Directory.CreateDirectory(_fullPath);
        }
    }
}
