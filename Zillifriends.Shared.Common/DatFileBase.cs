using System.Text;
using Newtonsoft.Json;

namespace Zillifriends.Shared.Common
{
    public abstract class DatFileBase
    {
        private string? _filePath;

        protected static TDatType Load<TDatType>() where TDatType : DatFileBase, new()
        {
            var datFilePath = GetDatFilePath(DataPathBuilder.Root, typeof(TDatType));
            return Load<TDatType>(datFilePath);
        }

        protected static TDatType Load<TDatType>(string datFilePath) where TDatType : DatFileBase, new()
        {
            if (File.Exists(datFilePath))
            {
                using (var fileStream = File.OpenRead(datFilePath))
                {
                    using (var fileReader = new StreamReader(fileStream, Encoding.UTF8))
                    {
                        var fileJson = fileReader.ReadToEnd();
                        var data = JsonConvert.DeserializeObject<TDatType>(fileJson);
                        if (data == null)
                        {
                            throw new RuntimeException($"Load of file '{datFilePath}' failed");
                        }
                        data._filePath = datFilePath;
                        return data;
                    }
                }
            }

            var createdSettings = new TDatType
            {
                _filePath = datFilePath
            };
            createdSettings.Save();
            return createdSettings;
        }

        protected static string GetDatFilePath(DataPathBuilder dataPathBuilder, Type datType)
        {
            if (datType.GetCustomAttributes(typeof(DatFileNameAttribute), false).FirstOrDefault() is
                DatFileNameAttribute attribute)
            {
                return dataPathBuilder.GetFilePath(attribute.Filename);
            }

            throw new MissingCodeException($"DatFileNameAttribute not declared on {datType.FullName}");
        }

        public void Save()
        {
            using (var fileStream = File.OpenWrite(_filePath ?? throw new MissingCodeException($"DatFile {this.GetType()} must be created using Load()")))
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
