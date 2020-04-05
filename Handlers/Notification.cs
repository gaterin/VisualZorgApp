using Tulpep.NotificationWindow;

namespace VisualZorgApp.Handlers
{
    // Notification class
    // Overload constructor used to popup when creating the Notification
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
