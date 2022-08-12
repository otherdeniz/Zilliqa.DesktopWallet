using System.Text;
using Newtonsoft.Json;

namespace Zillifriends.Shared.Common
{
    public abstract class DatFileBase
    {
        private static readonly JsonSerializerSettings SerializerSettings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All,
#if DEBUG
            Formatting = Formatting.Indented
#endif
        };

        protected virtual string? FilePath { get; set; }

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
                        var data = JsonConvert.DeserializeObject<TDatType>(fileJson, SerializerSettings);
                        if (data == null)
                        {
                            throw new RuntimeException($"Load of file '{datFilePath}' failed");
                        }
                        data.FilePath = datFilePath;
                        return data;
                    }
                }
            }

            var createdDatFile = new TDatType
            {
                FilePath = datFilePath
            };
            createdDatFile.Save();
            return createdDatFile;
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

        public virtual void Save()
        {
            using (var fileStream = File.OpenWrite(FilePath ?? throw new MissingCodeException($"DatFile {this.GetType()} must be created using Load()")))
            {
                using (var fileWriter = new StreamWriter(fileStream, Encoding.UTF8, leaveOpen: true))
                {
                    fileWriter.Write(JsonConvert.SerializeObject(this, SerializerSettings));
                    fileWriter.Flush();
                }
                fileStream.SetLength(fileStream.Position);
            }
        }
    }
}
