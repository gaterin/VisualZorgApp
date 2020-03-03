using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tulpep.NotificationWindow;

namespace VisualZorgApp
{
    class Notification : PopupNotifier
    {
        public Notification(string title, string message)
        {
            SetTitle(title);
            SetMessage(message);
        }
        public Notification(string title, string message, bool popupNotification)
        {
            SetTitle(title);
            SetMessage(message);

            if(popupNotification == true)
            {
                Popup();
            }
            
        }

        public string GetTitle()
        {
            return TitleText;
        }
        public string GetMessage()
        {
            return ContentText;
        }

        public void SetTitle(string title)
        {
            this.TitleText = title;
        }
        public void SetMessage(string message)
        {
            this.ContentText = message;
        }
    }
}
