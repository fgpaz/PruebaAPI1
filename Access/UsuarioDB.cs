using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess
{
    public partial class UsuarioDB : DbContext
    {
        public UsuarioDB() { }

        public UsuarioDB(DbContextOptions<UsuarioDB> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder.UseMySql(DBProperties.getInstance().connectionString);
            //}
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
            .Entity<Usuario>()
            .Property(cn => cn.Rol)
            .HasConversion(
                m => m.ToString(),
                m => (Rol)Enum.Parse(typeof(Rol), m));
        }
    }
}