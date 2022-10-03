namespace Zilliqa.DesktopWallet.ViewModelAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DetailsPropertyAttribute : Attribute
    {
        public DetailsPropertyAttribute(DetailsPropertyType propertyType = DetailsPropertyType.AutoDetect)
        {
            PropertyType = propertyType;
        }

        public DetailsPropertyType PropertyType { get; }
    }

    public enum DetailsPropertyType
    {
        AutoDetect = 0,
        Text = 1,
        Address = 2,
        //Number = 3,
        //Amount = 4,
        Url = 5,
        //Date = 6,
        //DateTime = 7,
        BlockNumber = 8,
        TransactionId = 9,
        TextList = 101,
        AddressList = 102
    }
}
