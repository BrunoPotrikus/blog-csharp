using Blog.Interfaces;
using Blog.Repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Models
{
    [Table("[User]")]

    public class User : IUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Bio { get; set; }
        public string Image { get; set; }
        public string Slug { get; set; }

        private static Repository<User> _repository;

        public User(SqlConnection connection)
        {
            _repository = new Repository<User>(connection);
        }

        public void CreateUser(User user)
        {
            _repository.Create(user);
        }

        public static User ReadUser(SqlConnection connection, int id)
        {
            _repository = new Repository<User>(connection);
            return _repository.Get(id);
        }

        public void UpdateUser(User user)
        {
            _repository.Update(user);
        }

        public void DeleteUser(User user)
        {
            _repository.Delete(user);
        }

        public void DeleteUser(int id)
        {
            _repository.Delete(id);
        }
    }
}
