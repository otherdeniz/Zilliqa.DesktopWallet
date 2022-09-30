#pragma warning disable S3908 // Generic event handlers should be used
#pragma warning disable S3906 // Event Handlers should have the correct signature
#pragma warning disable S3874 // "out" and "ref" parameters should not be used
namespace Zilliqa.DesktopWallet.Gui.WinForms
{
    public delegate void WndProcDelegate(Message m, ref bool cancel);

    public interface ISingleInstanceForm
    {
        IntPtr Handle { get; }

        event WndProcDelegate WindowProcessMessage;

        void HandleCommand(string[] arguments);
    }
}
#pragma warning restore S3874 // "out" and "ref" parameters should not be used
#pragma warning restore S3906 // Event Handlers should have the correct signature
#pragma warning restore S3908 // Generic event handlers should be used
