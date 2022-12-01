using Zilliqa.DesktopWallet.Gui.WinForms.Controls.Wallet;

namespace Zilliqa.DesktopWallet.Gui.WinForms.ViewModel
{
    public class CreateAccountResult : DialogWithPasswordResult
    {
        public string AccountName { get; set; }

        public AddAccountControl.AddWalletType AddWalletType { get; set; }

        public string? PrivateKey { get; set; }


    }
}
