using ExpenseTracker.API.Expense.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.API.Expense;

public class ExpenseService : IExpenseService
{
    private static List<Expense> _expenses = new()
    {
        new Expense("Expense 1", 1, 10.50m, new DateOnly(2026, 4, 18)),
        new Expense("Expense 2", 2, 25.00m, new DateOnly(2026, 4, 19))
    };
    
    public List<Expense> GetAll()
    {
        return _expenses;
    }

    public Expense? GetById(int id)
    {
        return _expenses.FirstOrDefault(expense => expense.Id == id);
    }

    public Expense Create(ExpenseCreateDto dto)
    {
        int nextId = _expenses.Max(e => e.Id) + 1;

        var expense = new Expense(dto.ExpenseName, nextId, dto.Amount, dto.Date);
        _expenses.Add(expense);

        return expense;
    }

    public Expense? Update(ExpenseUpdateDto dto, int id)
    {
        for (var i = 0; i < _expenses.Count; i++)
        {
            var expense = _expenses[i];

            if (expense.Id != id) continue;
            var updatedExpense = new Expense(
                dto.ExpenseName,
                expense.Id,
                dto.Amount,
                dto.Date
            );
            _expenses[i] = updatedExpense;
            return updatedExpense;
        }

        return null;
    }

    public bool Delete(int id)
    {
        var expense = _expenses.FirstOrDefault(e => e.Id == id);

        if (expense is null)
            return false;

        _expenses.Remove(expense);
        return true;
    }
}