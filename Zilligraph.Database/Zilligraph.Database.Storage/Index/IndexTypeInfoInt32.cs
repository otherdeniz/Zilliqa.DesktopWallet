namespace Zilligraph.Database.Storage.Index;

public class IndexTypeInfoInt32 : IndexTypeInfoBase
{
    public override int HashLength => 4;

    public override byte[] GetHashBytes(object? value)
    {
        if (value is int intValue)
        {
            return BitConverter.GetBytes(intValue);
        }

        return NullHash;
    }
}