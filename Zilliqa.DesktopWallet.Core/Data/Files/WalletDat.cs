using System.Text;
using Newtonsoft.Json;
using Zilliqa.DesktopWallet.Core.Data.Model;

namespace Zilliqa.DesktopWallet.Core.Data.Files
{
    public class WalletDat
    {
        private static readonly Lazy<string> localDataFile = new Lazy<string>(() => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "wallet.dat"));

        public static bool Exists => File.Exists(localDataFile.Value);

        public static WalletDat Instance { get; private set; }

        #region wallet.dat Fields

        public DateTime CreatedDateUtc { get; set; }

        public string PasswordHash { get; set; }

        public List<MyAccount> MyAccounts { get; set; } = new List<MyAccount>();

        public List<WatchedAccount> WatchedAccounts { get; set; } = new List<WatchedAccount>();

        #endregion

        public static WalletDat CreateNew()
        {
            var wallet = new WalletDat();
            wallet.CreatedDateUtc = DateTime.UtcNow;
            return wallet;
        }

        public static WalletDat Load()
        {
            if (!Exists) throw new FileNotFoundException("wallet.dat not found");

            using (var fileStream = File.OpenRead(localDataFile.Value))
            {
                using (var fileReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    var fileJson = fileReader.ReadToEnd();
                    Instance = JsonConvert.DeserializeObject<WalletDat>(fileJson);
                    return Instance;
                }
            }

        }

        public void Save()
        {
            using (var fileStream = File.OpenWrite(localDataFile.Value))
            {
                using (var fileWriter = new StreamWriter(fileStream))
                {
                    fileWriter.Write(JsonConvert.SerializeObject(this));
                    fileWriter.Flush();
                }
                fileStream.SetLength(fileStream.Position);
            }

            Instance = this;
        }
    }
}