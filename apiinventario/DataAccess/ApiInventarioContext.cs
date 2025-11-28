using apiinventario.Models;
using Microsoft.EntityFrameworkCore;

namespace apiinventario.DataAccess
{
    public class ApiInventarioContext : DbContext
    {
        public ApiInventarioContext(DbContextOptions<ApiInventarioContext> options)
            : base(options)
        {
        }

        public DbSet<ProductoModel>? ProductoModel { get; set; }

        public DbSet<ClienteModel>? ClienteModel { get; set; }

        public DbSet<VentaModel>? VentaModel { get; set; }

        public DbSet<DetalleVentaModel>? DetalleVentaModel { get; set; }

        public DbSet<ResumenVentasView>? ResumenVentasView { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<ResumenVentasView>()
                .HasNoKey()                   
                .ToView("vwResumenVentas");
        }
    }
}
