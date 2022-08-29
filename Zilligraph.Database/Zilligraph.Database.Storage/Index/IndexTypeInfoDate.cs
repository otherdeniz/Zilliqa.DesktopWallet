namespace Zilligraph.Database.Storage.Index;

public class IndexTypeInfoDate : IndexTypeInfoBase
{
    private static readonly DateTime FirstDay = new DateTime(1, 1, 1);

    public override int HashLength => 4;

    public override int MaxIndexChainLength => 5000;

    public override byte[] GetHashBytes(object? value)
    {
        if (value is DateTime dateValue)
        {
            return BitConverter.GetBytes((dateValue - FirstDay).Days);
        }

        return NullHash;
    }
}