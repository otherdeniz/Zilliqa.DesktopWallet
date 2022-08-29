namespace Zilliqa.DesktopWallet.Core.ViewModel.ValueModel
{
    public class BlockNumberValue
    {
        public BlockNumberValue(long blockNumber)
        {
            BlockNumber = blockNumber;
        }

        public long BlockNumber { get; }

        public override string ToString()
        {
            return BlockNumber.ToString("#,##0");
        }
    }
}
