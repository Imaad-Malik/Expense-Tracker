using ExpenseTracker.API.Expenses.Dto;
using ExpenseTracker.API.Expenses.Repository;

namespace ExpenseTracker.API.Expenses.Service;

public class ExpenseService : IExpenseService
{
    private readonly IExpenseRepository _repository;

    public ExpenseService(IExpenseRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<List<ExpenseResponseDto>> GetAllAsync()
    {
        var expenses = await _repository.GetAllAsync();
        return expenses.Select(MapToDto).ToList();
    }
    
    public async Task<List<ExpenseResponseDto>> GetAllByUserId(int userId)
    {
        var expenses = await _repository.GetExpesnesByUserId(userId);
        return expenses.Select(MapToDto).ToList();
    }

    public async Task<ExpenseResponseDto?> GetByIdAsync(int id, int userId)
    {
        var expense = await _repository.GetByIdAsync(id);
        if (expense == null || expense.UserId != userId) return null;
        return MapToDto(expense);
    }

    public async Task<ExpenseResponseDto> Create(ExpenseCreateDto expense, int userId)
    {
        var createdExpense = new Expense(
            expense.ExpenseName,
            expense.Amount,
            expense.Date,
            userId);
        var created = await _repository.CreateAsync(createdExpense);
        return MapToDto(created);
    }

    public async Task<ExpenseResponseDto?> Update(ExpenseUpdateDto updatedExpense, int id, int userId)
    {
        var expense = await _repository.GetByIdAsync(id);
        if (expense is null || expense.UserId != userId) return null;

        expense.ExpenseName = updatedExpense.ExpenseName;
        expense.Amount = updatedExpense.Amount;
        expense.Date = updatedExpense.Date;

        await _repository.UpdateAsync(expense);
        
        return MapToDto(expense);
    }

    public async Task<bool> Delete(int id, int userId)
    {
        var expense = await _repository.GetByIdAsync(id);
        if (expense is null || expense.UserId != userId) return false;
        
        return await _repository.DeleteAsync(id);
    }
    
    private ExpenseResponseDto MapToDto(Expense expense)
    {
        return new ExpenseResponseDto(
            expense.UserId,
            expense.Id,
            expense.ExpenseName,
            expense.Amount,
            expense.Date
        );
    }
}