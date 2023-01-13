using Blog.Interfaces;
using Blog.Repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Models
{
    [Table("[Category]")]

    public class Category : IEntity<Category>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        private IRepository<Category> _repository;

        public Category()
        {
            _repository = new Repository<Category>(connection);
        }

        public static void ReadRegister(SqlConnection connection, int id)
        {
            throw new NotImplementedException();
        }

        public static void ReadRegisters(SqlConnection connection)
        {
            throw new NotImplementedException();
        }

        public void CreateRegister(Category register)
        {
            throw new NotImplementedException();
        }

        public void DeleteRegister(Category register)
        {
            throw new NotImplementedException();
        }

        public void DeleteRegister(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateRegister(Category register)
        {
            throw new NotImplementedException();
        }
    }
}
