using apiinventario.Models;

namespace apiinventario.Interfaces
{
    public interface IProductoRepository
    {

        Task<List<ProductoModel>> GetAllAsync();

    }
}
