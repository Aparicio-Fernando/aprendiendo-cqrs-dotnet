using TiendaAPI.DTOs;
using TiendaAPI.Interfaces;
using TiendaAPI.Queries.Productos;

namespace TiendaAPI.Handlers.Queries
{
    public class ObtenerProductoPorIdHandler : IQueryHandler<ObtenerProductoPorIdQuery, ProductoDto?>
    {
        public async Task<ProductoDto?> Handle(ObtenerProductoPorIdQuery query)
        {
            await Task.Delay(1);

            // Mapeamos Producto a ProductoDto
            var producto = ObtenerProductosHandler._productos
                .FirstOrDefault(p => p.Id == query.Id && p.Activo);

            if (producto is null)
                return null;

            return new ProductoDto(producto.Id, producto.Nombre, producto.Precio);
        }
    }       
}



