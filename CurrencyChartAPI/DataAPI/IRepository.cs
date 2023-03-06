namespace DataAPI
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        Task<T> GetById(int id);
        Task<T> GetByName(string name);
    }
}
