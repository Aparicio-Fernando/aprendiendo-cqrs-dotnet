using MediatR;

namespace TareasAPI.Command.Tareas
{
    public record CompletarTareaCommand(int Id) : IRequest<string>;   
    
}
