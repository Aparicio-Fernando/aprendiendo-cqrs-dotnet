using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaAPI.Data;
using TiendaAPI.DTOs;
using TiendaAPI.Entities;
using TiendaAPI.Interfaces;
using TiendaAPI.Queries.Productos;

namespace TiendaAPI.Handlers.Queries
{
    public class ObtenerProductosHandler : IRequestHandler<ObtenerProductosQuery, List<ProductoDto>>
    {
        private readonly TiendaDbContext _context;

        public ObtenerProductosHandler(TiendaDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductoDto>> Handle(ObtenerProductosQuery query, CancellationToken cancellationToken)
        {
            return await _context.Productos
            .Where(p => p.Activo)
            .Select(p => new ProductoDto(p.Id, p.Nombre, p.Precio))
            .ToListAsync(cancellationToken);

        }
       
    }
}
