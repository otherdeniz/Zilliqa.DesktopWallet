namespace Zilliqa.DesktopWallet.Core
{
    public static class WinFormsSynchronisationContext
    {
        public static SynchronizationContext? WinFormsMainContext { get; set; }

        public static void ExecuteSynchronized(Action action)
        {
            if (WinFormsMainContext != null && WinFormsMainContext != SynchronizationContext.Current)
            {
                //Send - synchronous: wait for answer(or action completed)
                //Post - asynchronous: drop off and continue
                WinFormsMainContext.Send(args => action(), null);
            }
            else
            {
                action();
            }
        }
    }
}
