namespace Zilliqa.DesktopWallet.Core.ViewModel
{
    public class ValueNumberDisplay
    {
        public ValueNumberDisplay(decimal baseNumber, string displayText)
        {
            BaseNumber = baseNumber;
            DisplayText = displayText;
        }

        public decimal BaseNumber { get; }

        public string DisplayText { get; }

        public override string ToString()
        {
            return DisplayText;
        }
    }
}
