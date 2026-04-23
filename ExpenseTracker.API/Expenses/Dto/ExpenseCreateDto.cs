using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.API.Expenses.Dto;

public class ExpenseCreateDto
{
        [Required, MaxLength(50)]
        public string ExpenseName { get; set; }
        [Required, Range(0.01, double.MaxValue)]
        public decimal Amount { get; set; }
        public DateOnly Date { get; set; }
}