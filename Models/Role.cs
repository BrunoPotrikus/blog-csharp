using Blog.Interfaces;
using Blog.Repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Models
{
    [Table("[Role]")]

    public class Role : Entity
    {
        public Role(string name, string slug)
        {
            Name = name;
            Slug = slug;
        }

        public string Name { get; set; }
        public string Slug { get; set; }

    }
}
