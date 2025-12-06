using apiinventario.DataAccess;
using apiinventario.Interfaces;
using apiinventario.Models;
using Humanizer;
using Microsoft.EntityFrameworkCore;

namespace apiinventario.Repositorys
{
    public class DetallleVentaRepository : IDetallleVentaRepository
    {
        private readonly ApiInventarioContext _context;

        public DetallleVentaRepository(ApiInventarioContext context)
        {
            _context = context;
        }

        public async Task<DetalleVentaModel> CreateAsync(DetalleVentaModel detalle)
        {
            _context.DetalleVentaModel!.Add(detalle);
            await _context.SaveChangesAsync();
            return detalle;
        }
    }
}
