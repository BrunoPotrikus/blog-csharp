using Blog.Interfaces;
using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class RoleRepository : IRepository<Role>
    {
        private readonly SqlConnection _connection;

        public RoleRepository(SqlConnection connection)
            => _connection = connection;

        public void Create(Role register)
        {
            register.Id = 0;
            _connection.Insert<Role>(register);
        }

        public void Delete(Role register)
        {
            if(register.Id != 0)
            {
                _connection.Delete<Role>(register);
            }
        }

        public void Delete(int id)
        {
            if (id != 0)
                return;

            var role = _connection.Get<Role>(id);
            _connection.Delete<Role>(role);
        }

        public Role Get(int id)
        {
            return _connection.Get<Role>(id);
        }

        public IEnumerable<Role> GetAll()
        {
            return _connection.GetAll<Role>();
        }

        public void Update(Role register)
        {
            if(register.Id != 0 )
            {
                _connection.Update<Role>(register);
            }
        }
    }
}
