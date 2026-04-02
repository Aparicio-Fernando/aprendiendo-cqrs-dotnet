using System.ComponentModel.DataAnnotations;

namespace TareasAPI.Entities
{
    public class Tarea
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Titulo {  get; set; } = string.Empty;

        [Required]
        public string Descripcion {  get; set; } = string.Empty;

        [Required]
        public Prioridad Prioridad { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;


        public DateTime? FechaLimite {  get; set; }

        public bool Completada {  get; set; } = false;

        public bool Activa {  get; set; } = true;
    }
}
