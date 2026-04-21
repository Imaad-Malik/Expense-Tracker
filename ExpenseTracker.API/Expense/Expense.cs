namespace ExpenseTracker.API.Expense;

public class Expense
{
    public string ExpenseName { get; private set; }
    public int Id { get; private set; }
    public decimal Amount { get; private set; }
    public DateOnly Date { get; private set; }

    public Expense(string expenseName, int id, decimal amount, DateOnly date)
    {
        this.ExpenseName = expenseName;
        this.Id = id;
        this.Amount = amount;
        this.Date = date;
    }
}