using apiinventario.Models;

namespace apiinventario.Interfaces
{
    public interface IClienteRepository
    {

        Task<List<ClienteModel>> GetAllAsync();

    }
}
