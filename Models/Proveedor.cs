using System.ComponentModel.DataAnnotations;

namespace API_RadiadoresDiaz.Models
{
    public class Proveedor
    {
        [Key]
        public int IdProveedor { get; set; }
        [Required]
        public string NombreProveedor { get; set; }
    }
}
