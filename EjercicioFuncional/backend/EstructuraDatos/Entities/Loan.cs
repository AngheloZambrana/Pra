namespace Entities;

public class Loan : ID
{
    public Guid Id { get; set; }
    public Guid BookId { get; set; }
    public Guid UserId { get; set; }
    public DateTime LoanStart { get; set; }
    public DateTime LoanEnd { get; set; }
}