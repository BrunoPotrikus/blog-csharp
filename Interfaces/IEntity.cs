using Blog.Models;
using Microsoft.Data.SqlClient;

namespace Blog.Interfaces
{
    public interface IEntity<T>
    {
        public int Id { get; set; }

        void CreateRegister(T register);
        void ReadRegister(int id);
        void ReadRegisters();
        void UpdateRegister(T register);
        void DeleteRegister(T register);
        void DeleteRegister(int id);
    }
}
