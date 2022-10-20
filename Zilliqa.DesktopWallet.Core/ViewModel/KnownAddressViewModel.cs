using Zilliqa.DesktopWallet.ViewModelAttributes;

namespace Zilliqa.DesktopWallet.Core.ViewModel
{
    [GridSearchable(nameof(Name))]
    public class KnownAddressViewModel
    {
        public string Category { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }
    }
}
