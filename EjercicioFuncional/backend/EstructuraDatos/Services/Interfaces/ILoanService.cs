using Entities;

namespace Services.Interfaces;

public interface ILoanService
{
    public Task<IEnumerable<Loan>> GetLoansAsync();
    public Task<Loan?> GetLoanByIdAsync(Guid id);
    public Task<IEnumerable<Loan>> GetLoansByUserIdAsync(Guid userId);
    public Task<Loan> CreateLoanAsync(Loan loan);
    public Task<Loan> UpdateLoanAsync(Loan loan);
    public Task<bool> DeleteLoanAsync(Loan loan);
}