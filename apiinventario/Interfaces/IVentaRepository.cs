using apiinventario.Models;

namespace apiinventario.Interfaces
{
    public interface IVentaRepository
    {
        Task<VentaModel> CreateAsync(VentaModel venta);
    }
}
