using DataAccess;
using Models;

namespace Logic
{
    public class TodoLogic
    {
        private readonly TodoDataAccess _todoDataAccess;
        public TodoLogic(TodoDataAccess todoDataAccess)
        {
            _todoDataAccess = todoDataAccess;
        }
        public async Task<List<TodoItem>> Get() => await _todoDataAccess.Get();
        public async Task<TodoItem> GetTodoItem(long id) => await _todoDataAccess.GetTodoItem(id);
        public async Task<TodoItem> Create(TodoItem todoItem) => await _todoDataAccess.Create(todoItem);
        public async Task<TodoItem> Update(long id, TodoItem todoItem) => await _todoDataAccess.Update(id, todoItem);

    }
}