using Blog.Interfaces;
using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly SqlConnection _connection;

        public UserRepository(SqlConnection connection)
            => _connection = connection;

        public void Create(User register)
        {
            register.Id = 0;
            _connection.Insert<User>(register);
        }

        public void Delete(User register)
        {
            if (register.Id != 0)
            {
                _connection.Delete<User>(register);
            }
        }

        public void Delete(int id)
        {
            if (id != 0)
                return;

            var user = _connection.Get<User>(id);
            _connection.Delete<User>(user);
        }

        public User Get(int id)
        {
            return _connection.Get<User>(id);
        }

        public IEnumerable<User> GetAll()
        {
            return _connection.GetAll<User>();
        }

        public void Update(User register)
        {
            if (register.Id != 0)
            {
                _connection.Update<User>(register);
            }
        }
    }
}
