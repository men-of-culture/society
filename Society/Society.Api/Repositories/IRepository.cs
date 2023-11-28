namespace Society.Api.Repositories
{
    public interface IRepository<T>
    {
        T GetById(Guid id);
        IEnumerable<T> GetAll();
        void Add(T model);
        void Update(T model);
        void Delete(Guid id);
    }
}
