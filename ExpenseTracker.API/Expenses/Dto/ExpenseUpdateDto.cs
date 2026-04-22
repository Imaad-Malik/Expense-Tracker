namespace ExpenseTracker.API.Expenses.Dto;

public record ExpenseUpdateDto(
        string ExpenseName,
        decimal Amount,
        DateOnly Date
    );