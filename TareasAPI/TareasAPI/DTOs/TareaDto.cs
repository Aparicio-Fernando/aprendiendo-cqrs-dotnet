using TareasAPI.Entities;

namespace TareasAPI.DTOs
{
    public record TareaDto(int Id, string Titulo, string Descripcion, Prioridad Prioridad, DateTime FechaCreacion, DateTime? FechaLimite, bool Completada)
    {        
    }
}
