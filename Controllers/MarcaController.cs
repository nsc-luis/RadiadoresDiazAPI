using API_RadiadoresDiaz.Context;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace API_RadiadoresDiaz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private readonly AppDbContext context;
        public MarcaController(AppDbContext context)
        {
            this.context = context;
        }

        // GET api/
        [HttpGet]
        [EnableCors("AllowAnyOrigin")]
        public IActionResult Get()
        {
            try
            {
                var marcas = context.Marca.ToList();    
                return Ok(marcas);
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
                if (year == 0)
                {
                    var marcas = (from a in context.Auto
                                  join m in context.Marca on a.idMarca equals m.IdMarca
                                  select new
                                  {
                                      m.IdMarca,
                                      m.NombreMarca
                                  }).ToList().Distinct();
                    return Ok(marcas);
                }
                else
                {
                    var marcas = (from a in context.Auto
                                  join m in context.Marca on a.idMarca equals m.IdMarca
                                  where a.year == year
                                  select new
                                  {
                                      m.IdMarca,
                                      m.NombreMarca
                                  }).ToList().Distinct();
                    return Ok(marcas);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
