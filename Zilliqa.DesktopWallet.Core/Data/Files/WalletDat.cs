using System.Text;
using Newtonsoft.Json;
using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.ViewModel;

namespace Zilliqa.DesktopWallet.Core.Data.Files
{
    public class WalletDat
    {
        private static readonly Lazy<string> localDataFile = new Lazy<string>(() => DataPathBuilder.GetFilePath("wallet.dat"));

        public static bool Exists => File.Exists(localDataFile.Value);

        public static WalletDat Instance { get; private set; }

        #region wallet.dat Fields

        public DateTime CreatedDateUtc { get; set; }

        public string PasswordHash { get; set; }

        public List<MyAccount> MyAccounts { get; set; } = new List<MyAccount>();

        public List<WatchedAccount> WatchedAccounts { get; set; } = new List<WatchedAccount>();

        #endregion

        public static WalletDat CreateNew(PasswordInfo password, string firstAccountName)
        {
            var wallet = new WalletDat();
            wallet.CreatedDateUtc = DateTime.UtcNow;
            wallet.PasswordHash = password.Hash;
            wallet.MyAccounts.Add(MyAccount.Create(firstAccountName, password.Password));
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

        public void InitialiseLoad(PasswordInfo password)
        {
            Instance.MyAccounts.ForEach(a => a.Load(password.Password));
        }

        public void Save()
        {
            using (var fileStream = File.OpenWrite(localDataFile.Value))
            {
                using (var fileWriter = new StreamWriter(fileStream, Encoding.UTF8, leaveOpen:true))
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