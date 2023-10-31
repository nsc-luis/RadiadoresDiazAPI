using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace API_RadiadoresDiaz.Models
{
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        [Required]
        [Precision(7, 2)]
        public decimal PrecioNuevoSuelto { get; set; }
        [Required]
        [Precision(7, 2)]
        public decimal PrecioNuevoInstalado { get; set; }
        [Required]
        [Precision(7, 2)]
        public decimal PrecioReparadoSuelto { get; set; }
        [Required]
        [Precision(7, 2)]
        public decimal PrecioReparadoInstalado { get; set; }
        [Precision(7, 2)]
        public decimal CostoProveedor { get; set; }
        [Required]
        public int IdTipoProducto { get; set; }
        public string NoParte { get; set; }
        public string Material { get; set; }
        public string Observaciones { get; set; }
        [Required]
        public int IdProveedor { get; set; }
        public int existencia { get; set; }
        public DateTime registro { get; set; }
    }
}
