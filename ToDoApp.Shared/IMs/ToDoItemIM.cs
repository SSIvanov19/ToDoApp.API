using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Shared.IMs;

public class ToDoItemIM
{
    [Required]
    public string Name { get; set; } = string.Empty;
}
