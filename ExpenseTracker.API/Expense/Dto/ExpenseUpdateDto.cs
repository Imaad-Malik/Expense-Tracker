namespace ExpenseTracker.API.Expense.Dto;

public record ExpenseUpdateDto(
        string ExpenseName,
        decimal Amount,
        DateOnly Date
    );