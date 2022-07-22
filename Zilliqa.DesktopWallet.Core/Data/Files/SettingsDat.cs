using System.Text;
using Newtonsoft.Json;

namespace Zilliqa.DesktopWallet.Core.Data.Files
{
    public class SettingsDat
    {
        private static readonly Lazy<string> LocalDataFile = new Lazy<string>(() => DataPathBuilder.GetFilePath("settings.dat"));
        private static SettingsDat? _instance;

        public static SettingsDat Instance => _instance ??= Load();

        #region Fields

        public string ViewBlockApiKey { get; set; } = string.Empty;

        #endregion

        private static SettingsDat Load()
        {
            if (File.Exists(LocalDataFile.Value))
            {
                using (var fileStream = File.OpenRead(LocalDataFile.Value))
                {
                    using (var fileReader = new StreamReader(fileStream, Encoding.UTF8))
                    {
                        var fileJson = fileReader.ReadToEnd();
                        return JsonConvert.DeserializeObject<SettingsDat>(fileJson);
                    }
                }
            }

            var createdSettings = new SettingsDat();
            createdSettings.Save();
            return createdSettings;
        }

        public void Save()
        {
            using (var fileStream = File.OpenWrite(LocalDataFile.Value))
            {
                using (var fileWriter = new StreamWriter(fileStream, Encoding.UTF8, leaveOpen: true))
                {
                    fileWriter.Write(JsonConvert.SerializeObject(this));
                    fileWriter.Flush();
                }
                fileStream.SetLength(fileStream.Position);
            }
        }

    }
}
