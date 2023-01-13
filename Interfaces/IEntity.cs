using Microsoft.Data.SqlClient;

namespace Blog.Interfaces
{
    public interface IEntity<T>
    {
        public int Id { get; set; }

        void CreateRegister(T register);
        void ReadRegister(SqlConnection connection, int id);
        void ReadRegisters(SqlConnection connection);
        void UpdateRegister(T register);
        void DeleteRegister(T register);
        void DeleteRegister(int id);
    }
}
