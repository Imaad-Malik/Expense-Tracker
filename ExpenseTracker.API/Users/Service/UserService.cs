using ExpenseTracker.API.Expenses;
using ExpenseTracker.API.Expenses.Dto;
using ExpenseTracker.API.Users.Dto;
using ExpenseTracker.API.Users.Repository;

namespace ExpenseTracker.API.Users.Service;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<List<UserResponseDto>> GetAllUsersAsync()
    {
        var users = await _repository.GetAllUsersAsync();
        return users.Select(MapToDto).ToList();
    }
    
    public async Task<UserResponseDto?> GetUserByIdAsync(int id)
    {
        var user = await _repository.GetUserByIdAsync(id);
        if (user == null) return null;
        
        return MapToDto(user);
    }

    public async Task<ExpenseResponseDto> CreateExpenseByUserIdAsync(ExpenseCreateDto dto, int userId)
    {
        var user = await _repository.GetUserByIdAsync(userId);
        
        var newExpense = new Expense(
            dto.ExpenseName,
            dto.Amount,
            dto.Date,
            dto.UserId
        );
        
        var expense = await _repository.CreateExpenseAsync(newExpense);

        return new ExpenseResponseDto(
                expense.UserId,
                expense.Id,
                expense.ExpenseName,
                expense.Amount,
                expense.Date
        );
    }

    public async Task<ExpenseResponseDto?> UpdateExpenseByUserIdAsync(ExpenseUpdateDto dto, int userId, int expenseId)
    {
        var user = await _repository.GetUserByIdAsync(userId);
        if (user == null) return null;
        
        var expense = await _repository.GetExpenseByIdAsync(expenseId);
        if (expense == null) return null;
        
        // Check if user has ownership of this expense
        if (user.Id != expense.UserId)
        {
            return null;
        }

        expense.ExpenseName = dto.ExpenseName;
        expense.Amount = dto.Amount;
        expense.Date = dto.Date;

        await _repository.UpdateExpenseAsync(expense);

        return new ExpenseResponseDto(
            expense.UserId,
            expense.Id,
            expense.ExpenseName,
            expense.Amount,
            expense.Date
        );
    }

    public async Task<bool> DeleteExpenseByUserIdAsync(int expenseId, int userId)
    {
        var user = await _repository.GetUserByIdAsync(userId);
        if (user == null) return false;
        var expense = await _repository.GetExpenseByIdAsync(expenseId);
        if (expense == null) return false;

        if (user.Id != expense.UserId)
        {
            return false;
        }

        return await _repository.DeleteExpenseByIdAsync(expenseId);
    }
    
    public async Task<UserResponseDto> CreateUserAsync(UserCreateDto user)
    {
        var newUser = new User(
            user.Email,
            user.PasswordHash
        );

        var createdUser = await _repository.CreateUserAsync(newUser);
        return MapToDto(createdUser);
    }
    
    public async Task<UserResponseDto?> UpdateUserAsync(UserUpdateDto updatedUser, int id)
    {
        var userToUpdate = await _repository.GetUserByIdAsync(id);
        if (userToUpdate == null) return null;

        userToUpdate.Email = updatedUser.Email;
        userToUpdate.PasswordHash = updatedUser.PasswordHash;

        await _repository.UpdateUserAsync(userToUpdate);
        return MapToDto(userToUpdate);
    }
    
    public async Task<bool> DeleteAsync(int id)
    {
        return await _repository.DeleteUserByIdAsync(id);
    }

    public async Task<List<ExpenseResponseDto>> GetExpensesAsync(int userId)
    {
        var expenses = await _repository.GetExpensesByUserId(userId);

        return expenses.Select(e => new ExpenseResponseDto(
            e.UserId,
            e.Id,
            e.ExpenseName,
            e.Amount,
            e.Date
        )).ToList();
    }
    
    
    public UserResponseDto MapToDto(User user)
    {
        return new UserResponseDto(
                user.Id,
                user.Email,
                user.PasswordHash
            );
    }
}