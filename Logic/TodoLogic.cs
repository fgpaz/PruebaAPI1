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
        public async Task<TodoItem?> GetTodoItem(long id) => await _todoDataAccess.GetTodoItem(id);
        public async Task<TodoItem?> Create(TodoItem todoItem) 
        {
            return await (validarExiste(todoItem)) ? null : await _todoDataAccess.Create(todoItem);
        }
        public async Task<TodoItem> Update(long id, TodoItem todoItem) => await _todoDataAccess.Update(id, todoItem);
        public void EntityS(TodoItem todoItem) => _todoDataAccess.EntityS(todoItem);
        public async Task SaveChanges() => await _todoDataAccess.SaveChangesAsync();
        public async Task<bool> validarExiste(TodoItem todoItem) 
        {
            var listadoTodoItem = _todoDataAccess.Get();
            var existe = false;
            foreach (var item in await listadoTodoItem)
            {
                if (item.Name == todoItem.Name) existe = true;
            }
            return existe;
        }
        public async Task<bool> validarExiste(long id) 
        {
            var listadoTodoItem = _todoDataAccess.Get();
            var existe = false;
            foreach (var item in await listadoTodoItem)
            {
                if (item.Id == id) existe = true;
            }
            return existe;
        }
        public async Task<IAsyncResult> DeleteTodoItem(long id) => _todoDataAccess.DeleteTodoItem(id);
    }
}