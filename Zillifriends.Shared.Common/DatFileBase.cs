using System.Text;
using Newtonsoft.Json;

namespace Zillifriends.Shared.Common
{
    public abstract class DatFileBase
    {
        private static readonly JsonSerializerSettings SerializerSettings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto,
            TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore,
#if DEBUG
            Formatting = Formatting.Indented
#endif
        };

        private readonly object _saveLock = new();

        protected virtual string? FilePath { get; private set; }

        protected static TDatType Load<TDatType>(DataPathBuilder dataRoot, bool saveOnCreate = true) where TDatType : DatFileBase, new()
        {
            var datFilePath = GetDatFilePath(dataRoot, typeof(TDatType));
            return Load<TDatType>(datFilePath, saveOnCreate);
        }

        protected static TDatType Load<TDatType>(string datFilePath, bool saveOnCreate = true) where TDatType : DatFileBase, new()
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
            if (saveOnCreate)
            {
                createdDatFile.Save();
            }
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
            if (FilePath == null)
            {
                throw new MissingCodeException($"DatFile {this.GetType()} must be created using Load()");
            }
            Task.Run(() =>
            {
                lock (_saveLock)
                {
                    var directory = new FileInfo(FilePath).Directory;
                    if (directory?.Exists == false)
                    {
                        directory.Create();
                    }

                    using (var fileStream = File.OpenWrite(FilePath))
                    {
                        using (var fileWriter = new StreamWriter(fileStream, Encoding.UTF8, leaveOpen: true))
                        {
                            fileWriter.Write(JsonConvert.SerializeObject(this, SerializerSettings));
                            fileWriter.Flush();
                        }

                        fileStream.SetLength(fileStream.Position);
                    }
                }
            });
        }

        public void EnsureExists()
        {
            // we call any function to ensure the instance is alive
            // this is for synchronisation ensurance, when multiple tasks try to acces the first instance at once, we call this method before parallel Tasks begin
            _ = GetType();
        }

    }
}
