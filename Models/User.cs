using Blog.Interfaces;
using Blog.Repositories;
using Blog.ValueObjects;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Models
{
    [Table("[User]")]

    public class User : Entity
    {
        public User()
        {
            Roles = new List<Role>();
        }

        public string Name { get; set; }
        public string Email { get; set;  }
        public string PasswordHash { get;  set; }
        public string Bio { get;  set; }
        public string Image { get;  set; }
        public string Slug { get;  set; }

        [Write(false)]
        public List<Role> Roles { get; set; }
        
        public void CreateRole(Repository<Role> repository, string name, string slug)
        {
            var role = new Role(name, slug);
            Roles.Add(role);
            repository.Create(role);
        }
    }
}
