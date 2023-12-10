using ToDoApp.Shared.IMs;
using ToDoApp.Shared.VMs;

namespace ToDoApp.Services.Contracts;

public interface IToDoService
{
    Task CreateToDoItemAsync(ToDoItemIM toDoItem);

    Task<IEnumerable<ToDoItemVM>> GetAllToDoItems();

    Task CheckOutToDoItem(string id);
}
