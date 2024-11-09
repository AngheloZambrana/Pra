using Entities;
using EstructuraDatos.Repositories;
using Services.Interfaces;

namespace EstructuraDatos.Services;

public class BookService : IBookService
{
    private BookRepository _bookRepository;
    private AuthorRepository _authorRepository;
    
    public BookService()
    {
        _bookRepository = new BookRepository(_authorRepository = new AuthorRepository());

    }
    public Task<List<Book>> GetAllBooks()
    {
        return _bookRepository.GetAll();
    }

    public Task<Book?> GetBookById(Guid id)
    {
        return _bookRepository.GetById(id);
    }

    public Task<Book> CreateBook(Book book)
    {
        return _bookRepository.Create(book);
    }

    public Task<bool> DeleteBook(Guid id)
    {
        return _bookRepository.Delete(id);
    }

    public Task<bool> UpdateBook(Book book)
    {
        return _bookRepository.Update(book);
    }
}