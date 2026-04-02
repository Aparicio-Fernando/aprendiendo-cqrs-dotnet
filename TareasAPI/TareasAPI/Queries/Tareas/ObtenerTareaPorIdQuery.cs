using MediatR;
using TareasAPI.DTOs;

namespace TareasAPI.Queries.Tareas
{
    public record ObtenerTareaPorIdQuery(int Id) : IRequest<TareaDto?>;
        
}
