using Blog.Notifications;

namespace Blog.ValueObjects
{
    public class Name : Notifiable
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            if (string.IsNullOrEmpty(FirstName))
            {   
                AddNotification("FirstName", "Nome não pode estar em branco");    
            }

            if (string.IsNullOrEmpty(LastName))
            {
                AddNotification("LastName", "Sobrenome não pode estar em branco");
            }

            foreach (var notification in Notifications)
            {
                Console.WriteLine(notification.Message);
            }
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
