namespace Zilliqa.DesktopWallet.ViewModelAttributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DetailsTitleAttribute: Attribute
    {

        public DetailsTitleAttribute(string image48Property, string titleProperty, string subTitleProperty)
        {
            Image48Property = image48Property;
            TitleProperty = titleProperty;
            SubTitleProperty = subTitleProperty;
        }

        public string Image48Property { get; }
        public string TitleProperty { get; }
        public string SubTitleProperty { get; }

    }
}
