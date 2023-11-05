using API_RadiadoresDiaz.Context;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_RadiadoresDiaz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private readonly AppDbContext context;
        public ProveedorController(AppDbContext context)
        {
            this.context = context;
        }

        // GET api/PorAuto
        [HttpGet]
        [EnableCors("AllowAnyOrigin")]
        [Route("[action]")]
        public IActionResult PorAuto(int idAuto)
        {
            try
            {
                var proveedores = (from pv in context.Proveedor
                                   join p in context.Producto on pv.IdProveedor equals p.IdProveedor
                                   join ap in context.AutoProducto on p.IdProducto equals ap.IdProducto
                                   where ap.IdAuto == idAuto
                                   select pv).ToList().Distinct();
                return Ok(proveedores);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
