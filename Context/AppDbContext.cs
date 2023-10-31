using API_RadiadoresDiaz.Models;
using Microsoft.EntityFrameworkCore;

namespace API_RadiadoresDiaz.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Autos> Auto { get; set; }
        public DbSet<AutoProducto> AutoProducto { get; set; }
        public DbSet<Marca> Marca { get; set; }
        public DbSet<MarcaAuto> MarcaAuto { get; set; }

        public DbSet<Producto> Producto { get; set; }
        public DbSet<Proveedor> Proveedor { get; set; }
        public DbSet<TipoProducto> TipoProducto { get; set; }
    }
}
