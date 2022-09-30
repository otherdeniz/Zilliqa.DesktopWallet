using Zillifriends.Shared.Common;
using Zilliqa.DesktopWallet.ApiClient.ViewblockApi.Model;

namespace Zilliqa.DesktopWallet.Core.Data.Files;

[DatFileName("cryptometa.json")]
public class CryptometaFile : DatFileBase
{
    private static CryptometaFile? _instance;

    public static CryptometaFile Instance => _instance ??= Load<CryptometaFile>(DataPathBuilder.AppDataRoot);

    #region Fields

    public DateTime? ModifiedDate { get; set; }

    public List<CryptometaEcosystem> Ecosystems { get; set; } = new();

    public List<CryptometaAsset> Assets { get; set; } = new();

    #endregion

}