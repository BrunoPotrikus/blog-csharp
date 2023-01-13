using Blog.Interfaces;
using Blog.Repositories;
using Microsoft.Data.SqlClient;

namespace Blog.Models
{
    public abstract class Entity<T> : IEntity<T>
    {
        private IRepository<Entity<T>> _repository;

        public Entity(SqlConnection connection)
        {
            _repository = new Repository<Entity<T>>(connection);
        }

        public int Id { get; set; }

        public void ReadRegister(SqlConnection connection, int id)
        {
            _repository.Get(id);
        }

        public void ReadRegisters(SqlConnection connection)
        {
            throw new NotImplementedException();
        }

        public virtual void CreateRegister(T register)
        {
            throw new NotImplementedException();
        }

        public virtual void DeleteRegister(T register)
        {
            throw new NotImplementedException();
        }

        public virtual void DeleteRegister(int id)
        {
            throw new NotImplementedException();
        }

        public virtual void UpdateRegister(T register)
        {
            throw new NotImplementedException();
        }
    }
}
