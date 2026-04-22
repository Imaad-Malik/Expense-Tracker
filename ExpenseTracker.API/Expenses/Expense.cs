namespace ExpenseTracker.API.Expenses;

public class Expense
{
    public int Id { get; set; }
    public string ExpenseName { get; set; }
    public decimal Amount { get; set; }
    public DateOnly Date { get; set; }

    public Expense(string expenseName, decimal amount, DateOnly date)
    {
        this.ExpenseName = expenseName;
        this.Amount = amount;
        this.Date = date;
    }
    
    private Expense() {}
}