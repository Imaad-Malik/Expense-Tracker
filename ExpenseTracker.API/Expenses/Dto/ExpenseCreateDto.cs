namespace ExpenseTracker.API.Expenses.Dto;

public record ExpenseCreateDto(
        string ExpenseName,
        decimal Amount,
        DateOnly Date
    );