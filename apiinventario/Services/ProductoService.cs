using apiinventario.Models;
using apiinventario.Repositorys;

namespace apiinventario.Services
{
    public class ProductoService
    {

        private readonly ProductoRepository _productoRepository;

        public ProductoService(ProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public async Task<List<ProductoModel>> GetAllProductosAsync()
        {
            return await _productoRepository.GetAllAsync();
        }

    }
}
