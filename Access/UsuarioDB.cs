using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess
{
    public partial class UsuarioDB : DbContext
    {
        public UsuarioDB() { }

        public UsuarioDB(DbContextOptions<TodoDB> options)
            : base(options)
        { 
        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
