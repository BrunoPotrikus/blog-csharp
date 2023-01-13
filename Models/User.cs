using Blog.Interfaces;
using Blog.Repositories;
using Blog.ValueObjects;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Models
{
    [Table("[User]")]

    public class User : Entity<User>
    {
        public Name Name { get; private set; }
        public Email Email { get; private set; }
        public string PasswordHash { get; private set; }
        public string Bio { get; private set; }
        public string Image { get; private set; }
        public string Slug { get; private set; }

        public User(SqlConnection connection) : base(connection)
        {

        }      
    }
}
