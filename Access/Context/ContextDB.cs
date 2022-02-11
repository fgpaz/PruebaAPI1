using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess
{
    public partial class ContextDB : DbContext
    {
        public ContextDB() { }

        public ContextDB(DbContextOptions<ContextDB> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<CertificacionHoras> CertificacionHoras { get; set; }
        public DbSet<CertificacionDevengamiento> CertificacionDevengamientos { get; set; }

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