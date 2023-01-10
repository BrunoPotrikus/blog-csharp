using Blog.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

public class Program
{
    private const string CONNECTION_STRING = "Server=localhost,1433;" +
                                             "Database=Blog;" +
                                             "User ID=sa;" +
                                             "Password=H2g@5dT$;" +
                                             "Trusted_Connection=False;" +
                                             "TrustServerCertificate=True";

    public static void Main(string[] args)
    {
        ReadUsers();
    }

    public static void ReadUsers()
    {
        using(var connection = new SqlConnection(CONNECTION_STRING))
        {
            var users = connection.GetAll<User>();

            foreach(var user in users)
            {
                Console.WriteLine(user.Name);
            }
        }
    }
}