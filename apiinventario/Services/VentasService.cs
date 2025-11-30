using apiinventario.Models;
using apiinventario.Repositorys;

namespace apiinventario.Services
{
    public class VentasService
    {
        private readonly ResumenVentasRepository _resumenVentasRepository;

        public VentasService(ResumenVentasRepository resumenVentasRepository)
        {
            _resumenVentasRepository = resumenVentasRepository;
        }

        public async Task<List<ResumenVentasView>> GetAllVentasAsync()
        {
            return await _resumenVentasRepository.GetAllAsync();
        }

        public async Task<List<ResumenVentasView>> GetVentasByClienteIdAsync(int idCliente)
        {
            return await _resumenVentasRepository.GetByClienteIdAsync(idCliente);
        }

    }
}
