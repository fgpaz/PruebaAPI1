using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess
{
    public partial class TodoDB : DbContext
    {
        public TodoDB() { }

        public TodoDB(DbContextOptions<TodoDB> options)
            : base(options)
        { 
        }

        public DbSet<TodoItem> todoItems { get; set; }
    }
}
