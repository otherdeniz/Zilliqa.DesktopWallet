using Zilliqa.DesktopWallet.Core;
using Zilliqa.DesktopWallet.Core.Data.Files;
using Zilliqa.DesktopWallet.Core.Services;
using Zilliqa.DesktopWallet.Gui.WinForms.Controls.Notification;
using Color = System.Drawing.Color;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Main
{
    public partial class BottomNotificationsControl : UserControl
    {
        public BottomNotificationsControl()
        {
            InitializeComponent();
        }

        private void BottomNotificationsControl_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                NotificationService.Instance.IncomingZilTransaction += OnIncomingZilTransaction;
                NotificationService.Instance.IncomingTokenTransaction += OnIncomingTokenTransaction;
            }
        }

        private void OnIncomingTokenTransaction(object? sender, NotificationService.IncominTokenTransactionEventArgs e)
        {
            WinFormsSynchronisationContext.ExecuteSynchronized(() =>
            {
                var control = new IncomingTokenNotificationControl();
                control.LoadData(e.AccountViewModel, e.TransactionViewModel);
                AddNotificationControl(control);
                SoundPlayer.PlaySound(SettingsFile.Instance.IncomingSound);
            });
        }

        private void OnIncomingZilTransaction(object? sender, NotificationService.IncominZilTransactionEventArgs e)
        {
            WinFormsSynchronisationContext.ExecuteSynchronized(() =>
            {
                var control = new IncomingZilNotificationControl();
                control.LoadData(e.AccountViewModel, e.TransactionViewModel);
                AddNotificationControl(control);
                SoundPlayer.PlaySound(SettingsFile.Instance.IncomingSound);
            });
        }

        private void AddNotificationControl(NotificationBaseControl control)
        {
            if (Controls.Count >= 10)
            {
                var removeControl = Controls[0];
                Controls.Remove(removeControl);
                removeControl.Dispose();
            }
            control.UnselectedBackColor = Color.Yellow;
            control.Dock = DockStyle.Left;
            Controls.Add(control);
            timerRefresh.Enabled = true;
            Refresh();
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            if (ParentForm!.WindowState == FormWindowState.Minimized) return;
            foreach (var notificationControl in Controls.OfType<NotificationBaseControl>().ToList())
            {
                notificationControl.RefreshTimeInfo();
                if (notificationControl.DisplayTicks >= 1200)
                {
                    Controls.Remove(notificationControl);
                    notificationControl.Dispose();
                }
                else
                {
                    if (notificationControl.DisplayTicks <= 100)
                    {
                        var fadeColor = FadeColor(Color.Yellow, Color.White, notificationControl.DisplayTicks);
                        notificationControl.UnselectedBackColor = fadeColor;
                    }
                    notificationControl.DisplayTicks++;
                }
            }
            if (Controls.Count == 0)
            {
                timerRefresh.Enabled = false;
            }
        }

        private Color FadeColor(Color fromColor, Color toColor, int fadePercent)
        {
            if (fadePercent == 0)
            {
                return fromColor;
            }
            if (fadePercent >= 100)
            {
                return toColor;
            }

            int red = fromColor.R;
            if (toColor.R < red)
            {
                red = Convert.ToInt32(Convert.ToDecimal(red - toColor.R) / 100m * Convert.ToDecimal(fadePercent)) 
                      + toColor.R;
            }
            else if (toColor.R > red)
            {
                red = Convert.ToInt32(Convert.ToDecimal(toColor.R - red) / 100m * Convert.ToDecimal(fadePercent))
                      + red;
            }
            int green = fromColor.G;
            if (toColor.G < green)
            {
                green = Convert.ToInt32(Convert.ToDecimal(green - toColor.G) / 100m * Convert.ToDecimal(fadePercent))
                        + toColor.G;
            }
            else if (toColor.G > green)
            {
                green = Convert.ToInt32(Convert.ToDecimal(toColor.G - green) / 100m * Convert.ToDecimal(fadePercent))
                        + green;
            }
            int blue = fromColor.B;
            if (toColor.B < blue)
            {
                blue = Convert.ToInt32(Convert.ToDecimal(blue - toColor.B) / 100m * Convert.ToDecimal(fadePercent))
                       + toColor.B;
            }
            else if (toColor.B > blue)
            {
                blue = Convert.ToInt32(Convert.ToDecimal(toColor.B - blue) / 100m * Convert.ToDecimal(fadePercent))
                       + blue;
            }
            return Color.FromArgb(red, green, blue);
        }
    }
}
