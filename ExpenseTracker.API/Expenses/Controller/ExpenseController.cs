using ExpenseTracker.API.Expenses.Dto;
using ExpenseTracker.API.Expenses.Service;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.API.Expenses.Controller;

[ApiController]
// This makes the route ".../expense"
[Route("[controller]")]
public class ExpenseController : Microsoft.AspNetCore.Mvc.Controller
{
    private IExpenseService _expenseService;

    public ExpenseController(IExpenseService expenseService)
    {
        _expenseService = expenseService;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<ExpenseResponseDto>>> GetAll()
    {
        var expense = await _expenseService.GetAllAsync();
        return Ok(expense);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ExpenseResponseDto>> GetById(int id)
    {
        var expense = await _expenseService.GetByIdAsync(id);
        return Ok(expense);
    }

    [HttpPost]
    public async Task<ActionResult<ExpenseResponseDto>> Create(ExpenseCreateDto dto)
    {
        var expense = await _expenseService.Create(dto);
        return Ok(expense);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ExpenseResponseDto>> Update(ExpenseUpdateDto dto, int id)
    {
        var expense = await _expenseService.Update(dto, id);
        return Ok(expense);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ExpenseResponseDto>> Delete(int id)
    {
        var expense = await _expenseService.Delete(id);
        return Ok(expense);
    }
}