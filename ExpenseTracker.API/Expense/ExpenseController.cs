using ExpenseTracker.API.Expense.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.API.Expense;

[ApiController]
// This makes the route ".../expense"
[Route("[controller]")]
public class ExpenseController : Controller
{
    private IExpenseService _expenseService;

    public ExpenseController(IExpenseService expenseService)
    {
        _expenseService = expenseService;
    }
    
    [HttpGet]
    public ActionResult<List<Expense>> GetAll()
    {
        return Ok(_expenseService.GetAll());
    }

    [HttpGet]
    [Route("/expense/{id}")]
    public ActionResult<Expense> GetById(int id)
    {
        return Ok(_expenseService.GetById(id));
    }

    [HttpPost]
    // Later change <Expense> to ExpenseResponse
    public ActionResult<Expense> Create(ExpenseCreateDto dto)
    {
        return Ok(_expenseService.Create(dto));
    }

    [HttpPut("{id}")]
    public ActionResult<Expense> Update(ExpenseUpdateDto dto, int id)
    {
        var updatedExpense = _expenseService.Update(dto, id);

        if (updatedExpense is null)
            return NotFound();

        return Ok(updatedExpense);
    }

    [HttpDelete("{id}")]
    public ActionResult<Expense> Delete(int id)
    {
        var isDeleted = _expenseService.Delete(id);

        if (!isDeleted)
            return NotFound();

        return NoContent();
    }
}