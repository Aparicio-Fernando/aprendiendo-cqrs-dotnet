using Microsoft.EntityFrameworkCore;
using TareasAPI.Entities;

namespace TareasAPI.Data
{
    public class TareasDbContext : DbContext
    {
        public TareasDbContext(DbContextOptions <TareasDbContext> options) : base(options)
        {
        }

        // Cada DbSet es una tabla en la base de datos
        public DbSet<Tarea> Tareas { get; set; }
    }
}
