using System.ComponentModel.DataAnnotations;

namespace TiendaAPI.Entities
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Nombre {  get; set; }

        [Required]
        public decimal Precio {  get; set; }

        public bool Activo { get; set; } = true;
    }
}
