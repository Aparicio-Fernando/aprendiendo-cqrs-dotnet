namespace TiendaAPI.Servicios
{
    public class ProductoServicio : IProductoServicio
    {
        private static List<string> _productos = new List<string>
        {
            "Laptop", "Mouse", "Teclado"
        };

        public string Crear(string nombre)
        {
            _productos.Add(nombre);
            return $"Producto '{nombre}' creado correctamente";
        }

        public string Eliminar(int id)
        {
            if (id < 0 || id >= _productos.Count)
                return "Producto no encontrado";

            var nombre = _productos[id];
            _productos.RemoveAt(id);
            return $"Producto '{nombre}' eliminado correctamente";
        }

        public string ObtenerPorId(int id)
        {
            if (id < 0 || id >= _productos.Count)
                return "Producto no encontrado";

            return _productos[id];
        }

        public List<string> ObtenerTodos()
        {
            return _productos;
        }
    }
}
