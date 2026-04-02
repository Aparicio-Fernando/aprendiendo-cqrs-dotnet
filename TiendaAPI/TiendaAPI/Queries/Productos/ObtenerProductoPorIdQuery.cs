using MediatR;
using TiendaAPI.DTOs;

namespace TiendaAPI.Queries.Productos
{
    public record ObtenerProductoPorIdQuery(int Id) : IRequest<ProductoDto?>;

}
