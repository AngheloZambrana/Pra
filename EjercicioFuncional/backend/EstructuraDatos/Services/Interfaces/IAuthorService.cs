using Entities;

namespace Services.Interfaces;

public interface IAuthorService
{
    public Task<List<Author>> GetAuthors();
    public Task<Author?> GetAuthorById(Guid id);
    public Task<Author> CreateAuthor(Author author);
    public Task<bool> DeleteAuthor(Guid id);
    public Task<bool> UpdateAuthor(Author author);
}
