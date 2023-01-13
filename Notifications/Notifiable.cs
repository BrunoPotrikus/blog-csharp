namespace Blog.Notifications
{
    public class Notifiable
    {
        public Notifiable()
        {
            Notifications = new List<Notification>();
        }

        public IList<Notification> Notifications { get; set; }

        public void AddNotification(string property, string message)
        {
            var notification = new Notification(property, message);
            Notifications.Add(notification);
        }
    }
}
