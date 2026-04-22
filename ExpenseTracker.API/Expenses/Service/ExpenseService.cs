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

    public async Task<ExpenseResponseDto> Create(ExpenseCreateDto dto)
    {
        var expense = new Expense(dto.ExpenseName, dto.Amount, dto.Date);
        var created = await _repository.CreateAsync(expense);
        return MapToDto(created);
    }

    public async Task<ExpenseResponseDto?> Update(ExpenseUpdateDto dto, int id)
    {
        var expense = await _repository.GetByIdAsync(id);
        if (expense is null)
            return null;

        var updatedExpense = new Expense(dto.ExpenseName, dto.Amount, dto.Date);
        var result = await _repository.UpdateAsync(updatedExpense);
        if (result is null)
            return null;
        
        return MapToDto(result);
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