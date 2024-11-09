namespace Entities;

public class Book : ID
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public Guid AuthorId { get; set; }
    public string? Gender { get; set; }
    public DateTime CreatedAt { get; set; }
}
