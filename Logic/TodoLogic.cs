using DataAccess;
using Models;
using Models.Exceptions;

namespace Logic
{
    public class TodoLogic
    {
        private readonly TodoDataAccess _todoDataAccess;
        public TodoLogic(TodoDataAccess todoDataAccess)
        {
            _todoDataAccess = todoDataAccess;
        }

        // Para GET
        public async Task<List<TodoItem>> Get() => await _todoDataAccess.Get();

        // Para GET/{id}
        public async Task<TodoItem?> GetTodoItem(long id) => await _todoDataAccess.GetTodoItem(id);

        // Para POST
        public async Task<TodoItem?> Create(TodoItem todoItem)
        {
            if (await siExisteElItem(todoItem))
            {
                throw new ExisteTodoConElMismoNombreException
                {
                    Details = "Ya existe este item",
                    StatusCode = 400
                };
            }
            else return await _todoDataAccess.Create(todoItem);
        }

        // Para PUT
        public async Task<TodoItem> Update(long id, TodoItem todoItem)
        {
            if (_todoDataAccess.GetTodoItem(id) == null)
            {
                throw new NoExisteElElementoException
                {
                    Details = "No existe el elemento a eliminar",
                    StatusCode = 404
                };
            }
            else
            {
                return await _todoDataAccess.Update(id, todoItem);
            }
        }

        // Para DELETE
        public async Task<TodoItem?> DeleteTodoItem(long id)
        {
            var todoItem = _todoDataAccess.GetTodoItem(id);
            if (todoItem == null)
            {
                throw new NoExisteElElementoException
                {
                    Details = "No existe el elemento a eliminar",
                    StatusCode = 404
                };
            }
            else
            {
                await _todoDataAccess.DeleteTodoItem(id);
            }
            return await todoItem;
        }

        // VALIDACIONES
        private async Task<bool> siExisteElItem(TodoItem? todoItem)
        {
            var listadoTodoItem = _todoDataAccess.Get();
            var siExiste = false;
            foreach (var item in await listadoTodoItem)
            {
                if (todoItem != null && item.Name == todoItem.Name) siExiste = true;
            }
            return siExiste;
        }
    }
}
