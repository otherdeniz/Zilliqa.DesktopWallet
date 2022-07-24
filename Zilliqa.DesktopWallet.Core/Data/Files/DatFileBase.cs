using System.Text;
using Newtonsoft.Json;

namespace Zilliqa.DesktopWallet.Core.Data.Files
{
    public abstract class DatFileBase
    {
        protected static TDatType Load<TDatType>() where TDatType : DatFileBase, new()
        {
            var datFilePath = GetDatFilePath(typeof(TDatType));
            if (File.Exists(datFilePath))
            {
                using (var fileStream = File.OpenRead(datFilePath))
                {
                    using (var fileReader = new StreamReader(fileStream, Encoding.UTF8))
                    {
                        var fileJson = fileReader.ReadToEnd();
                        return JsonConvert.DeserializeObject<TDatType>(fileJson);
                    }
                }
            }

            var createdSettings = new TDatType();
            createdSettings.Save();
            return createdSettings;
        }

        protected static string GetDatFilePath(Type datType)
        {
            if (datType.GetCustomAttributes(typeof(DatFileNameAttribute), false).FirstOrDefault() is
                DatFileNameAttribute attribute)
            {
                return DataPathBuilder.GetFilePath(attribute.Filename);
            }

            throw new Exception($"DatFileNameAttribute not declared on {datType.Name}");
        }

        public void Save()
        {
            using (var fileStream = File.OpenWrite(GetDatFilePath(this.GetType())))
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
