using Blog.Models;
using Microsoft.Data.SqlClient;

namespace Blog.Interfaces
{
    public interface IRepository<T>
    {
        public IEnumerable<T> GetAll();
        public T Get(int id);
        public void Create(T register);
        public void Update(T register);
        public void Delete(T register);
        public void Delete(int id);
    }
}
