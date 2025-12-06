using apiinventario.Models;

namespace apiinventario.Interfaces
{
    public interface IDetallleVentaRepository
    {

        Task<DetalleVentaModel> CreateAsync(DetalleVentaModel detalle);

    }
}
