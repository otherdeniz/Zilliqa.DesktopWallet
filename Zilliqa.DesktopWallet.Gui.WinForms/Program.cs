using System.Diagnostics;
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
        static void Main(string[] arguments)
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            DataPathBuilder.Setup("ZilliqaDesktopWallet");

            Debug.WriteLine($"arguments: {arguments.Length}");

            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}