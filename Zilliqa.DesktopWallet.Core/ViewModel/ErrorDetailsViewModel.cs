using System.ComponentModel;
using Zilliqa.DesktopWallet.ViewModelAttributes;

namespace Zilliqa.DesktopWallet.Core.ViewModel
{
    public class ErrorDetailsViewModel
    {
        public ErrorDetailsViewModel(string message)
        {
            Message = message;
        }

        [DetailsProperty]
        [DisplayName("Error")]
        public string Message { get; }
    }
}
