using System.ComponentModel.DataAnnotations;

namespace API_RadiadoresDiaz.Models
{
    public class Autos
    {
        [Key]
        public int idAuto { get; set; }
        public int idMarca { get; set; }
        public string modelo { get; set; }
        public int year { get; set; }
        public decimal motor { get; set; }
        public DateTime timestamp { get; set; }
    }
}
