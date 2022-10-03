namespace Zilliqa.DesktopWallet.Core.ViewModel.ValueModel
{
    public class BlockNumberValue : IDetailsViewModel
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

        public string GetUniqueId()
        {
            return $"Block-{BlockNumber}";
        }

        public string GetDisplayTitle()
        {
            return $"Block: {ToString()}";
        }
    }
}
