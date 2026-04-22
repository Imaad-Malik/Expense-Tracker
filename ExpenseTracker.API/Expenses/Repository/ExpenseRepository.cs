using ExpenseTracker.API.Data;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.API.Expenses.Repository;

public class ExpenseRepository : IExpenseRepository
{
    private readonly ExpenseContext _context;

    public ExpenseRepository(ExpenseContext context)
    {
        _context = context;
    }
    
    public async Task<List<Expense>> GetAllAsync()
    {
        return await _context.Expenses.ToListAsync();
    }

    public async Task<Expense?> GetByIdAsync(int id)
    {
        return await _context.Expenses.FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<Expense> CreateAsync(Expense expense)
    {
        _context.Expenses.Add(expense);
        await _context.SaveChangesAsync();
        return expense;
    }

    public async Task<Expense?> UpdateAsync(Expense expense)
    {
        _context.Expenses.Update(expense);
        await _context.SaveChangesAsync();
        return expense;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var expense = await _context.Expenses.FirstOrDefaultAsync(e => e.Id == id);
        if (expense == null) return false;

        _context.Expenses.Remove(expense);
        await _context.SaveChangesAsync();
        return true;
    }
}