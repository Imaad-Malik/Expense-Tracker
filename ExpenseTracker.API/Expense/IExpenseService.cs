using ExpenseTracker.API.Expense.Dto;

namespace ExpenseTracker.API.Expense;

public interface IExpenseService
{
    List<Expense> GetAll();
    // ? means method can return null
    // It's possible no expense is found by that id, so ? is used for that possibility
    Expense? GetById(int id);
    Expense Create(ExpenseCreateDto dto);
    Expense? Update(ExpenseUpdateDto dto, int id);
    bool Delete(int id);
}