using QuiSNCF.Database;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<GameDbContext>(options =>
    options.UseNpgsql(connectionString));


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<GameDbContext>();
        
        context.Database.Migrate();
        
        Console.WriteLine("Database migrations OK.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Database migration NOT OK: {ex.Message}");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


app.Run();
