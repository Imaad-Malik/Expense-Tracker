using ExpenseTracker.API.Expenses.Dto;
using ExpenseTracker.API.Expenses.Service;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace ExpenseTracker.API.Expenses.Controller;

[ApiController]
[Route("[controller]")]
[Authorize]
public class ExpenseController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly IExpenseService _expenseService;

    public ExpenseController(IExpenseService expenseService)
    {
        _expenseService = expenseService;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<ExpenseResponseDto>>> GetAll()
    {
        var userId = GetUserId();
        var expense = await _expenseService.GetAllByUserId(userId);
        return Ok(expense);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ExpenseResponseDto>> GetById(int id)
    {
        var userId = GetUserId();
        
        var expense = await _expenseService.GetByIdAsync(id, userId);
        if (expense == null) return NotFound();
        
        return Ok(expense);
    }
    
    [HttpPost]
    public async Task<ActionResult<ExpenseResponseDto>> Create(ExpenseCreateDto dto)
    {
        var userId = GetUserId();
        var expense = await _expenseService.Create(dto, userId);
        return Ok(expense);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ExpenseResponseDto>> Update(ExpenseUpdateDto dto, int id)
    {
        var userId = GetUserId();
        var expense = await _expenseService.Update(dto, id, userId);
        if (expense is null) return NotFound();
        
        return Ok(expense);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ExpenseResponseDto>> Delete(int id)
    {
        var userId = GetUserId();
        var expense = await _expenseService.Delete(id, userId);
        if (!expense) return NotFound();
        
        return NoContent();
    }

    private int GetUserId()
    {
        var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userIdString == null)
            throw new UnauthorizedAccessException();

        return int.Parse(userIdString);
    }
}