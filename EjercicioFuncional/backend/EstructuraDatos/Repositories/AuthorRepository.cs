using Entities;
using EstructuraDatos.Repositories.Interfaces;

namespace EstructuraDatos.Repositories;

public class AuthorRepository : AbstractRepository<Author> 
{
    public AuthorRepository()
    {
        _items = new List<Author>()
        {
            new Author()
            {
                Id = new Guid("0a95be3f-2ea6-4fdf-a563-25f38975a5c6"),
                Name = "Juan",
                Surname = "Perez",
                Nationality = "Romania",
            },
            new Author()
            {
                Id = new Guid("a7b0e85d-546a-4ed9-aec7-1ca690ea0b10"),
                Name = "Roberto",
                Surname = "Pozo",
                Nationality = "Argelia"
            }
        };
    }
    public override Task<bool> Update(Author entity)
    {
        var result = _items.FirstOrDefault(x => x.Id == entity.Id);
        if (result == null)
        {
            return Task.FromResult(false);
        }
        result.Name = entity.Name;
        result.Surname = entity.Surname;
        result.Nationality = entity.Nationality;
        return Task.FromResult(true);
    }
}