using Zillifriends.Shared.Common;
using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.ViewModel;

namespace Zilliqa.DesktopWallet.Core.Data.Files
{
    public class WalletDat : DatFileBase
    {

        public const int MinPasswordLength = 12;

        #region Static Code

        private static string? _walletDatFilePath;
        private static WalletDat? _instance;

        public static WalletDat Instance => _instance ?? throw new MissingCodeException("WalletDat.Instance not set, Load() or Save() first");

        public static bool Exists => File.Exists(WalletDatFilePath);

        public static string WalletDatFilePath => _walletDatFilePath ??= DataPathBuilder.UserDataRoot.GetFilePath("wallet.dat");

        public static WalletDat CreateNew(PasswordInfo password)
        {
            var wallet = new WalletDat();
            wallet.CreatedDateUtc = DateTime.UtcNow;
            wallet.PasswordHash = password.Hash;
            return wallet;
        }

        public static WalletDat Load()
        {
            if (!Exists) throw new FileNotFoundException("wallet.dat not found");

            _instance = Load<WalletDat>(WalletDatFilePath);
            return _instance;
        }

        #endregion

        #region wallet.dat Fields

        public DateTime CreatedDateUtc { get; set; }

        public string PasswordHash { get; set; }

        public List<MyAccount> MyAccounts { get; set; } = new List<MyAccount>();

        public List<WatchedAccount> WatchedAccounts { get; set; } = new List<WatchedAccount>();

        #endregion

        protected override string? FilePath => _walletDatFilePath;

        public void InitialiseLoad(PasswordInfo password)
        {
            Instance.MyAccounts.ForEach(a => a.DecryptAccountDetailsFromKey(password.Password));
        }

        public void SetPassword(PasswordInfo newPassword)
        {
            PasswordHash = newPassword.Hash;
            Instance.MyAccounts.ForEach(a => a.EncryptAccountDetailsToKey(newPassword.Password));
        }

        public override void Save()
        {
            base.Save();
            _instance = this;
        }
    }
}