using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.ViewModel;

namespace Zilliqa.DesktopWallet.Gui.WinForms.ViewModel
{
    public class DialogWithPasswordResult
    {
        public MyAccount SenderAccount { get; set; } = null!;

        public PasswordInfo Password { get; set; } = null!;

    }
}
