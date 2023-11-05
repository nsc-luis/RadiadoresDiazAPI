using API_RadiadoresDiaz.Context;
using API_RadiadoresDiaz.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_RadiadoresDiaz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly AppDbContext context;
        public ProductoController(AppDbContext context)
        {
            this.context = context;
        }

        public class FiltroAuto
        {
            public int idMarca { get; set; }
            public string modelo { get; set; }
            public int? year { get; set; }
            public decimal? motor { get; set; }
        }

        public class AutoProveedor
        {
            public int idAuto { get; set; }
            public int idProveedor { get; set; }
        }

        public class fMarcaAuto
        {
            public int year { get; set; }
            public int idMarca { get; set; }
            public int idAuto { get; set; }
        }

        // GET api/PorMarca/{marca}
        [HttpGet]
        [EnableCors("AllowAnyOrigin")]
        [Route("[action]")]
        public IActionResult PorMarca(int idMarca)
        {
            try
            {
                var radiadores = (from m in context.Marca
                                  join a in context.Auto on m.IdMarca equals a.idMarca
                                  join ap in context.AutoProducto on a.idAuto equals ap.IdAuto
                                  join p in context.Producto on ap.IdProducto equals p.IdProducto
                                  join prov in context.Proveedor on p.IdProveedor equals prov.IdProveedor
                                  where m.IdMarca == idMarca && p.IdTipoProducto == 1
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
                                join m in context.Marca on a.idMarca equals m.IdMarca
                                where p.NoParte == noParte && p.IdTipoProducto == 1
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
                var productos = (from p in context.Producto
                                 join ap in context.AutoProducto on p.IdProducto equals ap.IdProducto
                                 join a in context.Auto on ap.IdAuto equals a.idAuto
                                 join m in context.Marca on a.idMarca equals m.IdMarca
                                 join pv in context.Proveedor on p.IdProveedor equals pv.IdProveedor
                                 where p.IdProveedor == idProveedor && p.IdTipoProducto == 1
                                 select new
                                 {
                                     p.IdProducto,
                                     pv.IdProveedor,
                                     pv.NombreProveedor,
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
                return Ok(productos);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // POST api/PorProveedor/{idProveedor}
        [HttpPost]
        [EnableCors("AllowAnyOrigin")]
        [Route("[action]")]
        public IActionResult PorAutoProveedor([FromBody] AutoProveedor apv)
        {
            try
            {
                if (apv.idProveedor == 0)
                {
                    var productos = (from p in context.Producto
                                     join ap in context.AutoProducto on p.IdProducto equals ap.IdProducto
                                     join a in context.Auto on ap.IdAuto equals a.idAuto
                                     join m in context.Marca on a.idMarca equals m.IdMarca
                                     join pv in context.Proveedor on p.IdProveedor equals pv.IdProveedor
                                     where p.IdTipoProducto == 1 && a.idAuto == apv.idAuto
                                     select new
                                     {
                                         p.IdProducto,
                                         pv.IdProveedor,
                                         pv.NombreProveedor,
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
                    return Ok(productos);
                }
                else
                {
                    var productos = (from p in context.Producto
                                     join ap in context.AutoProducto on p.IdProducto equals ap.IdProducto
                                     join a in context.Auto on ap.IdAuto equals a.idAuto
                                     join m in context.Marca on a.idMarca equals m.IdMarca
                                     join pv in context.Proveedor on p.IdProveedor equals pv.IdProveedor
                                     where p.IdProveedor == apv.idProveedor && p.IdTipoProducto == 1 && a.idAuto == apv.idAuto
                                     select new
                                     {
                                         p.IdProducto,
                                         pv.IdProveedor,
                                         pv.NombreProveedor,
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
                    return Ok(productos);
                }

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
                                          m.IdMarca,
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

        // POST api/FiltroMarcaAuto}
        [HttpPost]
        [EnableCors("AllowAnyOrigin")]
        [Route("[action]")]
        public IActionResult FiltroMarcaAuto([FromBody] fMarcaAuto filtro)
        {
            try
            {
                if (filtro.idAuto == 0)
                {
                    var productos = (from ap in context.AutoProducto
                                      join a in context.Auto on ap.IdAuto equals a.idAuto
                                      join m in context.Marca on a.idMarca equals m.IdMarca
                                      join p in context.Producto on ap.IdProducto equals p.IdProducto
                                      where m.IdMarca == filtro.idMarca && a.year == filtro.year
                                      && (from a in context.Auto
                                          where a.idMarca == filtro.idMarca
                                          select a.idAuto).Contains(ap.IdAuto)
                                      select new
                                      {
                                          m.IdMarca,
                                          m.NombreMarca,
                                          a.idAuto,
                                          a.modelo,
                                          a.year,
                                          a.motor,
                                          p.IdProducto,
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
                    return Ok(productos);
                }
                else
                {
                    var productos = (from ap in context.AutoProducto
                                     join a in context.Auto on ap.IdAuto equals a.idAuto
                                     join m in context.Marca on a.idMarca equals m.IdMarca
                                     join p in context.Producto on ap.IdProducto equals p.IdProducto
                                     where m.IdMarca == filtro.idMarca && ap.IdAuto == filtro.idAuto
                                     && a.year == filtro.year
                                     select new
                                     {
                                         m.IdMarca,
                                         m.NombreMarca,
                                         a.idAuto,
                                         a.modelo,
                                         a.year,
                                         a.motor,
                                         p.IdProducto,
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
                    return Ok(productos);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
