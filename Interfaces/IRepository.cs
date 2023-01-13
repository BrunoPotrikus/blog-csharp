namespace Blog.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Create(T register);
        void Update(T register);
        void Delete(T register);
        void Delete(int id);
    }
}
