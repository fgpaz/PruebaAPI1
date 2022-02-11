namespace DataAccess
{
    public class TodoDataAccess
    {
        //    private readonly TodoContext _todoDb;
        //    public TodoDataAccess(TodoContext todoContext)
        //    {
        //        _todoDb = todoContext;
        //    }

        //    // Para GET
        //    public async Task<List<TodoItem>> Get()
        //    {
        //        return await _todoDb.TodoItems.ToListAsync();
        //    }

        //    // Para GET/{id}
        //    public async Task<TodoItem?> GetTodoItem(long id)
        //    {
        //        var todoItem = _todoDb.TodoItems.FindAsync(id);
        //        return await todoItem;
        //    }

        //    // Para POST
        //    public async Task<TodoItem> Create(TodoItem todoItem)
        //    {
        //        _todoDb.TodoItems.Add(todoItem);
        //        await _todoDb.SaveChangesAsync();
        //        return todoItem;
        //    }

        //    // Para PUT
        //    public async Task<TodoItem> Update(long id, TodoItem todoItem)
        //    {
        //        //_todoDb.Entry(todoItem).State = EntityState.Modified;
        //        _todoDb.TodoItems.Update(todoItem);
        //        await _todoDb.SaveChangesAsync();
        //        return todoItem;
        //    }

        //    // Para DELETE
        //    public async Task<TodoItem?> DeleteTodoItem(long id)
        //    {
        //        var todoItem = await GetTodoItem(id);
        //        if (todoItem != null) _todoDb.TodoItems.Remove(todoItem);
        //        await _todoDb.SaveChangesAsync();
        //        return todoItem;
        //    }
    }
}