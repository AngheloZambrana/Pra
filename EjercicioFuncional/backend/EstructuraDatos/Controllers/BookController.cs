using AutoMapper;
using DTOs;
using DTOs.WithoutIDs;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace EstructuraDatos.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;
    private readonly IMapper _mapper;

    public BookController(IBookService bookService, IMapper mapper)
    {
        _bookService = bookService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<BookDTO>>> GetBooks()
    {
        var books = await _bookService.GetAllBooks();
        var bookDTOs = _mapper.Map<List<BookDTO>>(books);
        return Ok(bookDTOs);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BookDTO>> GetBook(Guid id)
    {
        var book = await _bookService.GetBookById(id);
        if (book == null)
            return NotFound();
        var bookDto = _mapper.Map<BookDTO>(book);
        return Ok(bookDto);
    }

    [HttpPost]
    public async Task<ActionResult<BookDTO>> PostBook(PostBook postBook)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var book = _mapper.Map<Book>((postBook, Guid.NewGuid()));
        var createdBook = await _bookService.CreateBook(book);
        var bookDto = _mapper.Map<BookDTO>(createdBook);
        
        return CreatedAtAction(nameof(GetBook), new { id = createdBook.Id }, bookDto);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(Guid id)
    {
        var book = await _bookService.DeleteBook(id);
        if (!book)
            return NotFound();
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBook(Guid id, PostBook postBook)
    {
        var bookToUpdate = _mapper.Map<Book>((postBook, id));
        var updateSuccess = await _bookService.UpdateBook(bookToUpdate);
        if (!updateSuccess)
            return NotFound();
        return NoContent();
    }
}