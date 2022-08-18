namespace Zillifriends.Shared.Common
{
    public class RuntimeException : Exception
    {
        public RuntimeException(string message) 
            : base(message)
        {
        }

        public RuntimeException(string message, Exception innerException) 
            : base (message, innerException)
        {
        }
    }
}
