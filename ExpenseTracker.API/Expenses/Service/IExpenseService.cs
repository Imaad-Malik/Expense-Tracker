using ExpenseTracker.API.Expenses.Dto;

namespace ExpenseTracker.API.Expenses.Service;

public interface IExpenseService
{
    Task<List<ExpenseResponseDto>> GetAllAsync();
    // ? means method can return null
    // It's possible no expense is found by that id, so ? is used for that possibility
    Task<ExpenseResponseDto?> GetByIdAsync(int id);
    Task<ExpenseResponseDto> Create(ExpenseCreateDto createdExpense);
    Task<ExpenseResponseDto?> Update(ExpenseUpdateDto updatedExpense, int id);
    Task<bool> Delete(int id);
}