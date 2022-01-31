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
        public async Task<TodoItem> Create(TodoItem todoItem) 
        {            
            _todoContext.TodoItems.Add(todoItem);
            await _todoContext.SaveChangesAsync();
            return todoItem;
        }
     
    }
}