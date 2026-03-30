using TiendaAPI.Commands.Productos;

namespace TiendaAPI.Handlers.Commands
{
    public class CrearProductoHandler
    {
        // Lista en memoria — después la reemplazamos con base de datos
        public static List<string> _productos = new List<string>
        {
            "Laptop", "Mouse", "Teclado"
        };

        public string Handle(CrearProductoCommand commnand)
        {
            _productos.Add(commnand.Nombre);
            return $"Producto '{commnand.Nombre}' creado correctamente";
        }
    }
}
