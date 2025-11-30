using apiinventario.Models;

namespace apiinventario.Interfaces
{
    public interface IResumenVentasRepository
    {

        Task<List<ResumenVentasView>> GetAllAsync();
        Task<List<ResumenVentasView>> GetByClienteIdAsync(int idCliente);

    }
}
