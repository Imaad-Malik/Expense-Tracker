using ExpenseTracker.API.Data;
using ExpenseTracker.API.Expenses;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.API.Users.Repository;

public class UserRepository : IUserRepository
{
    private readonly ExpenseContext _context;

    public UserRepository (ExpenseContext context)
    {
        _context = context;
    }
    
    // GET ALL USERS
    public async Task<List<User>> GetAllUsersAsync()
    {
        return await _context.Users.ToListAsync();
    }
    
    // GET USER BY ID
    public async Task<User?> GetUserByIdAsync(int id)
    {
        return await _context.Users.FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<Expense> CreateExpenseAsync(Expense expense)
    {
        _context.Expenses.Add(expense);
        await _context.SaveChangesAsync();
        return expense;
    }

    // CREATE USER 
    public async Task<User> CreateUserAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }
    
    // UPDATE USER
    public async Task<User> UpdateUserAsync(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
        return user;
    }
    
    // DELETE USER
    public async Task<bool> DeleteUserByIdAsync(int id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(e => e.Id == id);
        if (user == null) return false;
        
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<List<Expense>> GetExpensesByUserId(int userId)
    {
        return await _context.Expenses
            .Where(e => e.UserId == userId)
            .ToListAsync();
    }
}