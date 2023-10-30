using API_RadiadoresDiaz.Context;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_RadiadoresDiaz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RadiadoresController : ControllerBase
    {
        private readonly AppDbContext context;
        public RadiadoresController(AppDbContext context)
        {
            this.context = context;
        }


        // GET api/<RadiadoresController>
        [HttpGet]
        [EnableCors("AllowAnyOrigin")]
        public IActionResult Get()
        {
            try
            {
                var productos = context.Productos.ToList();
                return Ok(productos);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        // GET api/<RadiadoresController>
        [HttpGet("{noParte}")]
        [EnableCors("AllowAnyOrigin")]
        public IActionResult Get(string noParte)
        {
            try
            {
                var producto = (from p in context.Productos
                                select p).ToList();
                return Ok(producto);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
