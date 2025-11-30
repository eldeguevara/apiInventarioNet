using apiinventario.DataAccess;
using apiinventario.Interfaces;
using apiinventario.Models;
using Microsoft.EntityFrameworkCore;

namespace apiinventario.Repositorys
{
    public class ResumenVentasRepository : IResumenVentasRepository
    {
        private readonly ApiInventarioContext _context;

        public ResumenVentasRepository(ApiInventarioContext context)
        {
            _context = context;
        }

        public async Task<List<ResumenVentasView>> GetAllAsync()
        {
            return await _context.ResumenVentasView.ToListAsync();
        }

        public async Task<List<ResumenVentasView>> GetByClienteIdAsync(int idCliente)
        {
            return await _context.ResumenVentasView
                                .Where(rv => rv.IdCliente == idCliente)
                                .ToListAsync();
        }
    }
}
