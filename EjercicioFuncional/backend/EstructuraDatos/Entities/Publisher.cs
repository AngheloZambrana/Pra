namespace Entities;

public class Publisher : ID
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Country { get; set; }
    public DateTime Created { get; set; }
}