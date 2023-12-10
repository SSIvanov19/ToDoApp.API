namespace ToDoApp.Data.Models;

public class ToDoItem
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public string Name { get; set; } = string.Empty;

    public bool IsChecked { get; set; } = false;

    public ToDoItem(string name)
    {
        this.Name = name;
    }
}
