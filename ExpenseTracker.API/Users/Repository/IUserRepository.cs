using ExpenseTracker.API.Expenses;

namespace ExpenseTracker.API.Users.Repository;

public interface IUserRepository
{
    public Task<List<User>> GetAllUsersAsync();
    public Task<User?> GetUserByIdAsync(int id);
    public Task<User> CreateUserAsync(User user);
    public Task<User> UpdateUserAsync(User user);
    public Task<bool> DeleteUserByIdAsync(int id);
    public Task<Expense?> GetExpenseByIdAsync(int id);
    public Task<List<Expense>> GetExpensesByUserId(int userId);
    public Task<Expense> CreateExpenseAsync(Expense expense);
    public Task<Expense> UpdateExpenseAsync(Expense expense);
}