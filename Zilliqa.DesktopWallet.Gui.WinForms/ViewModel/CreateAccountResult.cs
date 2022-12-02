using Zilliqa.DesktopWallet.Gui.WinForms.Controls.Wallet;

namespace Zilliqa.DesktopWallet.Gui.WinForms.ViewModel
{
    public class CreateAccountResult : DialogWithPasswordResult
    {
        public string AccountName { get; set; }

        public AddAccountControl.AddWalletType AddWalletType { get; set; }

        public string? PrivateKey { get; set; }

        public string? LedgerPublicKey { get; set; }

        public string? LedgerAddressBech32 { get; set; }

    }
}
