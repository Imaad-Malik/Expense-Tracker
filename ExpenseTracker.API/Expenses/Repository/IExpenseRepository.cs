using ExpenseTracker.API.Expenses.Dto;

namespace ExpenseTracker.API.Expenses.Repository;

public interface IExpenseRepository
{
    Task<List<Expense>> GetAllAsync();
    Task<Expense?> GetByIdAsync(int id);
    Task<Expense> CreateAsync(Expense expense);
    Task<Expense?> UpdateAsync(Expense expense);
    Task<bool> DeleteAsync(int id);
}