using ExpenseTracker.API.Users.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ExpenseTracker.API.Users;

namespace ExpenseTracker.API.Auth;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserRepository _repository;
    private readonly TokenService _tokenService;
    private readonly PasswordHasher<User> _passwordHasher;

    public AuthController(IUserRepository repository, TokenService tokenService)
    {
        _repository = repository;
        _tokenService = tokenService;
        _passwordHasher = new PasswordHasher<User>();
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        if (await _repository.GetUserByEmailAsync(request.Email) != null)
        {
            return BadRequest("User with this email already exists");
        }

        var user = new User(request.Email, "");
        user.PasswordHash = _passwordHasher.HashPassword(user, request.Password);

        await _repository.CreateUserAsync(user);

        return Ok("User registered successfully");
    }
    
    // LOGIN
    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
        {
            return BadRequest("Email and password are required");
        }

        var user = await _repository.GetUserByEmailAsync(request.Email);

        if (user == null)
        {
            return Unauthorized("Invalid credentials");
        }

        var result = _passwordHasher.VerifyHashedPassword(
            user,
            user.PasswordHash,
            request.Password
        );

        if (result == PasswordVerificationResult.Failed)
        {
            return Unauthorized("Invalid credentials 2");
        }

        var token = _tokenService.CreateToken(
            user.Id.ToString(),
            user.Email
        );

        return Ok(new { token });
    }
    
    [Authorize]
    [HttpGet("test")]
    public IActionResult Test()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        return Ok($"You are authenticated. UserId: {userId}");
    }
}