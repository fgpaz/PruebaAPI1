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
        public async Task<TodoItem> Create(TodoItem todoItem) => await _todoDataAccess.Create(todoItem);

    }
}