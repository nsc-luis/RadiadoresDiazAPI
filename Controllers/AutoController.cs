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

        [HttpGet]
        [EnableCors("AllowAnyOrigin")]
        [Route("[action]")]
        public IActionResult ListaAuto()
        {
            try
            {
                var autos = context.Auto.ToList();
                return Ok(autos);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
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
                             join ma in context.MarcaAuto on a.idAuto equals ma.IdAuto
                             join m in context.Marca on ma.IdMarca equals m.IdMarca
                             where a.modelo == modelo
                             select new
                             {
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
                             join ma in context.MarcaAuto on a.idAuto equals ma.IdAuto
                             join m in context.Marca on ma.IdMarca equals m.IdMarca
                             where a.year == year
                             select new
                             {
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
