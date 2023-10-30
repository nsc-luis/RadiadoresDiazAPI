using API_RadiadoresDiaz.Models;
using Microsoft.EntityFrameworkCore;

namespace API_RadiadoresDiaz.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Autos> Autos { get; set; }
        public DbSet<AutoProducto> AutoProductos { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<MarcaAuto> MarcaAutos { get; set; }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Proveedor> Proveedors { get; set; }
        public DbSet<TipoProducto> TipoProductos { get; set; }
    }
}
