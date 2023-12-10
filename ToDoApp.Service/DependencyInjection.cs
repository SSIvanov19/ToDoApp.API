using Microsoft.Extensions.DependencyInjection;
using ToDoApp.Services.Contracts;
using ToDoApp.Services.Implementations;

namespace ToDoApp.Services;

public static class DependencyInjection
{
    public static void AddServices(this IServiceCollection services)
    {
        services
            .AddScoped<IToDoService, ToDoService>();
    }
}
