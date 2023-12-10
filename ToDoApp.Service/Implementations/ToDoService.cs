using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Data.Data;
using ToDoApp.Data.Models;
using ToDoApp.Services.Contracts;
using ToDoApp.Shared.IMs;
using ToDoApp.Shared.VMs;

namespace ToDoApp.Services.Implementations;

internal class ToDoService : IToDoService
{
    private readonly ApplicationDbContext context;
    private readonly IMapper mapper;

    public ToDoService(ApplicationDbContext context, IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }

    public async Task CheckOutToDoItem(string id)
    {
        var toDoItem = await this.context.ToDoItems.FirstOrDefaultAsync(x => x.Id == id);

        if (toDoItem is null)
        {
            throw new ArgumentNullException(nameof(toDoItem));
        }

        toDoItem.IsChecked = true;

        await this.context.SaveChangesAsync();
    }

    public Task CreateToDoItemAsync(ToDoItemIM toDoItem)
    {
        var toDoItemEntity = this.mapper.Map<ToDoItem>(toDoItem);

        this.context.ToDoItems.Add(toDoItemEntity);

        return this.context.SaveChangesAsync();
    }

    public async Task<IEnumerable<ToDoItemVM>> GetAllCrossedToDoItems()
    {
        return await this.context.ToDoItems
            .Where(x => x.IsChecked)
            .ProjectTo<ToDoItemVM>(this.mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task<IEnumerable<ToDoItemVM>> GetAllNonCrossedToDoItems()
    {
        return await this.context.ToDoItems
            .Where(x => !x.IsChecked)
            .ProjectTo<ToDoItemVM>(this.mapper.ConfigurationProvider)
            .ToListAsync();
    }
}
