namespace Zillifriends.Shared.Common
{
    public class DataPathBuilder
    {

#region Static Code

        private static string? _applicationFolderName;
        private static DataPathBuilder? _userRootDataPathBuilder;
        private static DataPathBuilder? _appRootDataPathBuilder;

        public static void Setup(string applicationFolderName)
        {
            _applicationFolderName = applicationFolderName;
            var userDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), _applicationFolderName);
            _userRootDataPathBuilder = new DataPathBuilder(userDataPath);
            var appDataPath = Path.Combine(Environment.ExpandEnvironmentVariables("%ProgramData%"), _applicationFolderName);
            _appRootDataPathBuilder = new DataPathBuilder(appDataPath);
        }

        public static DataPathBuilder UserDataRoot => _userRootDataPathBuilder ?? throw new MissingCodeException("DataPathBuilder.Setup not executed");

        public static DataPathBuilder AppDataRoot => _appRootDataPathBuilder ?? throw new MissingCodeException("DataPathBuilder.Setup not executed");

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

        public bool HasFiles(string pattern)
        {
            return Directory.EnumerateFiles(_fullPath, pattern).Any();
        }

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
