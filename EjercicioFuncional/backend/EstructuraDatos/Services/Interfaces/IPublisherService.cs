using Entities;

namespace Services.Interfaces;

public interface IPublisherService
{
    public Task<IEnumerable<Publisher>> GetAllAsync();
    public Task<Publisher?> GetByIdAsync(Guid id);
    public Task<Publisher> AddAsync(Publisher publisher);
    public Task<bool> DeleteAsync(Guid id);
}