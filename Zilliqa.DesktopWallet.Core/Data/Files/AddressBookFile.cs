using Zillifriends.Shared.Common;
using Zilliqa.DesktopWallet.Core.ViewModel;

namespace Zilliqa.DesktopWallet.Core.Data.Files
{
    [DatFileName("addressbook.json")]
    public class AddressBookFile : DatFileBase
    {
        private static AddressBookFile? _instance;

        public static AddressBookFile Instance => _instance ??= Load<AddressBookFile>(DataPathBuilder.UserDataRoot);

        #region Fields

        public List<AddressbookEntryViewModel> Entries { get; set; } = new();

        #endregion

    }
}
