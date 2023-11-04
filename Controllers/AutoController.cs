using API_RadiadoresDiaz.Context;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_RadiadoresDiaz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoController : ControllerBase
    {
        private readonly AppDbContext context;
        public AutoController(AppDbContext context)
        {
            this.context = context;
        }

        // GET api/PorModelo
        [HttpGet]
        [EnableCors("AllowAnyOrigin")]
        [Route("[action]")]
        public IActionResult PorModelo(string modelo)
        {
            try
            {
                var autos = (from a in context.Auto
                             join m in context.Marca on a.idMarca equals m.IdMarca
                             where a.modelo == modelo
                             select new
                             {
                                 m.IdMarca,
                                 m.NombreMarca,
                                 a.modelo,
                                 a.year,
                                 a.motor
                             }).ToList();
                return Ok(autos);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // GET api/PorYear
        [HttpGet]
        [EnableCors("AllowAnyOrigin")]
        [Route("[action]")]
        public IActionResult PorYear(int year)
        {
            try
            {
                var autos = (from a in context.Auto
                             join m in context.Marca on a.idMarca equals m.IdMarca
                             where a.year == year
                             select new
                             {
                                 m.IdMarca,
                                 m.NombreMarca,
                                 a.modelo,
                                 a.year,
                                 a.motor
                             }).ToList();
                return Ok(autos);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // GET api/PorMarca
        [HttpGet]
        [EnableCors("AllowAnyOrigin")]
        [Route("[action]")]
        public IActionResult PorMarca(int idMarca)
        {
            try
            {
                var autos = (from a in context.Auto
                             join m in context.Marca on a.idMarca equals m.IdMarca
                             where a.idMarca == idMarca
                             select new
                             {
                                 m.IdMarca,
                                 m.NombreMarca,
                                 a.modelo,
                                 a.year,
                                 a.motor
                             }).ToList();
                return Ok(autos);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
