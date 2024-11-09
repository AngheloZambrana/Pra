using Entities;

namespace EstructuraDatos.Repositories.Interfaces;

public abstract class AbstractRepository<T> : IRepository<T> where T : ID
{
    protected List<T> _items;

    public Task<List<T>> GetAll()
    {
        return Task.FromResult(_items);
    }

    public Task<T?> GetById(Guid id)
    {
        var lists = _items.FirstOrDefault(j => j.Id == id);
        return Task.FromResult(lists);
    }

    public Task<T> Create(T entity)
    {
        _items.Add(entity);
        return Task.FromResult(entity);
    }

    public Task<bool> Delete(Guid id)
    {
        var list = _items.FirstOrDefault(j => j.Id == id);
        if (list != null)
        {
            _items.Remove(list);
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }
    
    public abstract Task<bool> Update(T entity);
}