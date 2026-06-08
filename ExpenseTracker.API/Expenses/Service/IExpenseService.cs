using ExpenseTracker.API.Expenses.Dto;

namespace ExpenseTracker.API.Expenses.Service;

public interface IExpenseService
{
    Task<List<ExpenseResponseDto>> GetAllAsync();
    Task<List<ExpenseResponseDto>> GetAllByUserId(int userId);
    Task<ExpenseResponseDto?> GetByIdAsync(int id, int userId);
    Task<ExpenseResponseDto> Create(ExpenseCreateDto expense, int userId);
    Task<ExpenseResponseDto?> Update(ExpenseUpdateDto updatedExpense, int id, int userId);
    Task<bool> Delete(int id, int userId);
}