using apiinventario.DataAccess;
using apiinventario.Interfaces;
using apiinventario.Models;
using Microsoft.EntityFrameworkCore;

namespace apiinventario.Repositorys
{
    public class ProductoRepository : IProductoRepository
    {

        private readonly ApiInventarioContext _context;

        public ProductoRepository(ApiInventarioContext context)
        {
            _context = context;
        }

        public async Task<List<ProductoModel>> GetAllAsync()
        {
            return await _context.ProductoModel.ToListAsync();
        }

    }
}
