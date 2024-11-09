namespace DTOs.WithoutIDs;

public class PostBook
{
    public string? Title { get; set; }
    public Guid AuthorId { get; set; }
    public string? Gender { get; set; }
    public DateTime CreatedAt { get; set; }
}
