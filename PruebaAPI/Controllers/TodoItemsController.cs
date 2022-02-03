#nullable disable
using Logic;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Exceptions;

namespace PruebaAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly TodoLogic _todoLogic;

        public TodoItemsController(TodoLogic todoLogic)
        {
            _todoLogic = todoLogic;
        }

        // GET: api/TodoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems() => await _todoLogic.Get();

        // GET: api/TodoItems/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(long id)
        {
            try
            {
                return await _todoLogic.GetTodoItem(id);
            }
            catch (CustomException e)
            {
                return new ObjectResult(new { e.Details }) { StatusCode = e.StatusCode };
            }
        }

        // POST: api/TodoItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem todoItem)
        {
            try
            {
                return await _todoLogic.Create(todoItem);
            }
            catch (CustomException e)
            {
                return new ObjectResult(new { e.Details }) { StatusCode = e.StatusCode };
            }
        }

        // PUT: api/TodoItems/{id}
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<TodoItem>> PutTodoItem([FromRoute] long id, [FromBody] TodoItem todoItem)
        {
            try
            {
                return await _todoLogic.Update(id, todoItem);
                 //todoItem;
            }
            catch (CustomException e)
            {
                return new ObjectResult(new { e.Details }) { StatusCode = e.StatusCode };
            }
        }

        // DELETE: api/TodoItems/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<TodoItem>> DeleteTodoItem([FromRoute] long id)
        {
            try
            {
                await _todoLogic.DeleteTodoItem(id);
                return NoContent();
            }
            catch (CustomException e)
            {
                return new ObjectResult(new { e.Details }) { StatusCode = e.StatusCode };
            }
        }
    }
}
