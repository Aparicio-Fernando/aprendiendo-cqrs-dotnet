using Microsoft.EntityFrameworkCore;
using TiendaAPI.Entities;

namespace TiendaAPI.Data
{
    public class TiendaDbContext : DbContext
    {
        public TiendaDbContext(DbContextOptions<TiendaDbContext> options) : base(options)
        {
        }

        // Cada DbSet es una tabla en la base de datos
        public DbSet<Producto> Productos { get; set; }
    }
}
