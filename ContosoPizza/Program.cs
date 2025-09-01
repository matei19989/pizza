using ContosoPizza.Data;
using ContosoPizza.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Configure SQLite database (use /tmp for Azure App Service)
string dbPath = builder.Environment.IsDevelopment() 
    ? "Data Source=ContosoPizza.db" 
    : "Data Source=/tmp/ContosoPizza.db";

builder.Services.AddDbContext<PizzaContext>(options =>
    options.UseSqlite(dbPath));

builder.Services.AddScoped<PizzaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();

// CRITICAL: Create database and tables on startup
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<PizzaContext>();
    try 
    {
        context.Database.EnsureCreated();
        Console.WriteLine("Database and tables created successfully!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Database error: {ex.Message}");
    }
}

app.Run();