namespace TiendaAPI.Servicios
{
    public interface IProductoServicio
    {
        List<string> ObtenerTodos();
        string ObtenerPorId(int id);
        string Crear(string nombre);
        string Eliminar(int id);
    }
}
