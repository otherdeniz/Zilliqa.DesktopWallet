using System.Globalization;
using System.Runtime.CompilerServices;

namespace Zilliqa.DesktopWallet.Core.Extensions
{
    public static class AsyncExtensions
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Task RunWithCurrentCulture(this Action action)
        {
            CultureInfo culture = Thread.CurrentThread.CurrentCulture;
            CultureInfo uiculture = Thread.CurrentThread.CurrentUICulture;
            return Task.Run(() =>
            {
                Thread.CurrentThread.CurrentCulture = culture;
                Thread.CurrentThread.CurrentUICulture = uiculture;
                action.Invoke();
            });
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Task<TResult> RunWithCurrentCulture<TResult>(this Func<TResult> function)
        {
            CultureInfo culture = Thread.CurrentThread.CurrentCulture;
            CultureInfo uiculture = Thread.CurrentThread.CurrentUICulture;
            return Task.Run(() =>
            {
                Thread.CurrentThread.CurrentCulture = culture;
                Thread.CurrentThread.CurrentUICulture = uiculture;
                return function.Invoke();
            });
        }

    }

}
