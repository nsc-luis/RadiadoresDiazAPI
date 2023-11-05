using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace API_RadiadoresDiaz.Models
{
    public class Auto
    {
        [Key]
        public int idAuto { get; set; }
        public int idMarca { get; set; }
        public string modelo { get; set; }
        public int year { get; set; }
        [Precision(2, 1)]
        public decimal motor { get; set; }
        public DateTime timestamp { get; set; }
    }
}
