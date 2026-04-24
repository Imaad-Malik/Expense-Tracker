using ExpenseTracker.API.Data;
using ExpenseTracker.API.Users.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.API.Users.Controller;

[ApiController]
[Route("users")]
public class UserController : ControllerBase
{
    public readonly ExpenseContext _context;

    public UserController(ExpenseContext context)
    {
        _context = context;
    }

    [HttpGet]
    // TEST VERSION add dto later 
    public async Task<IActionResult> GetUsers()
    {
        var users = await _context.Users
            .Select(u => new UserResponseDto
            {
                Id = u.Id,
                Email = u.Email
            })
            .ToListAsync();

        return Ok(users);
    }
    
    // TESTING
    [HttpPost]
    public async Task<IActionResult> CreateUser(UserCreateDto user)
    {
        var newUser = new User
        {
            Email = user.Email,
            PasswordHash = user.PasswordHash
        };

        _context.Users.Add(newUser);
        await _context.SaveChangesAsync();

        return Ok(user);
    }
}