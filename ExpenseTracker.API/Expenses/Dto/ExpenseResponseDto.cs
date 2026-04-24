namespace ExpenseTracker.API.Expenses.Dto;

public record ExpenseResponseDto(
        int userId,
        int Id,
        string ExpenseName,             
        decimal Amount,                  
        DateOnly Date 
    );