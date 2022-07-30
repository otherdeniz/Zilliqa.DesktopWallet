namespace Zillifriends.Shared.Common
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DatFileNameAttribute : Attribute
    {
        public DatFileNameAttribute(string filename)
        {
            Filename = filename;
        }

        public string Filename { get; }
    }
}
