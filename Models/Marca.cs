using System.ComponentModel.DataAnnotations;

namespace API_RadiadoresDiaz.Models
{
    public class Marca
    {
        [Key]
        public int IdMarca { get; set; }
        [Required]
        public string NombreMarca { get; set; }
    }
}
