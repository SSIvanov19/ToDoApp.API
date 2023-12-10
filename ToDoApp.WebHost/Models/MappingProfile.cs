using AutoMapper;
using ToDoApp.Data.Models;
using ToDoApp.Shared.IMs;
using ToDoApp.Shared.VMs;

namespace ToDoApp.WebHost.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        this.CreateMap<ToDoItemIM, ToDoItem>();
        this.CreateMap<ToDoItem, ToDoItemVM>();
    }
}
