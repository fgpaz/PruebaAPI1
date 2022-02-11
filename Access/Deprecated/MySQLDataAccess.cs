using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess
{
    public class MySQLDataAccess
    {
        private readonly TodoDB _todoDB;

        public MySQLDataAccess(TodoDB todoDB)
        {
            _todoDB = todoDB;
        }

        public void SaveChanges() => _todoDB.SaveChanges();

        // Para GET
        public async Task<List<TodoItem>> Get()
        {
            return await _todoDB.todoItems.ToListAsync();
        }

        // Para GET/{id}
        public async Task<TodoItem?> GetTodoItem(long id)
        {
            var todoItem = _todoDB.todoItems.FindAsync(id);
            return await todoItem;
        }

        // Para POST
        public async Task<TodoItem> Create(TodoItem todoItem)
        {
            _todoDB.todoItems.Add(todoItem);
            await _todoDB.SaveChangesAsync();
            return todoItem;
        }

        // Para PUT
        public async Task<TodoItem> Update(long id, TodoItem todoItem)
        {
            //_todoDb.Entry(todoItem).State = EntityState.Modified;
            _todoDB.todoItems.Update(todoItem);
            await _todoDB.SaveChangesAsync();
            return todoItem;
        }

        // Para DELETE
        public async Task<TodoItem?> DeleteTodoItem(long id)
        {
            var todoItem = await GetTodoItem(id);
            if (todoItem != null) _todoDB.todoItems.Remove(todoItem);
            await _todoDB.SaveChangesAsync();
            return todoItem;
        }
    }
}
