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
        public string motor { get; set; }
        public DateTime registro { get; set; }
    }
}
