using System.Text;

namespace Zillifriends.Shared.Common
{
    public static class ByteExtensions
    {
        public static string ByteToHexString(this byte value)
        {
            return (new[] { value }).ByteArrayToHexString();
        }

        public static string ByteArrayToHexString(this byte[] bytes)
        {
            var sb = new StringBuilder(bytes.Length * 3);
            foreach (var b in bytes)
            {
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0').PadRight(3, ' '));
            }
            return sb.ToString().ToUpper().Replace(" ", "");
        }

        public static byte Byte8BitTo4Bit(this byte byte8Bit)
        {
            return (byte)(byte8Bit % 16);
        }
    }
}
