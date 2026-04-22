using ExpenseTracker.API.Data;
using ExpenseTracker.API.Expenses.Repository;
using ExpenseTracker.API.Expenses.Service;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ExpenseContext>(options => 
    options.UseSqlite(connectionString));

// Allows Controller Usage
builder.Services.AddControllers();

builder.Services.AddScoped<IExpenseService, ExpenseService>();
builder.Services.AddScoped<IExpenseRepository, ExpenseRepository>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();