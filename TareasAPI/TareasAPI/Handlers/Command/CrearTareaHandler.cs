using MediatR;
using TareasAPI.Command.Tareas;
using TareasAPI.Data;
using TareasAPI.Entities;

namespace TareasAPI.Handlers.Command
{
    public class CrearTareaHandler : IRequestHandler<CrearTareaCommand, string>
    {
        private readonly TareasDbContext _context;

        public CrearTareaHandler(TareasDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(CrearTareaCommand command, CancellationToken cancellationToken)
        {            
            var tarea = new Tarea
            {
                Titulo = command.Titulo,
                Descripcion = command.Descripcion,
                Prioridad = command.Prioridad,
                FechaLimite = command.FechaLimite
            };

            _context.Tareas.Add(tarea);
            await _context.SaveChangesAsync(cancellationToken);

            return $"Tarea '{command.Titulo}' creada correctamente con Id {tarea.Id}";
        }
    }
}
