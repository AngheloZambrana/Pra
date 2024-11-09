using Entities;
using EstructuraDatos.Repositories;
using Services.Interfaces;

namespace EstructuraDatos.Services;

public class AuthorService : IAuthorService
{
    private AuthorRepository _repository;

    public AuthorService()
    {
        _repository = new AuthorRepository();
    }
    public Task<List<Author>> GetAuthors()
    {
        return _repository.GetAll();
    }

    public Task<Author?> GetAuthorById(Guid id)
    {
        return _repository.GetById(id);
    }

    public Task<Author> CreateAuthor(Author author)
    {
        return _repository.Create(author);
    }

    public Task<bool> DeleteAuthor(Guid id)
    {
        return _repository.Delete(id);
    }

    public Task<bool> UpdateAuthor(Author author)
    {
        return _repository.Update(author);
    }
}