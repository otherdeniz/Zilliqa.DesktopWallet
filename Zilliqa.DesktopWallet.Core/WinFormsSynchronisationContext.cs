namespace Zilliqa.DesktopWallet.Core
{
    public static class WinFormsSynchronisationContext
    {
        public static SynchronizationContext? WinFormsMainContext { get; set; }

        public static void ExecuteSynchronized(Action action)
        {
            if (WinFormsMainContext != null)
            {
                WinFormsMainContext.Send(args => action(), null);
            }
            else
            {
                action();
            }
        }
    }
}
