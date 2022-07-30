using Zillifriends.Shared.Common;
using Zilliqa.DesktopWallet.Core.Data;

namespace Zilliqa.DesktopWallet.Gui.WinForms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            DataPathBuilder.Setup("ZilliqaDesktopWallet");

            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}