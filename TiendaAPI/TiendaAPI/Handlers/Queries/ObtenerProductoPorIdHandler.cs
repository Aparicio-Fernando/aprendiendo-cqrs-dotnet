using MediatR;
using TiendaAPI.DTOs;
using TiendaAPI.Interfaces;
using TiendaAPI.Queries.Productos;

namespace TiendaAPI.Handlers.Queries
{
    public class ObtenerProductoPorIdHandler : IRequestHandler<ObtenerProductoPorIdQuery, ProductoDto?>
    {
        public async Task<ProductoDto?> Handle(ObtenerProductoPorIdQuery query, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            // Mapeamos Producto a ProductoDto
            var producto = ObtenerProductosHandler._productos
                .FirstOrDefault(p => p.Id == query.Id && p.Activo);

            if (producto is null)
                return null;

            return new ProductoDto(producto.Id, producto.Nombre, producto.Precio);
        }
    }       
}



