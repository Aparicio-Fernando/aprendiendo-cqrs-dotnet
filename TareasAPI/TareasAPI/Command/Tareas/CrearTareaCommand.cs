using MediatR;
using TareasAPI.Entities;

namespace TareasAPI.Command.Tareas
{
    public record CrearTareaCommand(string Titulo, string Descripcion, Prioridad Prioridad, DateTime FechaLimite) : IRequest<string>;
        
}
