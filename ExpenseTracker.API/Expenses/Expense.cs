using ExpenseTracker.API.Users;

namespace ExpenseTracker.API.Expenses;

public class Expense
{
    public int Id { get; set; }
    public string ExpenseName { get; set; }
    public decimal Amount { get; set; }
    public DateOnly Date { get; set; }
    public User User { get; set; }
    public int UserId { get; set; }

    public Expense(string expenseName, decimal amount, DateOnly date, int UserId)
    {
        this.ExpenseName = expenseName;
        this.Amount = amount;
        this.Date = date;
        this.UserId = UserId;
    }
    
    private Expense() {}
}