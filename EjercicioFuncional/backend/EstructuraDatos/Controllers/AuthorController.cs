using AutoMapper;
using DTOs;
using DTOs.WithoutIDs;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace EstructuraDatos.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService _authorService;
    private readonly IMapper _mapper;

    public AuthorController(IAuthorService authorService, IMapper mapper)
    {
        _authorService = authorService;
        _mapper = mapper;
    }
    
    // GET: api/Author
    [HttpGet]
    public async Task<ActionResult<List<AuthorDTO>>> GetAuthors()
    {
        var authors = await _authorService.GetAuthors();
        var authorDTOs = _mapper.Map<List<AuthorDTO>>(authors);
        return Ok(authorDTOs);
    }
    // GET: api/Author/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<AuthorDTO>> GetAuthorById(Guid id)
    {
        var author = await _authorService.GetAuthorById(id);
        if (author == null)
        {
            return NotFound();
        }
        var authorDto = _mapper.Map<AuthorDTO>(author);
        return Ok(authorDto);
    }

    // POST: api/Author
    [HttpPost]
    public async Task<ActionResult<AuthorDTO>> CreateAuthor(PostAuthor postAuthor)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var authorEntity = _mapper.Map<Author>((postAuthor, Guid.NewGuid()));
        var createdAuthor = await _authorService.CreateAuthor(authorEntity);
        var authorDTO = _mapper.Map<AuthorDTO>(createdAuthor);

        return CreatedAtAction(nameof(GetAuthorById), new { id = authorDTO.Id }, authorDTO);
    }

    // DELETE: api/Author/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAuthor(Guid id)
    {
        var result = await _authorService.DeleteAuthor(id);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAuthor(Guid id, PostAuthor postAuthor)
    {
        var authorToUpdate = _mapper.Map<Author>((postAuthor, id));
        var updateSuccessful = await _authorService.UpdateAuthor(authorToUpdate);
        if (!updateSuccessful)
        {
            return NotFound("El autor no fue encontrado.");
        }
        return NoContent();
    }
}