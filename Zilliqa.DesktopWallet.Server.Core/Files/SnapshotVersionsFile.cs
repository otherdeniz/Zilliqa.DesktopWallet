using Zillifriends.Shared.Common;
using Zilliqa.DesktopWallet.Server.Core.Model;

namespace Zilliqa.DesktopWallet.Server.Core.Files
{
    [DatFileName("server-snapshots.json")]
    public class SnapshotVersionsFile : DatFileBase
    {
        public static SnapshotVersionsFile Load()
        {
            return Load<SnapshotVersionsFile>(DataPathBuilder.AppDataRoot);
        }

        public List<SnapshotEntry> Snapshots { get; set; } = new();
    }
}
