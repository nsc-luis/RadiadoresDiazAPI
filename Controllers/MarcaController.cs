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
    }
}
