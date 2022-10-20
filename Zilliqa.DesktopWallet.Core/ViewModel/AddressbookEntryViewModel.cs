using Zilliqa.DesktopWallet.ViewModelAttributes;

namespace Zilliqa.DesktopWallet.Core.ViewModel
{
    [GridSearchable(nameof(Name))]
    public class AddressbookEntryViewModel
    {
        public string Name { get; set; }

        public string Address { get; set; }

    }
}
