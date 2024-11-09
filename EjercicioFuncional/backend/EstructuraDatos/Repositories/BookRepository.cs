using Entities;
using EstructuraDatos.Repositories.Interfaces;

namespace EstructuraDatos.Repositories;

public class BookRepository : AbstractRepository<Book>
{
    private readonly AuthorRepository _authorRepository;
    private readonly Random _random = new Random();
    public BookRepository(AuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
        var authors = _authorRepository.GetAll().Result;
        if (!authors.Any())
        {
            throw new Exception("No authors available to assign to books.");
        }

        _items = new List<Book>()
        {
            new Book()
            {
                Id = Guid.NewGuid(),
                Title = "Estructura de Datos",
                CreatedAt = DateTime.Today,
                Gender = "Informatica",
                AuthorId = authors[_random.Next(authors.Count)].Id
            },
            new Book()
            {
                Id = Guid.NewGuid(),
                Title = "Pedagogia",
                CreatedAt = DateTime.Today,
                Gender = "Medicina",
                AuthorId = authors[_random.Next(authors.Count)].Id
            }
        };
    }
    public override Task<bool> Update(Book entity)
    {
        var result = _items.FirstOrDefault(x => x.Id == entity.Id);
        if (result == null)
            return Task.FromResult(false);
        result.Title = entity.Title;
        result.Gender = entity.Gender;
        result.CreatedAt = entity.CreatedAt;
        result.AuthorId = entity.AuthorId;
        return Task.FromResult(true);
    }
}