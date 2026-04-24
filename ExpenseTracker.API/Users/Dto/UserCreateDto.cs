namespace ExpenseTracker.API.Users.Dto;

public class UserCreateDto
{
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    
}