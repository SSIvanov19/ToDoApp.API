using Microsoft.AspNetCore.Mvc;
using ToDoApp.Services.Contracts;
using ToDoApp.Shared.IMs;
using ToDoApp.Shared.VMs;

namespace ToDoApp.WebHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemController : ControllerBase
    {
        private readonly IToDoService toDoService;

        public ToDoItemController(IToDoService toDoService)
        {
            this.toDoService = toDoService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ToDoItemVM>>> GetAllCrossedToDoItems()
        {
            var toDoItems = await this.toDoService.GetAllToDoItems();

            return this.Ok(toDoItems);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> CreateToDoItemAsync([FromBody] ToDoItemIM toDoItem)
        {
            await this.toDoService.CreateToDoItemAsync(toDoItem);

            return this.Created(string.Empty, toDoItem);
        }

        [HttpPost]
        [Route("checkout/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> CheckOutToDoItem(string id)
        {
            await this.toDoService.CheckOutToDoItem(id);

            return this.Ok();
        }
    }
}
