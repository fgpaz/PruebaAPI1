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
        public async Task<TodoItem?> GetTodoItem(long id)
        {
            var todoItem = _todoContext.TodoItems.FindAsync(id);
            return (todoItem != null) ? await todoItem : null;
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
        public void EntityS(TodoItem todoItem) => _todoContext.Entry(todoItem).State = EntityState.Modified;
        public async Task<IAsyncResult> SaveChangesAsync() => await SaveChangesAsync();
        public async Task<IAsyncResult> DeleteTodoItem(long id) 
        {
            _todoContext.TodoItems.Remove(await GetTodoItem(id));
            return await SaveChangesAsync();
        }
    }
}