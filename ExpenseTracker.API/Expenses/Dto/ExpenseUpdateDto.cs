using System.ComponentModel.DataAnnotations;

public class ExpenseUpdateDto
{
    [MaxLength(50)]
    public string ExpenseName { get; set; }
    [Range(0.01, double.MaxValue)]
    public decimal Amount { get; set; }

    public DateOnly Date { get; set; }
}