using apiinventario.Interfaces;
using apiinventario.Models;

namespace apiinventario.Repositorys
{
    public class VentaRepository : IVentaRepository
    {
        public Task<VentaModel> CreateAsync(VentaModel venta)
        {
            throw new NotImplementedException();
        }
    }
}
