namespace Zilliqa.DesktopWallet.Core
{
    public static class WinFormsSynchronisationContext
    {
        public static SynchronizationContext? WinFormsMainContext { get; set; }

        public static void ExecuteSynchronized(Action action)
        {
            if (WinFormsMainContext != null && WinFormsMainContext != SynchronizationContext.Current)
            {
                WinFormsMainContext.Send(args => action(), null);
            }
            else
            {
                action();
            }
        }

        public static void ExecuteSynchronizedAndWait(Action action)
        {
            if (WinFormsMainContext != null && WinFormsMainContext != SynchronizationContext.Current)
            {
                WinFormsMainContext.Post(args => action(), null);
            }
            else
            {
                action();
            }
        }
    }
}
