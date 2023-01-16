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
        var user = new User();

        Console.Write("Adicione um nome: ");
        user.Name = Console.ReadLine();

        Console.Write("Adicione uma Bio: ");
        user.Bio = Console.ReadLine();

        Console.Write("Adicione um Email: ");
        user.Email = Console.ReadLine();

        Console.Write("Adicione uma Imagem: ");
        user.Image = Console.ReadLine();

        Console.Write("Defina sua senha: ");
        user.PasswordHash = Console.ReadLine();

        Console.Write("Como te encontrar: ");
        user.Slug = Console.ReadLine();

        connection.Open();

        //ReadUsers(connection);
        //ReadRoles(connection);
        //ReadTags(connection);
        CreateUser(connection, user);
        CreateRole(connection, user, "Programação .NET", "programacao-dotnet");
        CreateUserRole(connection, user);
        //ReadUserRoles(connection);

        connection.Close();
    }

    public static void ReadUsers(SqlConnection connection)
    {
        var repository = new UserRepository(connection);
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

    public static void CreateUser(SqlConnection connection, User user)
    {
        var repository = new UserRepository(connection);
        repository.Create(user);
    }

    public static void CreateRole(SqlConnection connection, User user, string nome, string slug)
    {
        var repository = new Repository<Role>(connection);
        user.CreateRole(repository, nome, slug);
    }

    public static void CreateUserRole(SqlConnection connection, User user)
    {
        var repository = new Repository<UserRole>(connection);
        foreach(var role in user.Roles)
        {
            var userRole = new UserRole(user.Id, role.Id);
            repository.Create(userRole);
        }
    }

    //public static void UpdateUser(SqlConnection connection)
    //{
    //    var repository = new UserRepository(connection);
    //    var user = new User();
    //    user.Id = 2;
    //    user.Bio = "Desenvolvimento Backend .NET";
    //    user.Email = "devdotnet@email.com";
    //    user.Image = "https://image";
    //    user.Name = "Chico";
    //    user.PasswordHash = "passwordhash";
    //    user.Slug = "equipe-dev-dotnet";

    //    repository.Update(user);
    //}

    //public static void DeleteUser()
    //{
    //    using (var connection = new SqlConnection(CONNECTION_STRING))
    //    {
    //        var user = connection.Get<User>(2);
    //        var updateUser = connection.Delete<User>(user);

    //        Console.WriteLine($"O usuário {user.Name} foi removido com sucesso");
    //    }
    //}

    //public static void ReadUserRoles(SqlConnection connection)
    //{
    //    var repository = new UserRepository(connection);
    //    var items = repository.GetUserRoles();

    //    foreach(var item in items)
    //    {
    //        Console.WriteLine(item.Name);
    //        foreach(var role in item.Roles)
    //        {
    //            Console.WriteLine(role.Name);
    //        }
    //    }
    //}
}