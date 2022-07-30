using System.Text;
using Newtonsoft.Json;
using Zillifriends.Shared.Common;
using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.ViewModel;

namespace Zilliqa.DesktopWallet.Core.Data.Files
{
    public class WalletDat
    {

        #region Static Code

        private static string? _filePath;
        private static WalletDat? _instance;

        public static WalletDat Instance => _instance ?? throw new MissingCodeException("WalletDat.Instance not set, Load() or Save() first");

        public static bool Exists => File.Exists(FilePath);

        public static string FilePath => _filePath ??= DataPathBuilder.Root.GetFilePath("wallet.dat");

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

            using (var fileStream = File.OpenRead(FilePath))
            {
                using (var fileReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    var fileJson = fileReader.ReadToEnd();
                    _instance = JsonConvert.DeserializeObject<WalletDat>(fileJson);
                    return Instance;
                }
            }

        }

        #endregion

        #region wallet.dat Fields

        public DateTime CreatedDateUtc { get; set; }

        public string PasswordHash { get; set; }

        public List<MyAccount> MyAccounts { get; set; } = new List<MyAccount>();

        public List<WatchedAccount> WatchedAccounts { get; set; } = new List<WatchedAccount>();

        #endregion

        public void InitialiseLoad(PasswordInfo password)
        {
            Instance.MyAccounts.ForEach(a => a.Load(password.Password));
        }

        public void Save()
        {
            using (var fileStream = File.OpenWrite(FilePath))
            {
                using (var fileWriter = new StreamWriter(fileStream, Encoding.UTF8, leaveOpen:true))
                {
                    fileWriter.Write(JsonConvert.SerializeObject(this));
                    fileWriter.Flush();
                }
                fileStream.SetLength(fileStream.Position);
            }

            _instance = this;
        }
    }
}