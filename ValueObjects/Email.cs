namespace Blog.ValueObjects
{
    public class Email
    {
        public Email(string address)
        {
            Address = address;

            if (string.IsNullOrEmpty(address))
            {
                Console.WriteLine("Email inválido!");
            }
        }

        public string Address { get; private set; }

        public string SetEmail(string email)
        {
           Address = email;
            return Address;
        }
    }
}
