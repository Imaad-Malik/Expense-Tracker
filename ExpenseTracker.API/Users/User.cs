using ExpenseTracker.API.Expenses;

namespace ExpenseTracker.API.Users;

public class User
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }

    public List<Expense> Expenses { get; set; }= new();
}