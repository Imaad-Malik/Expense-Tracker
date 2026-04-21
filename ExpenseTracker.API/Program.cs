using ExpenseTracker.API.Expense;

var builder = WebApplication.CreateBuilder(args);
// Allows Controller Usage
builder.Services.AddControllers();
// When something asks for IExpenseService, create and provide ExpenseService
builder.Services.AddSingleton<IExpenseService, ExpenseService>();

var app = builder.Build();
// Automatically redirects all HTTPS requests to their HTTP equivalents
app.UseHttpsRedirection();
app.UseAuthorization();
// When using class-based controller, need to call this to make the endpoints reachable
app.MapControllers();

app.Run();