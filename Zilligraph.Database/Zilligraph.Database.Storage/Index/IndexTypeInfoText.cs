using Zillifriends.Shared.Common;

namespace Zilligraph.Database.Storage.Index
{
    public class IndexTypeInfoText : IndexTypeInfoBase
    {
        public override int HashLength => 16;

        public override byte[] GetHashBytes(object? value)
        {
            if (value is string { Length: > 0 } stringValue)
            {
                return stringValue.GetMd5();
            }

            return NullHash;
        }
    }
}
