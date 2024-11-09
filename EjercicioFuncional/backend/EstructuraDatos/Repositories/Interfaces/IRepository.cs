namespace EstructuraDatos.Repositories.Interfaces;

public interface IRepository<T>
{
    public Task<List<T>> GetAll();
    public Task<T?> GetById(Guid id);
    public Task<T> Create(T entity);
    public Task<bool> Delete(Guid id);
    public Task<bool> Update(T entity);
}
