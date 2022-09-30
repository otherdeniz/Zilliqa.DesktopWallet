using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

#pragma warning disable S1854 // Dead stores should be removed
#pragma warning disable S3963 // "static" fields should be initialized inline
namespace Zilliqa.DesktopWallet.Gui.WinForms
{
    public class SingleInstance
    {
        private const int WM_COPYDATA = 0x4a;
        private const int SW_RESTORE = 9;

        private static readonly EnumWindowsProc EnumWindowProcedure = new EnumWindowsProc(Ewp);
        private static int _mainFormWindowHandle = -1;
        private static readonly string McThisAppId;
        private static Mutex? _oMutex;
        private static readonly bool MutexOwned;
        private static ISingleInstanceForm _mainForm;

        static SingleInstance()
        {
            McThisAppId = Assembly.GetEntryAssembly().FullName;
            _oMutex = new Mutex(true, McThisAppId + "_APPLICATION_MUTEX", out MutexOwned);
            if (!MutexOwned)
            {
                //try to find window for 1 sec
                MutexOwned = true;
                var startTime = DateTime.Now;
                do
                {
                    if (FindWindow())
                    {
                        //another window found
                        MutexOwned = false;
                        break;
                    }
                    Task.Run(async () => { await Task.Delay(250).ConfigureAwait(false); });
                } while ((DateTime.Now - startTime).TotalSeconds < 1);
            }
            AppDomain.CurrentDomain.ProcessExit += OnExit;
        }

        public static bool IsFirstInstance => MutexOwned;

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr GetProp(IntPtr hWnd, string lpString);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr SetProp(IntPtr hWnd, string lpString, IntPtr hData);

        [DllImport("user32.dll")]
        private static extern IntPtr EnumWindows(EnumWindowsProc enumProc, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint message, UIntPtr wParam, IntPtr lParam);

        private static void OnExit(object sender, EventArgs e)
        {
            try
            {
                if (_oMutex != null)
                {
                    _oMutex.ReleaseMutex();
                    ((IDisposable)_oMutex).Dispose();
                    _oMutex = null;
                }
            }
            catch
            {
                //Do Nothing
            }
        }

        public static bool NotifyPreviousWindow()
        {
            return SendMessageToWindow(new string[] { }.SerializeToBase64String());
        }

        public static bool NotifyPreviousWindow(string[] arguments)
        {
            return SendMessageToWindow(arguments.SerializeToBase64String());
        }

        public static void SetMainForm(ISingleInstanceForm frm)
        {
            _mainForm = frm;
            try
            {
                SetProp(frm.Handle, McThisAppId + "_APPLICATION", 1.ToIntPtr());
                frm.WindowProcessMessage += MainForm_WndProc;
            }
            catch
            {
                _mainForm = null;
            }
        }

        private static void MainForm_WndProc(Message m, ref bool cancel)
        {
            switch (m.Msg)
            {
                case WM_COPYDATA:
                    byte[] byteArray;
                    try
                    {
                        var copyDataStruct = (CopyDataStruct) m.GetLParam(typeof(CopyDataStruct));
                        byteArray = new byte[copyDataStruct.cbData];
                        var lpData = new IntPtr(copyDataStruct.lpData);
                        Marshal.Copy(lpData, byteArray, 0, copyDataStruct.cbData);
                        var strData = Encoding.Default.GetString(byteArray);
                        var args = strData.DeserializeFromBase64String() as string[];
                        _mainForm.HandleCommand(args);
                        WindowStateRestore();
                        cancel = true;
                    }
                    catch
                    {
                        cancel = false;
                    }
                    finally
                    {
                        byteArray = null;
                    }

                    break;
                default:
                    cancel = false;
                    break;
            }
        }

        private static int Ewp(IntPtr hWnd, int lParam)
        {
            // Customised windows enumeration procedure.  Stops
            // when it finds another application with the Window
            // property set, or when all windows are exhausted.
            try
            {
                if (IsThisApp(hWnd))
                {
                    _mainFormWindowHandle = hWnd.ToInt32();
                    return 0;
                }
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        private static bool IsThisApp(IntPtr hWnd)
        {
            // Check if the windows property is set for this
            // window handle:
            return GetProp(hWnd, McThisAppId + "_APPLICATION").ToInt32() == 1;
        }

        private static bool FindWindow()
        {
            if (_mainFormWindowHandle == -1)
            {
                EnumWindows(EnumWindowProcedure, 0.ToIntPtr());
                if (_mainFormWindowHandle == -1)
                {
                    return false;
                }
            }
            return true;
        }

        private static void WindowStateRestore()
        {
            ShowWindow(_mainFormWindowHandle.ToIntPtr(), SW_RESTORE);
        }


        private static bool SendCdsToWindow(CopyDataStruct cd)
        {
            try
            {
                var lpCd = Marshal.AllocHGlobal(Marshal.SizeOf(cd));
                Marshal.StructureToPtr(cd, lpCd, false);
                SendMessage(_mainFormWindowHandle.ToIntPtr(), WM_COPYDATA,
                    new UIntPtr(Convert.ToUInt32(_mainFormWindowHandle)), lpCd);
                Marshal.FreeHGlobal(lpCd);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static bool SendMessageToWindow(string strCmd)
        {
            if (_mainFormWindowHandle == -1)
                return false;
            if (strCmd.Length == 0)
            {
                try
                {
                    var copyDataStruct = new CopyDataStruct {cbData = 0, dwData = 0, lpData = 0};
                    return SendCdsToWindow(copyDataStruct);
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                try
                {
                    var byteArray = Encoding.Default.GetBytes(strCmd);
                    var lpB = Marshal.AllocHGlobal(byteArray.Length);
                    Marshal.Copy(byteArray, 0, lpB, byteArray.Length);
                    var copyDataStruct =
                        new CopyDataStruct {cbData = byteArray.Length, dwData = 0, lpData = lpB.ToInt32()};

                    byteArray = null;

                    try
                    {
                        if (SendCdsToWindow(copyDataStruct))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    catch
                    {
                        return false;
                    }
                    finally
                    {
                        Marshal.FreeHGlobal(lpB);
                    }
                }
                catch
                {
                    return false;
                }
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct CopyDataStruct
        {
            public int dwData;
            public int cbData;
            public int lpData;
        }

        private delegate int EnumWindowsProc(IntPtr hWnd, int lParam);
    }

    internal static class SerializerExtensions
    {
        public static string SerializeToBase64String(this object graph)
        {
            var formatter = new BinaryFormatter();
            using (var serialMemoryStream = new MemoryStream())
            {
                formatter.Serialize(serialMemoryStream, graph);
                var bytes = serialMemoryStream.ToArray();
                return Convert.ToBase64String(bytes).Trim();
            }
        }

        public static object DeserializeFromBase64String(this string base64String)
        {
            var formatter = new BinaryFormatter();
            base64String = base64String.Trim();
            var bytes = Convert.FromBase64String(base64String);
            using (var serialMemoryStream = new MemoryStream(bytes))
            {
                try
                {
                    return formatter.Deserialize(serialMemoryStream);
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
    }

    internal static class DllImportExtensions
    {
        public static IntPtr ToIntPtr(this int value)
        {
            return new IntPtr(value);
        }
    }

}
#pragma warning restore S1854 // Dead stores should be removed
#pragma warning restore S3963 // "static" fields should be initialized inline
