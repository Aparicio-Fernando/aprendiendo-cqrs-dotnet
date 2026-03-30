using TiendaAPI.Commands.Productos;
using TiendaAPI.Interfaces;

namespace TiendaAPI.Handlers.Commands
{
    public class CrearProductoHandler : ICommandHandler<CrearProductoCommand>
    {
        // Lista en memoria — después la reemplazamos con base de datos
        public static List<string> _productos = new List<string>
        {
            "Laptop", "Mouse", "Teclado"
        };

        public async Task<string> Handle(CrearProductoCommand command)
        {
            // Simulamos una operación async (después será base de datos real)
            await Task.Delay(1);

            if (string.IsNullOrWhiteSpace(command.Nombre))
                return "Error: el nombre del producto no puede estar vacío";

            if (command.Precio <= 0)
                return "Error: el precio dene ser mayor a cero";

            _productos.Add(command.Nombre);
            return $"Producto '{command.Nombre}' creado correctamente";
        }
    }
}
