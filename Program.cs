using Blog.Models;
using Blog.Repositories;
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
        var connection = new SqlConnection(CONNECTION_STRING);
        connection.Open();

        ReadUsers(connection);
        ReadRoles(connection);

        connection.Close();
    }

    public static void ReadUsers(SqlConnection connection)
    {
        var userRepository = new Repository<User>(connection);
        var users = userRepository.GetAll();

        foreach (var user in users)
        {
            Console.WriteLine(user.Name);
        }
    }

    public static void ReadRoles(SqlConnection connection)
    {
        var roleRepository = new RoleRepository(connection);
        var roles = roleRepository.GetAll();

        foreach (var role in roles)
        {
            Console.WriteLine(role.Name);
        }
    }

    public static void CreateUser()
    {
        var user = new User()
        {
            Bio = "Desenvolvimento Backend .NET",
            Email = "devdotnet@email.com",
            Image = "https://image",
            Name = "Equipe de desenvolvimento .NET",
            PasswordHash = "passwordhash",
            Slug = "equipe-dev-dotnet"
        };

        using (var connection = new SqlConnection(CONNECTION_STRING))
        {
            var insertUser = connection.Insert<User>(user);

            Console.WriteLine($"O usuário {user.Name} foi cadastrado com sucesso");
        }
    }

    public static void UpdateUser()
    {
        var user = new User()
        {
            Id = 2,
            Bio = "Desenvolvimento Backend .NET",
            Email = "devdotnet@email.com",
            Image = "https://image",
            Name = "Equipe de suporte .NET",
            PasswordHash = "passwordhash",
            Slug = "equipe-dev-dotnet"
        };

        using (var connection = new SqlConnection(CONNECTION_STRING))
        {
            var updateUser = connection.Update<User>(user);

            Console.WriteLine($"O usuário {user.Name} foi atualizado com sucesso");
        }
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