using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaAPI.Data;
using TiendaAPI.DTOs;
using TiendaAPI.Interfaces;
using TiendaAPI.Queries.Productos;

namespace TiendaAPI.Handlers.Queries
{
    public class ObtenerProductoPorIdHandler : IRequestHandler<ObtenerProductoPorIdQuery, ProductoDto?>
    {
        private readonly TiendaDbContext _context;

        public ObtenerProductoPorIdHandler(TiendaDbContext context)
        {
            _context = context;
        }

        public async Task<ProductoDto?> Handle(ObtenerProductoPorIdQuery query, CancellationToken cancellationToken)
        {
            var producto = await _context.Productos
             .FirstOrDefaultAsync(p => p.Id == query.Id && p.Activo, cancellationToken);

            if (producto is null)
                return null;

            return new ProductoDto(producto.Id, producto.Nombre, producto.Precio);
        }
    }       
}



