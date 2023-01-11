using Blog.Models;
using Microsoft.Data.SqlClient;

namespace Blog.Interfaces
{
    public interface IUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Bio{ get; set; }
        public string Image { get; set; }
        public string Slug { get; set; }

        public void CreateUser(User user);
        public abstract static User ReadUser(SqlConnection connection, int id);
        public void UpdateUser(User user);
        public void DeleteUser(User user);
        public void DeleteUser(int id);
    }
}
