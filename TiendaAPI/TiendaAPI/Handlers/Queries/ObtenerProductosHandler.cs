using TiendaAPI.DTOs;
using TiendaAPI.Entities;
using TiendaAPI.Interfaces;
using TiendaAPI.Queries.Productos;

namespace TiendaAPI.Handlers.Queries
{
    public class ObtenerProductosHandler : IQueryHandler<ObtenerProductosQuery, List<ProductoDto>>
    {
        // Lista compartida — en Sesión 8 será la base de datos real
        public static List<Producto> _productos = new List<Producto>
        {
            new Producto { Id = 1, Nombre = "Laptop", Precio = 1500 },
            new Producto { Id = 2, Nombre = "Mouse", Precio = 25 },
            new Producto { Id = 3, Nombre = "Teclado", Precio = 45 }
        };

        public async Task<List<ProductoDto>> Handle(ObtenerProductosQuery query)
        {
            await Task.Delay(1);

            // Mapeamos cada Producto a ProductoDto
            var dtos = _productos
                .Where(p => p.Activo)
                .Select(p => new ProductoDto(p.Id, p.Nombre, p.Precio))
                .ToList();
            
            return dtos;
                
        }
       
    }
}
