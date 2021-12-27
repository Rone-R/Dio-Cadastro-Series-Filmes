namespace Dio_Series.Interfaces
{
    public interface IRepository<T>
    {
        List<T> GetList { get; }
        void Insert(T entity);
        void Delete(int id);
        void Update(int id, T objeto);
        T GetId(int id);
        int NextId { get; }
    }
}