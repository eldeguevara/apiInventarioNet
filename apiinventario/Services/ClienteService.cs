using apiinventario.Models;
using apiinventario.Repositorys;

namespace apiinventario.Services
{
    public class ClienteService
    {

        private readonly ClienteRepository _clienteRepository;

        public ClienteService(ClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<List<ClienteModel>> GetAllClientesAsync()
        {
            return await _clienteRepository.GetAllAsync();
        }

    }
}
