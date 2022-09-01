namespace Zilliqa.DesktopWallet.Core.ViewModel.ValueModel
{
    public class BlockNumberValue
    {
        public BlockNumberValue(int blockNumber)
        {
            BlockNumber = blockNumber;
        }

        public int BlockNumber { get; }

        public override string ToString()
        {
            return BlockNumber.ToString("#,##0");
        }
    }
}
