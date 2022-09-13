using System.Diagnostics;

namespace Zilliqa.DesktopWallet.Gui.WinForms
{
    public static class BlockExplorerBrowser
    {
        public static BlockExplorerSite BlockExplorerSite { get; set; } = BlockExplorerSite.ViewblockIo;

        public static void ShowBlock(int blockNumber)
        {
            string? url = null;
            if (BlockExplorerSite == BlockExplorerSite.ViewblockIo)
            {
                url = $"https://viewblock.io/zilliqa/block/{blockNumber}";
                if (ApplicationInfo.IsTestnet)
                {
                    url += "?network=testnet";
                }
            }
            if (url != null)
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
        }

        public static void ShowTransaction(string transactionId)
        {
            string? url = null;
            if (BlockExplorerSite == BlockExplorerSite.ViewblockIo)
            {
                url = $"https://viewblock.io/zilliqa/tx/0x{transactionId}";
                if (ApplicationInfo.IsTestnet)
                {
                    url += "?network=testnet";
                }
            }
            if (url != null)
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
        }

        public static void ShowAddress(string addressBech32)
        {
            string? url = null;
            if (BlockExplorerSite == BlockExplorerSite.ViewblockIo)
            {
                url = $"https://viewblock.io/zilliqa/address/{addressBech32}";
                if (ApplicationInfo.IsTestnet)
                {
                    url += "?network=testnet";
                }
            }
            if (url != null)
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
        }
    }

    public enum BlockExplorerSite
    {
        ViewblockIo = 1
    }

}
