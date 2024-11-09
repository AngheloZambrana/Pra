namespace Entities;

public class Author : ID
{
    public Guid Id { get; set; }    
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Nationality { get; set; }
    
}