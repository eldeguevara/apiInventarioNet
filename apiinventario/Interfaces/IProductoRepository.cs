using apiinventario.Models;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;

namespace apiinventario.Interfaces
{
    public interface IProductoRepository
    {

        Task<List<ProductoModel>> GetAllAsync();

        Task<ProductoModel?> findByIdProducto(int IdProducto, bool error = false);

    }
}
