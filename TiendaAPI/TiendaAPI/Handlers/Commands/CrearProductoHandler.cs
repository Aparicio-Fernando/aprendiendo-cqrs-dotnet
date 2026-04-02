using MediatR;
using TiendaAPI.Commands.Productos;
using TiendaAPI.Data;
using TiendaAPI.Entities;
using TiendaAPI.Handlers.Queries;
using TiendaAPI.Interfaces;

namespace TiendaAPI.Handlers.Commands
{
    public class CrearProductoHandler : IRequestHandler<CrearProductoCommand, string>
    {
        private readonly TiendaDbContext _context;

        public CrearProductoHandler(TiendaDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(CrearProductoCommand command, CancellationToken cancellationToken)
        {           
            if (string.IsNullOrWhiteSpace(command.Nombre))
                return "Error: el nombre del producto no puede estar vacío";

            if (command.Precio <= 0)
                return "Error: el precio dene ser mayor a cero";

            var producto = new Producto
            {
                Nombre = command.Nombre,
                Precio = command.Precio
            };

            _context.Productos.Add(producto);
            await _context.SaveChangesAsync(cancellationToken);

            return $"Producto '{command.Nombre}' creado correctamente con Id {producto.Id}";
        }
    }
}
