using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.API.Users.Dto;

public class UserUpdateDto
{
    [Required]
    public string Email { get; set; }
    [Required]
    public string PasswordHash { get; set; }
}