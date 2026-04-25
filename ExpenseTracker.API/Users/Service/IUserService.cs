using ExpenseTracker.API.Users.Dto;

namespace ExpenseTracker.API.Users.Service;

public interface IUserService
{
    public Task<List<UserResponseDto>> GetAllUsersAsync();
    public Task<UserResponseDto?> GetUserByIdAsync(int id);
    public Task<UserResponseDto> CreateUserAsync(UserCreateDto user);
    public Task<UserResponseDto?> UpdateUserAsync(UserUpdateDto updatedUser, int id);
    public Task<bool> DeleteAsync(int id);
}