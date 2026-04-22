namespace ExpenseTracker.API.Expenses.Dto;

public record ExpenseResponseDto(
        int Id,
        string ExpenseName,             
        decimal Amount,                  
        DateOnly Date 
    );