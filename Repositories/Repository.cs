using Blog.Interfaces;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly SqlConnection _connection;

        public Repository(SqlConnection connection)
            => _connection = connection;

        public void Create(T register)
        {
            _connection.Insert<T>(register);
        }

        public void Delete(T register)
        {
            _connection.Delete<T>(register);
        }

        public void Delete(int id)
        {
            if (id != 0)
                return;

            var register = _connection.Get<T>(id);
            _connection.Delete<T>(register);
        }

        public T Get(int id)
        {
            return _connection.Get<T>(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _connection.GetAll<T>();
        }

        public void Update(T register)
        {
            _connection.Update<T>(register);
        }
    }
}
