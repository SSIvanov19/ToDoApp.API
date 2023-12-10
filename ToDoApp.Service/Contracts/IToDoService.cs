using ToDoApp.Shared.IMs;
using ToDoApp.Shared.VMs;

namespace ToDoApp.Services.Contracts;

public interface IToDoService
{
    Task CreateToDoItemAsync(ToDoItemIM toDoItem);

    Task<IEnumerable<ToDoItemVM>> GetAllCrossedToDoItems();

    Task<IEnumerable<ToDoItemVM>> GetAllNonCrossedToDoItems();

    Task CheckOutToDoItem(string id);
}
