namespace DTOs.WithoutIDs;

public class PostLoan
{
    public Guid BookId { get; set; }
    public Guid UserId { get; set; }
    public DateTime LoanStart { get; set; }
    public DateTime LoanEnd { get; set; }
}