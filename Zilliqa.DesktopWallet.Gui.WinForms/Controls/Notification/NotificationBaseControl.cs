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
                var timeAgoText = CreatedTimestamp.Value.GetTimeAgoText();
                labelTimeInfo.Text = $"{CreatedTimestamp.Value:g} - {timeAgoText} ago";
            }
        }
    }
}
