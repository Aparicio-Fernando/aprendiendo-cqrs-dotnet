using MediatR;

namespace TareasAPI.Command.Tareas
{
    public record EliminarTareaCommand(int Id) : IRequest<string>;
        
}
