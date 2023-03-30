namespace Zillifriends.Shared.Common
{
    public class StatusProgressText
    {
        public StatusProgressText(string statusText)
        {
            StatusText = statusText;
        }

        public string StatusText { get; }

        public long ItemCount { get; set; }

        public long CurrentItem { get; set; }

        public override string ToString()
        {
            if (ItemCount == 0)
            {
                return StatusText;
            }
            return $"{StatusText} ({100m / Convert.ToDecimal(ItemCount) * Convert.ToDecimal(CurrentItem):0}%)";
        }
    }
}
