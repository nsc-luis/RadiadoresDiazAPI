using System.ComponentModel.DataAnnotations;

namespace API_RadiadoresDiaz.Models
{
    public class MarcaAuto_emilinar
    {
        [Key]
        public int IdMarcaAuto { get; set; }
        [Required]
        public int IdAuto { get; set; }
        [Required]
        public int IdMarca { get; set; }
    }
}
