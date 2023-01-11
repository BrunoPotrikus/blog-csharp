using Blog.Models;
using Blog.Repositories;
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
        var connection = new SqlConnection(CONNECTION_STRING);
        connection.Open();

        //ReadUsers(connection);
        //ReadRoles(connection);
        //ReadTags(connection);
        CreateUser(connection);

        connection.Close();
    }

    public static void ReadUsers(SqlConnection connection)
    {
        var repository = new Repository<User>(connection);
        var items = repository.GetAll();

        foreach (var item in items)
        {
            Console.WriteLine(item.Name);
        }
    }

    public static void ReadRoles(SqlConnection connection)
    {
        var repository = new Repository<Role>(connection);
        var items = repository.GetAll();

        foreach (var item in items)
        {
            Console.WriteLine(item.Name);
        }
    }

    public static void ReadTags(SqlConnection connection)
    {
        var repository = new Repository<Tag>(connection);
        var items = repository.GetAll();

        foreach (var item in items)
        {
            Console.WriteLine(item.Name);
        }
    }

    public static void CreateUser(SqlConnection connection)
    {
        var user = new User(connection)
        {
            Bio = "Desenvolvimento Backend .NET",
            Email = "suportedotnet@email.com",
            Image = "https://image",
            Name = "Equipe de desenvolvimento .NET",
            PasswordHash = "passwordhash",
            Slug = "equipe-suporte-dotnet"
        };

        user.CreateUser(user);
    }

    public static void UpdateUser(SqlConnection connection)
    {
        var user = new User(connection)
        {
            Id = 2,
            Bio = "Desenvolvimento Backend .NET",
            Email = "devdotnet@email.com",
            Image = "https://image",
            Name = "Equipe de suporte .NET",
            PasswordHash = "passwordhash",
            Slug = "equipe-dev-dotnet"
        };

        user.UpdateUser(user);
    }

    public static void DeleteUser()
    {
        using (var connection = new SqlConnection(CONNECTION_STRING))
        {
            var user = connection.Get<User>(2);
            var updateUser = connection.Delete<User>(user);

            Console.WriteLine($"O usuário {user.Name} foi removido com sucesso");
        }
    }
}