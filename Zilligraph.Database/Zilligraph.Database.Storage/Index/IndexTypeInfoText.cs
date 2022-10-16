using Zillifriends.Shared.Common;

namespace Zilligraph.Database.Storage.Index
{
    public class IndexTypeInfoText : IndexTypeInfoBase
    {
        private readonly bool _caseInsensitive;

        public IndexTypeInfoText(bool caseInsensitive)
        {
            _caseInsensitive = caseInsensitive;
        }

        public override int HashLength => 16;

        public override int MaxIndexChainLength => 5000;

        public override byte[] GetHashBytes(object? value)
        {
            if (value is string { Length: > 0 } stringValue)
            {
                return _caseInsensitive
                    ? stringValue.ToLower().GetMd5()
                    : stringValue.GetMd5();
            }

            return NullHash;
        }
    }
}
