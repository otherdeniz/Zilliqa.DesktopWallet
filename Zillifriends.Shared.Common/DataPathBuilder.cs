namespace Zillifriends.Shared.Common
{
    public class DataPathBuilder
    {

        #region Static Code

        private static DataPathBuilder? _userRootDataPathBuilder;
        private static DataPathBuilder? _appRootDataPathBuilder;

        public static void Setup(string applicationFolderName, bool storeUserDataInProgramData = false)
        {
            var appDataPath = Path.Combine(Environment.ExpandEnvironmentVariables("%ProgramData%"), applicationFolderName);
            _appRootDataPathBuilder = new DataPathBuilder(appDataPath);
            var userDataPath = storeUserDataInProgramData
                ? appDataPath
                : Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), applicationFolderName);
            _userRootDataPathBuilder = new DataPathBuilder(userDataPath);
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
