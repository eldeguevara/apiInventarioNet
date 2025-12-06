using apiinventario.DataAccess;
using apiinventario.Interfaces;
using apiinventario.Models;
using Humanizer;
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

        public async Task<ProductoModel?> findByIdProducto(int IdProducto, bool error = false)
        {
            var producto = await _context.ProductoModel.FirstOrDefaultAsync(p => p.IdProducto == IdProducto);
            if (producto == null && error == true) throw new Exception("Producto no encontrado");
            return producto;
        }

        public async Task<List<ProductoModel>> GetAllAsync()
        {
            return await _context.ProductoModel.ToListAsync();
        }

    }
}
