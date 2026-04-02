using MediatR;
using TareasAPI.DTOs;

namespace TareasAPI.Queries.Tareas
{
    public record ObtenerTareasQuery() : IRequest<List<TareaDto>>;
        
}
