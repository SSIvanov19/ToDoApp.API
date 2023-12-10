namespace ToDoApp.Shared.VMs;

public class ToDoItemVM
{
    public string Id { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public bool IsChecked { get; set; } = false;
}
