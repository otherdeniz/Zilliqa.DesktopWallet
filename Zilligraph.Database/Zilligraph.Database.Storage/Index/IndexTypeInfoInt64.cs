namespace Zilligraph.Database.Storage.Index;

public class IndexTypeInfoInt64 : IndexTypeInfoBase
{
    public override int HashLength => 8;

    public override byte[] GetHashBytes(object? value)
    {
        if (value is long longValue)
        {
            return BitConverter.GetBytes(longValue);
        }

        return NullHash;
    }
}