namespace ExpenseTracker.API.Expense.Dto;

public record ExpenseCreateDto(
        string ExpenseName,
        decimal Amount,
        DateOnly Date
    );