using ExpenseTracker.API.Expenses;
using ExpenseTracker.API.Expenses.Dto;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.API.Data;

public class ExpenseContext : DbContext
{
    public DbSet<Expense> Expenses { get; set; }

    public ExpenseContext(DbContextOptions<ExpenseContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Expense>()
            .HasKey(e => e.Id);

        modelBuilder.Entity<Expense>()
            .Property(e => e.ExpenseName)
            .IsRequired()
            .HasMaxLength(200);

        modelBuilder.Entity<Expense>()
            .Property(e => e.Amount)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Expense>()
            .Property(e => e.Date)
            .IsRequired();
    }
}