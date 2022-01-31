using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess
{
    public class TodoDataAccess
    {
        private readonly TodoContext _todoContext;
        public TodoDataAccess(TodoContext todoContext)
        {
            _todoContext = todoContext;
        }
        public async Task<List<TodoItem>> Get()
        {
            return await _todoContext.TodoItems.ToListAsync();
        }
        public async Task<TodoItem> GetTodoItem(long id)
        {
            var todoItem = _todoContext.TodoItems.FindAsync(id);
            if (todoItem != null)
            {
                return await todoItem;
            }
            else {
                return null;
            }
            
        }
        public async Task<TodoItem> Create(TodoItem todoItem)
        {
            _todoContext.TodoItems.Add(todoItem);
            await _todoContext.SaveChangesAsync();
            return todoItem;
        }
        public async Task<TodoItem> Update(long id, TodoItem todoItem)
        {

            _todoContext.TodoItems.Update(todoItem);
            await _todoContext.SaveChangesAsync();
            return todoItem;
        }


    }
}