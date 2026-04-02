using TiendaAPI.Commands.Productos;
using TiendaAPI.Handlers.Queries;
using TiendaAPI.Interfaces;

namespace TiendaAPI.Handlers.Commands
{
    public class CrearProductoHandler : ICommandHandler<CrearProductoCommand>
    {        
        public async Task<string> Handle(CrearProductoCommand command)
        {
            // Simulamos una operación async (después será base de datos real)            
            await Task.Delay(1);

            if (string.IsNullOrWhiteSpace(command.Nombre))
                return "Error: el nombre del producto no puede estar vacío";

            if (command.Precio <= 0)
                return "Error: el precio dene ser mayor a cero";

            var nuevoId = ObtenerProductosHandler._productos.Count + 1;
            ObtenerProductosHandler._productos.Add(new Entities.Producto
            {
                Id = nuevoId,
                Nombre = command.Nombre,
                Precio = command.Precio,
            });


            return $"Producto '{command.Nombre}' creado correctamente con Id {nuevoId}";
        }
    }
}
