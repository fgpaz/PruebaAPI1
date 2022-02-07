using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess
{
    public class MySQLDataAccess
    {
        private readonly TodoContext _todoContext;
        public MySQLDataAccess(TodoContext todoContext)
        {
            _todoContext = todoContext;
        }

        // Para GET
        public async Task<List<TodoItem>> Get()
        {
            return await _todoContext.TodoItems.ToListAsync();
        }

        // Para GET/{id}
        public async Task<TodoItem?> GetTodoItem(long id)
        {
            var todoItem = _todoContext.TodoItems.FindAsync(id);
            return await todoItem;
        }

        // Para POST
        public async Task<TodoItem> Create(TodoItem todoItem)
        {
            _todoContext.TodoItems.Add(todoItem);
            await _todoContext.SaveChangesAsync();
            return todoItem;
        }

        // Para PUT
        public async Task<TodoItem> Update(long id, TodoItem todoItem)
        {
            //_todoContext.Entry(todoItem).State = EntityState.Modified;
            _todoContext.TodoItems.Update(todoItem);
            await _todoContext.SaveChangesAsync();
            return todoItem;
        }

        // Para DELETE
        public async Task<TodoItem?> DeleteTodoItem(long id)
        {
            var todoItem = await GetTodoItem(id);
            if (todoItem != null) _todoContext.TodoItems.Remove(todoItem);
            await _todoContext.SaveChangesAsync();
            return todoItem;
        }
    }
}
