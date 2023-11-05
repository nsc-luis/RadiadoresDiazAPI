using API_RadiadoresDiaz.Context;
using API_RadiadoresDiaz.Models;
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

        public class MarcaYear
        {
            public int idMarca { get; set; }
            public int year { get; set; }
        }

        // GET api/PorModelo
        [HttpGet]
        [EnableCors("AllowAnyOrigin")]
        public IActionResult Get()
        {
            try
            {
                var autos = (from a in context.Auto
                             join m in context.Marca on a.idMarca equals m.IdMarca
                             orderby m.NombreMarca ascending, a.year descending
                             select new
                             {
                                 m.IdMarca,
                                 m.NombreMarca,
                                 a.idAuto,
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
                             orderby a.modelo ascending, a.year descending
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

        // POST api/modeloPorMarcaYear
        [HttpPost]
        [EnableCors("AllowAnyOrigin")]
        [Route("[action]")]
        public IActionResult modeloPorMarcaYear([FromBody] MarcaYear my)
        {
            try
            {
                if (my.year == 0)
                {
                    var autos = (from a in context.Auto
                                 join m in context.Marca on a.idMarca equals m.IdMarca
                                 where my.idMarca == m.IdMarca
                                 orderby a.modelo ascending, a.year descending
                                 select new
                                 {
                                     m.IdMarca,
                                     m.NombreMarca,
                                     a.idAuto,
                                     a.modelo,
                                     a.year,
                                     a.motor
                                 }).ToList();
                    return Ok(autos);
                }
                else
                {
                    var autos = (from a in context.Auto
                                 join m in context.Marca on a.idMarca equals m.IdMarca
                                 where my.idMarca == m.IdMarca && my.year == a.year
                                 orderby a.modelo ascending, a.year descending
                                 select new
                                 {
                                     m.IdMarca,
                                     m.NombreMarca,
                                     a.idAuto,
                                     a.modelo,
                                     a.year,
                                     a.motor
                                 }).ToList();
                    return Ok(autos);
                }

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // GET api/listaYears
        [HttpGet]
        [EnableCors("AllowAnyOrigin")]
        [Route("[action]")]
        public IActionResult listaYears()
        {
            try
            {
                var years = (from a in context.Auto
                             orderby a.year descending
                             select a.year).ToList().Distinct();
                return Ok(years);
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
                             orderby a.modelo ascending, a.year descending
                             select new
                             {
                                 a.idAuto,
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
