namespace TiendaAPI.Commands.Productos
{
    // El Command solo transporta datos — es un record
    public record CrearProductoCommand(string Nombre, decimal Precio)
    {
    }
}
