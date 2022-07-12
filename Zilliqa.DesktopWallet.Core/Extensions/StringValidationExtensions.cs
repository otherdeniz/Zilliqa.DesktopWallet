using System.Text.RegularExpressions;

namespace Zilliqa.DesktopWallet.Core.Extensions
{
    public static class StringValidationExtensions
    {
        //E-Mail validation Regex explenation -> http://haacked.com/archive/2007/08/21/i-knew-how-to-validate-an-email-address-until-i.aspx/
        public static bool IsValidEmailAddress(this string email)
        {
            const string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                                   + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                                   + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }

        public static bool IsValidMobileNr(this string mobileNr)
        {
            const string pattern = @"^(\+|[00])?(\d|[ ]|[-]|[/]|\(|\)){10,24}$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(mobileNr);
        }

        public static string GetCompareMobileNr(this string mobileNumber)
        {
            var mobileNrComparRegex = new Regex("[^1-9]");
            var nr = mobileNrComparRegex.Replace(mobileNumber, "");
            int maxL = 7;
            if (nr.Length <= maxL)
                return nr;
            return nr.Substring(nr.Length - maxL, maxL);
        }

    }
}
