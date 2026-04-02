using MediatR;
using Microsoft.EntityFrameworkCore;
using TareasAPI.Data;
using TareasAPI.DTOs;
using TareasAPI.Queries.Tareas;

namespace TareasAPI.Handlers.Queries
{
    public class ObtenerTareaPorIdHandler : IRequestHandler<ObtenerTareaPorIdQuery, TareaDto?>
    {
        private readonly TareasDbContext _context;

        public ObtenerTareaPorIdHandler(TareasDbContext context)
        {
            _context = context;
        }

        public async Task<TareaDto?> Handle(ObtenerTareaPorIdQuery query, CancellationToken cancellationToken)
        {
            var tarea = await _context.Tareas
                .FirstOrDefaultAsync(t => t.Id == query.Id && t.Activa, cancellationToken);

            if(tarea is null)
                return null;

            return new TareaDto(
                tarea.Id,
                tarea.Titulo,
                tarea.Descripcion,
                tarea.Prioridad,
                tarea.FechaCreacion,
                tarea.FechaLimite,
                tarea.Completada
            );
        }
    }
}
