using API_RadiadoresDiaz.Context;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

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

        public class FiltroAuto
        {
            public int idMarca { get; set; }
            public string modelo { get; set; }
            public int? year { get; set; }
            public string? motor { get; set; }
        }

        [HttpGet]
        [EnableCors("AllowAnyOrigin")]
        [Route("[action]")]
        public IActionResult ListaRadiadores()
        {
            try
            {
                var radiadores = context.Producto.ToList();
                return Ok(radiadores);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpGet]
        [EnableCors("AllowAnyOrigin")]
        [Route("[action]")]
        public IActionResult PorMarcaAuto(int idMarca, int idAuto)
        {
            try
            {
                var radiadores = (from p in context.Producto
                                  join ap in context.AutoProducto on p.IdProducto equals ap.IdProducto
                                  join a in context.Auto on ap.IdAuto equals a.idAuto
                                  join m in context.Marca on a.idMarca equals m.IdMarca
                                  where m.IdMarca == idMarca && a.idAuto == idAuto
                                  select new
                                  {
                                      m.NombreMarca,
                                      a.modelo,
                                      a.year,
                                      a.motor,
                                      p.NombreProducto,
                                      p.NoParte,
                                      p.Material,
                                      p.PrecioNuevoInstalado,
                                      p.PrecioNuevoSuelto,
                                      p.PrecioReparadoInstalado,
                                      p.PrecioReparadoSuelto,
                                      p.Observaciones,
                                      p.existencia
                                  }).ToList();
                return Ok(radiadores);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        // GET api/PorMarca/{marca}
        [HttpGet]
        [EnableCors("AllowAnyOrigin")]
        [Route("[action]")]
        public IActionResult PorMarca(string marca)
        {
            try
            {
                var radiadores = (from m in context.Marca
                                  join a in context.Auto on m.IdMarca equals a.idMarca
                                  join ap in context.AutoProducto on a.idAuto equals ap.IdAuto
                                  join p in context.Producto on ap.IdProducto equals p.IdProducto
                                  join prov in context.Proveedor on p.IdProveedor equals prov.IdProveedor
                                  where m.NombreMarca == marca && p.IdTipoProducto == 1
                                  select new
                                  {
                                      m.NombreMarca,
                                      a.modelo,
                                      a.year,
                                      a.motor,
                                      p.NombreProducto,
                                      p.NoParte,
                                      p.Material,
                                      p.PrecioNuevoInstalado,
                                      p.PrecioNuevoSuelto,
                                      p.PrecioReparadoInstalado,
                                      p.PrecioReparadoSuelto,
                                      p.Observaciones,
                                      p.existencia
                                  }).ToList();
                return Ok(radiadores);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // GET api/PorNoParte/{noParte}
        [HttpGet]
        [EnableCors("AllowAnyOrigin")]
        [Route("[action]")]
        public IActionResult PorNoParte(string noParte)
        {
            try
            {
                var radiador = (from p in context.Producto
                                join ap in context.AutoProducto on p.IdProducto equals ap.IdProducto
                                join a in context.Auto on ap.IdAuto equals a.idAuto
                                join ma in context.MarcaAuto on a.idAuto equals ma.IdAuto
                                join m in context.Marca on a.idMarca equals m.IdMarca
                                where p.NoParte == noParte
                                select new
                                {
                                    m.NombreMarca,
                                    a.modelo,
                                    a.year,
                                    a.motor,
                                    p.NombreProducto,
                                    p.NoParte,
                                    p.Material,
                                    p.PrecioNuevoInstalado,
                                    p.PrecioNuevoSuelto,
                                    p.PrecioReparadoInstalado,
                                    p.PrecioReparadoSuelto,
                                    p.Observaciones,
                                    p.existencia
                                }).ToList();
                return Ok(radiador);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // GET api/PorProveedor/{idProveedor}
        [HttpGet]
        [EnableCors("AllowAnyOrigin")]
        [Route("[action]")]
        public IActionResult PorProveedor(int idProveedor)
        {
            try
            {
                var radiadores = (from p in context.Producto
                                  join ap in context.AutoProducto on p.IdProducto equals ap.IdProducto
                                  join a in context.Auto on ap.IdAuto equals a.idAuto
                                  join ma in context.MarcaAuto on a.idAuto equals ma.IdAuto
                                  join m in context.Marca on a.idMarca equals m.IdMarca
                                  where p.IdProveedor == idProveedor
                                  select new
                                  {
                                      m.NombreMarca,
                                      a.modelo,
                                      a.year,
                                      a.motor,
                                      p.NombreProducto,
                                      p.NoParte,
                                      p.Material,
                                      p.PrecioNuevoInstalado,
                                      p.PrecioNuevoSuelto,
                                      p.PrecioReparadoInstalado,
                                      p.PrecioReparadoSuelto,
                                      p.Observaciones,
                                      p.existencia
                                  }).ToList();
                return Ok(radiadores);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // POST api/PorFiltroDeAuto}
        [HttpPost]
        [EnableCors("AllowAnyOrigin")]
        [Route("[action]")]
        public IActionResult PorFiltroDeAuto([FromBody] FiltroAuto filtro)
        {
            try
            {
                if (filtro.year != null)
                {
                    var radiadores = (from m in context.Marca
                                      join a in context.Auto on m.IdMarca equals a.idMarca
                                      join ap in context.AutoProducto on a.idAuto equals ap.IdAuto
                                      join p in context.Producto on ap.IdProducto equals p.IdProducto
                                      join prov in context.Proveedor on p.IdProveedor equals prov.IdProveedor
                                      where m.IdMarca == filtro.idMarca && a.modelo == filtro.modelo
                                      && a.year == filtro.year
                                      select new
                                      {
                                          m.NombreMarca,
                                          a.modelo,
                                          a.year,
                                          a.motor,
                                          p.NombreProducto,
                                          p.NoParte,
                                          p.Material,
                                          p.PrecioNuevoInstalado,
                                          p.PrecioNuevoSuelto,
                                          p.PrecioReparadoInstalado,
                                          p.PrecioReparadoSuelto,
                                          p.Observaciones,
                                          p.existencia
                                      }).ToList();
                    return Ok(radiadores);
                }
                else if (filtro.motor != null)
                {
                    var radiadores = (from m in context.Marca
                                      join a in context.Auto on m.IdMarca equals a.idMarca
                                      join ap in context.AutoProducto on a.idAuto equals ap.IdAuto
                                      join p in context.Producto on ap.IdProducto equals p.IdProducto
                                      join prov in context.Proveedor on p.IdProveedor equals prov.IdProveedor
                                      where m.IdMarca == filtro.idMarca && a.modelo == filtro.modelo
                                      && a.motor == filtro.motor
                                      select new
                                      {
                                          m.NombreMarca,
                                          a.modelo,
                                          a.year,
                                          a.motor,
                                          p.NombreProducto,
                                          p.NoParte,
                                          p.Material,
                                          p.PrecioNuevoInstalado,
                                          p.PrecioNuevoSuelto,
                                          p.PrecioReparadoInstalado,
                                          p.PrecioReparadoSuelto,
                                          p.Observaciones,
                                          p.existencia
                                      }).ToList();
                    return Ok(radiadores);
                }
                else if (filtro.year != null && filtro.motor != null)
                {
                    var radiadores = (from m in context.Marca
                                      join a in context.Auto on m.IdMarca equals a.idMarca
                                      join ap in context.AutoProducto on a.idAuto equals ap.IdAuto
                                      join p in context.Producto on ap.IdProducto equals p.IdProducto
                                      join prov in context.Proveedor on p.IdProveedor equals prov.IdProveedor
                                      where m.IdMarca == filtro.idMarca && a.modelo == filtro.modelo
                                      && a.motor == filtro.motor && a.year == filtro.year
                                      select new
                                      {
                                          m.NombreMarca,
                                          a.modelo,
                                          a.year,
                                          a.motor,
                                          p.NombreProducto,
                                          p.NoParte,
                                          p.Material,
                                          p.PrecioNuevoInstalado,
                                          p.PrecioNuevoSuelto,
                                          p.PrecioReparadoInstalado,
                                          p.PrecioReparadoSuelto,
                                          p.Observaciones,
                                          p.existencia
                                      }).ToList();
                    return Ok(radiadores);
                }
                else
                {
                    var radiadores = (from m in context.Marca
                                      join a in context.Auto on m.IdMarca equals a.idMarca
                                      join ap in context.AutoProducto on a.idAuto equals ap.IdAuto
                                      join p in context.Producto on ap.IdProducto equals p.IdProducto
                                      join prov in context.Proveedor on p.IdProveedor equals prov.IdProveedor
                                      where m.IdMarca == filtro.idMarca && a.modelo == filtro.modelo
                                      select new
                                      {
                                          m.NombreMarca,
                                          a.modelo,
                                          a.year,
                                          a.motor,
                                          p.NombreProducto,
                                          p.NoParte,
                                          p.Material,
                                          p.PrecioNuevoInstalado,
                                          p.PrecioNuevoSuelto,
                                          p.PrecioReparadoInstalado,
                                          p.PrecioReparadoSuelto,
                                          p.Observaciones,
                                          p.existencia
                                      }).ToList();
                    return Ok(radiadores);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
