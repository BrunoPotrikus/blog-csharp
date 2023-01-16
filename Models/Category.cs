using Blog.Interfaces;
using Blog.Repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Models
{
    [Table("[Category]")]

    public class Category : Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public List<Post> Posts { get; set; }
        private IRepository<Category> _repository;

        public Category(SqlConnection connection)
        {
           
        }
    }
}
