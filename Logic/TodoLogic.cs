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
            if (await validarExiste(todoItem))
            {
                throw new ExisteTodoConElMismoNombreException
                {
                    Details = "Ya existe este item",
                    StatusCode = 400
                };
            }
            else return await _todoDataAccess.Create(todoItem);
        }
        public async Task<TodoItem> Update(long id, TodoItem todoItem) => await _todoDataAccess.Update(id, todoItem);
        public void EntityS(TodoItem todoItem) => _todoDataAccess.EntityS(todoItem);
        private async Task<bool> validarExiste(TodoItem todoItem)
        {
            var listadoTodoItem = _todoDataAccess.Get();
            var existe = false;
            foreach (var item in await listadoTodoItem)
            {
                if (item.Name == todoItem.Name) existe = true;
            }
            return existe;
        }
        public async Task<Object> DeleteTodoItem(long id)
        {
            if (_todoDataAccess.GetTodoItem(id) == null)
            {
                throw new NoExisteElElementoException
                {
                    Details = "No existe el elemento a eliminar",
                    StatusCode = 400
                };
            } else return await _todoDataAccess.DeleteTodoItem(id);
        }
    }
}