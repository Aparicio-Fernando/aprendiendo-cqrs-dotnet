using TiendaAPI.Queries.Productos;

namespace TiendaAPI.Handlers.Queries
{
    public class ObtenerProductosHandler
    {
        private static List<string> _productos = new List<string>
        {
            "Laptop", "Mouse", "Teclado"
        };

        public List<string> Handle(ObtenerProductosQuery query)
        {
            return _productos;
        }
    }
}
