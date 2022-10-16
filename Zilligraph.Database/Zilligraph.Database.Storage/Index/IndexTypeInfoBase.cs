using Zillifriends.Shared.Common;
using Zilligraph.Database.Contract;

namespace Zilligraph.Database.Storage.Index
{
    public abstract class IndexTypeInfoBase
    {
        private byte[]? _nullHash;

        public static IndexTypeInfoBase Create(Type valueType, IndexAttributeBase indexAttribute)
        {
            if (valueType == typeof(string))
            {
                return new IndexTypeInfoText(indexAttribute.CaseInsensitive);
            }
            if (valueType == typeof(int))
            {
                return new IndexTypeInfoInt32();
            }
            if (valueType == typeof(long))
            {
                return new IndexTypeInfoInt64();
            }
            if (valueType == typeof(DateTime))
            {
                return new IndexTypeInfoDate();
            }

            throw new RuntimeException($"value Type {valueType} not supported as Index");
        }

        protected byte[] NullHash => _nullHash ??= new byte[HashLength];

        public abstract int HashLength { get; }

        public virtual int MaxIndexChainLength => 0;

        public abstract byte[] GetHashBytes(object? value);
    }
}
