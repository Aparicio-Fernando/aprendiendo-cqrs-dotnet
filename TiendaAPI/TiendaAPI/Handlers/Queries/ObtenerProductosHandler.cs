using TiendaAPI.Interfaces;
using TiendaAPI.Queries.Productos;

namespace TiendaAPI.Handlers.Queries
{
    public class ObtenerProductosHandler : IQueryHandler<ObtenerProductosQuery, List<string>>
    {
        private static List<string> _productos = new List<string>
        {
            "Laptop", "Mouse", "Teclado"
        };

        public async Task<List<string>> Handle(ObtenerProductosQuery query)
        {
            await Task.Delay(1);
            return _productos;
        }
    }
}
