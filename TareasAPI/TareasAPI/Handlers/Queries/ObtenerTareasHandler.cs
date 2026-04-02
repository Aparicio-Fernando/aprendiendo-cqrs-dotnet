using MediatR;
using Microsoft.EntityFrameworkCore;
using TareasAPI.Data;
using TareasAPI.DTOs;
using TareasAPI.Queries.Tareas;

namespace TareasAPI.Handlers.Queries
{
    public class ObtenerTareasHandler : IRequestHandler<ObtenerTareasQuery, List<TareaDto>>
    {
        private readonly TareasDbContext _context;

        public ObtenerTareasHandler(TareasDbContext context)
        {
            _context = context;
        }

        public async Task<List<TareaDto>> Handle(ObtenerTareasQuery query, CancellationToken cancellationToken)
        {
            return await _context.Tareas
                .Where(t => t.Activa)
                .Select(t => new TareaDto(t.Id, t.Titulo, t.Descripcion, t.Prioridad, t.FechaCreacion, t.FechaLimite, t.Completada))
                .ToListAsync(cancellationToken);
        }
    }
}
