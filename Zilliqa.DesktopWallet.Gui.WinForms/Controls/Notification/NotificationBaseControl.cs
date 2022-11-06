using System.ComponentModel;
using Zillifriends.Shared.Common;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Notification
{
    public partial class NotificationBaseControl : HighlitableBaseControl
    {
        public NotificationBaseControl()
        {
            InitializeComponent();
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime? CreatedTimestamp { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int DisplayTicks { get; set; }

        public void RefreshTimeInfo()
        {
            if (CreatedTimestamp != null)
            {
                var localTime = CreatedTimestamp.Value.ToLocalTime();
                var timeAgoText = localTime.GetTimeAgoText();
                labelTimeInfo.Text = $"{localTime:g} - {timeAgoText} ago";
            }
        }
    }
}
