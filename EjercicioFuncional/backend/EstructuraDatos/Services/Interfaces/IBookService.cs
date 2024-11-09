using Entities;

namespace Services.Interfaces;

public interface IBookService
{
    public Task<List<Book>> GetAllBooks();
    public Task<Book?> GetBookById(Guid id);
    public Task<Book> CreateBook(Book book);
    public Task<bool> DeleteBook(Guid id);
    public Task<bool> UpdateBook(Book book);
}