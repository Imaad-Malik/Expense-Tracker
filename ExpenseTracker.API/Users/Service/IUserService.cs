using ExpenseTracker.API.Expenses;
using ExpenseTracker.API.Expenses.Dto;
using ExpenseTracker.API.Users.Dto;

namespace ExpenseTracker.API.Users.Service;

public interface IUserService
{
    public Task<List<UserResponseDto>> GetAllUsersAsync();
    public Task<UserResponseDto?> GetUserByIdAsync(int id);
    public Task<UserResponseDto> CreateUserAsync(UserCreateDto user);
    public Task<UserResponseDto?> UpdateUserAsync(UserUpdateDto updatedUser, int id);
    public Task<bool> DeleteAsync(int id);
    public Task<List<ExpenseResponseDto>> GetExpensesAsync(int userId);
    public Task<ExpenseResponseDto> CreateExpenseByUserIdAsync(ExpenseCreateDto dto, int userId);
    public Task<ExpenseResponseDto?> UpdateExpenseByUserIdAsync(ExpenseUpdateDto dto, int userId, int expenseId);
}