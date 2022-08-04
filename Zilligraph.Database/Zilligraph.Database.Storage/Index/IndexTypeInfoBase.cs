using Zillifriends.Shared.Common;

namespace Zilligraph.Database.Storage.Index
{
    public abstract class IndexTypeInfoBase
    {
        private byte[]? _nullHash;

        public static IndexTypeInfoBase Create(Type valueType)
        {
            if (valueType == typeof(string))
            {
                return new IndexTypeInfoText();
            }

            throw new RuntimeException($"value Type {valueType} not supported");
        }

        protected byte[] NullHash => _nullHash ??= new byte[HashLength];

        public abstract int HashLength { get; }

        public abstract byte[] GetHashBytes(object value);
    }
}
