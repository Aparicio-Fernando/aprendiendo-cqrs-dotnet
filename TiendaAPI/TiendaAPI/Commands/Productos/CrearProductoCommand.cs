using MediatR;

namespace TiendaAPI.Commands.Productos
{    
    // El Command solo transporta datos — es un record |||| IRequest<string> le dice a MediatR que este Command devuelve un string
    public record CrearProductoCommand(string Nombre, decimal Precio) : IRequest<string>;
    
    
}
