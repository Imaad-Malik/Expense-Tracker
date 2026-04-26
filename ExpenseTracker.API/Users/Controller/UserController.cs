using ExpenseTracker.API.Data;
using ExpenseTracker.API.Expenses;
using ExpenseTracker.API.Expenses.Dto;
using ExpenseTracker.API.Users.Dto;
using ExpenseTracker.API.Users.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.API.Users.Controller;

[ApiController]
[Route("users")]
public class UserController : ControllerBase
{
    private readonly IUserService _service;

    public UserController(IUserService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<UserResponseDto>>> GetUsers()
    {
        var users = await _service.GetAllUsersAsync();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserResponseDto>> GetUserById(int id)
    {
        var user = await _service.GetUserByIdAsync(id);
        return Ok(user);
    }

    [HttpGet("{userId}/expenses")]
    public async Task<ActionResult<List<ExpenseResponseDto>>> GetExpensesByUserId(int userId)
    {
        var expenses = await _service.GetExpensesAsync(userId);
        return Ok(expenses);
    }

    [HttpPost("{userId}/expenses")]
    public async Task<ActionResult<ExpenseResponseDto>> CreateExpenseByUserId(ExpenseCreateDto dto, int userId)
    {
        var expense = await _service.CreateExpenseByUserIdAsync(dto, userId);
        return Ok(expense);
    }
    
    [HttpPost]
    public async Task<ActionResult<UserResponseDto>> CreateUser(UserCreateDto user)
    {
        var newUser = await _service.CreateUserAsync(user);
        return Ok(newUser);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UserResponseDto>> UpdateUser(UserUpdateDto user, int id)
    {
        var updatedUser = await _service.UpdateUserAsync(user, id);
        return Ok(updatedUser);
    }

    [HttpPut("{userId}/expenses/{id}")]
    public async Task<ActionResult<ExpenseResponseDto>> UpdateExpense(ExpenseUpdateDto expense, int userId, int id)
    {
        var updatedExpense = await _service.UpdateExpenseByUserIdAsync(expense, userId, id);
        return Ok(updatedExpense);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<UserResponseDto>> DeleteUser(int id)
    {
        var deletedUser = await _service.DeleteAsync(id);
        return Ok(deletedUser);
    }
}