using Microsoft.EntityFrameworkCore;
using ToDoApp.Data.Data;
using ToDoApp.Services;
using ToDoApp.WebHost.Models;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")!, o =>
    {
        o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
        o.MigrationsAssembly(typeof(Program).Assembly.FullName);
    });
    options.EnableDetailedErrors();
    options.EnableSensitiveDataLogging();
    options.EnableThreadSafetyChecks();
});


// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddServices();

builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
