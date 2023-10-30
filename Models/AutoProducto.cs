using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace API_RadiadoresDiaz.Models
{
    public class AutoProducto
    {
        [Key]
        public int IdAutoProducto { get; set; }
        [Required]
        public int IdAuto { get; set; }
        [Required]
        public int IdProducto { get; set; }
    }
}
