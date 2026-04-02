using MediatR;
using Microsoft.EntityFrameworkCore;
using TareasAPI.Command.Tareas;
using TareasAPI.Data;
using TareasAPI.Entities;

namespace TareasAPI.Handlers.Command
{
    public class CompletarTareaHandler :IRequestHandler<CompletarTareaCommand, string>
    {
        private readonly TareasDbContext _context;

        public CompletarTareaHandler(TareasDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(CompletarTareaCommand command, CancellationToken cancellationToken)
        {
            if (int.IsNegative(command.Id))
            {
                return "Error: no se puede ingresar un número negativo";
            }

            var tarea = await _context.Tareas
                .FirstOrDefaultAsync(t => t.Id == command.Id && t.Activa, cancellationToken);

            if ((tarea is null))
                return $"Error: no se encontró la tarea con Id {command.Id}";

            tarea.Completada = true;

            await _context.SaveChangesAsync(cancellationToken);

            return $"Tarea con Id {command.Id} completada correctamente";
        }
    }    
    
}
