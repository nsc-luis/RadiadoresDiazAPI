using System.ComponentModel.DataAnnotations;

namespace API_RadiadoresDiaz.Models
{
    public class TipoProducto
    {
        [Key]
        public int idTipoProducto { get; set; }
        [Required]
        public string nombreTipoProducto { get; set; }
    }
}
