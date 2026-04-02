using MediatR;
using TiendaAPI.DTOs;

namespace TiendaAPI.Queries.Productos
{
    // La Query transporta los parámetros de búsqueda — también es un record |||| IRequest<List<ProductoDto>> le dice a MediatR que devuelve una lista de DTOs
    public record ObtenerProductosQuery() : IRequest<List<ProductoDto>>;
    
    
}
