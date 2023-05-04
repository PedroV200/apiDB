public interface IGenericRepository<T> where T: class
{
    Task<IEnumerable<T>> getAll();
    Task<T> getById(int id);
    Task<int> add(T entity);
    Task<int> update(T entity);
    Task<int> delete(T entity);
}