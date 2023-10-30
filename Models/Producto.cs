using System.ComponentModel.DataAnnotations;

namespace API_RadiadoresDiaz.Models
{
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        [Required]
        public decimal PrecioNuevoSuelto { get; set; }
        [Required]
        public decimal PrecioNuevoInstalado { get; set; }
        [Required]
        public decimal PrecioReparadoSuelto { get; set; }
        [Required]
        public decimal PrecioReparadoInstalado { get; set; }
        public decimal CostoProveedor { get; set; }
        [Required]
        public int IdTipoProducto { get; set; }
        public string NoParte { get; set; }
        public string Material { get; set; }
        public string Observaciones { get; set; }
        [Required]
        public int IdProveedor { get; set; }
    }
}
