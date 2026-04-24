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

    public async Task<ExpenseResponseDto?> GetByIdAsync(int id)
    {
        var expense = await _repository.GetByIdAsync(id);
        return expense is null ? null : MapToDto(expense);
    }

    public async Task<ExpenseResponseDto> Create(ExpenseCreateDto expense)
    {
        var createdExpense = new Expense(
            expense.ExpenseName,
            expense.Amount,
            expense.Date,
            expense.UserId);
        var created = await _repository.CreateAsync(createdExpense);
        return MapToDto(created);
    }

    public async Task<ExpenseResponseDto?> Update(ExpenseUpdateDto updatedExpense, int id)
    {
        var expense = await _repository.GetByIdAsync(id);
        if (expense is null)
            return null;

        expense.ExpenseName = updatedExpense.ExpenseName;
        expense.Amount = updatedExpense.Amount;
        expense.Date = updatedExpense.Date;

        await _repository.UpdateAsync(expense);
        
        return MapToDto(expense);
    }

    public async Task<bool> Delete(int id)
    {
        return await _repository.DeleteAsync(id);
    }

    private ExpenseResponseDto MapToDto(Expense expense)
    {
        return new ExpenseResponseDto(
            expense.Id,
            expense.ExpenseName,
            expense.Amount,
            expense.Date
        );
    }
}