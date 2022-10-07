namespace Zilliqa.DesktopWallet.Core.ViewModel.ValueModel
{
    public class BlockNumberValue : IDetailsLabel, IDetailsViewModel
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

        public object GetViewModel()
        {
            try
            {
                return new BlockViewModel(BlockNumber);
            }
            catch (Exception e)
            {
                return new ErrorDetailsViewModel(e.Message);
            }
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
