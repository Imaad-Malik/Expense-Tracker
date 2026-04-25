namespace ExpenseTracker.API.Users.Dto;

public record UserResponseDto(
        int Id,
        string Email,
        string PasswordHash
    );