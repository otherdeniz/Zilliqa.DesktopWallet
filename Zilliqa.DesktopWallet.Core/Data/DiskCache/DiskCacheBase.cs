using Zillifriends.Shared.Common;
using Zilliqa.DesktopWallet.Core.Cryptography;

namespace Zilliqa.DesktopWallet.Core.Data.DiskCache
{
    public abstract class DiskCacheBase
    {
        private readonly object _itemSyncLock = new();

        protected DiskCacheBase(string cachingFolderName)
        {
            CachingFolderName = cachingFolderName;
            DataPathBuilder = DataPathBuilder.AppDataRoot.GetSubFolder(cachingFolderName);
        }

        protected string CachingFolderName { get; }

        protected DataPathBuilder DataPathBuilder { get; }

        public byte[] GetItemData(string name, Func<byte[]> createItem)
        {
            var nameHash = name.GetMD5Hex();
            var itemFilePath = DataPathBuilder.GetFilePath(nameHash);
            if (File.Exists(itemFilePath))
            {
                return ReadFile(itemFilePath);
            }

            lock (_itemSyncLock)
            {
                if (File.Exists(itemFilePath))
                {
                    return ReadFile(itemFilePath);
                }
                var createdItem = createItem();
                using (var targetStream = File.Create(itemFilePath))
                {
                    targetStream.Write(createdItem, 0, createdItem.Length);
                }

                return createdItem;
            }
        }

        private byte[] ReadFile(string fullPath)
        {
            using (var fileStream = File.Open(fullPath, FileMode.Open))
            {
                using (var memoryStream = new MemoryStream(Convert.ToInt32(fileStream.Length)))
                {
                    fileStream.CopyTo(memoryStream);
                    memoryStream.Position = 0;
                    return memoryStream.ToArray();
                }
            }
        }

    }
}
