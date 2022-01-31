#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

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

        //// GET: api/TodoItems
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
        //{
        //    return await _todoLogic.TodoItems.ToListAsync();
        //}

        //// GET: api/TodoItems/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<TodoItem>> GetTodoItem(long id)
        //{
        //    var todoItem = await _todoLogic.TodoItems.FindAsync(id);

        //    if (todoItem == null)
        //    {
        //        return NotFound();
        //    }

        //    return todoItem;
        //}

        //// PUT: api/TodoItems/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutTodoItem(long id, TodoItem todoItem)
        //{
        //    if (id != todoItem.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _todoLogic.Entry(todoItem).State = EntityState.Modified;

        //    try
        //    {
        //        await _todoLogic.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TodoItemExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/TodoItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem todoItem)
        {
            //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            //return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, todoItem);
            return await _todoLogic.Create(todoItem);
        }

        //    // DELETE: api/TodoItems/5
        //    [HttpDelete("{id}")]
        //    public async Task<IActionResult> DeleteTodoItem(long id)
        //    {
        //        {
        //            return NotFound();
        //        }

        //        _todoLogic.TodoItems.Remove(todoItem);
        //        await _todoLogic.SaveChangesAsync();

        //        return NoContent();
        //    }

        //    private bool TodoItemExists(long id)
        //    {
        //        return _todoLogic.TodoItems.Any(e => e.Id == id);
        //    }
        //}
    }
}
