using apiinventario.DataAccess;
using apiinventario.Interfaces;
using apiinventario.Models;
using Microsoft.EntityFrameworkCore;

namespace apiinventario.Repositorys
{
    public class ClienteRepository : IClienteRepository
    {

        private readonly ApiInventarioContext _context; 

        public ClienteRepository(ApiInventarioContext context)
        {
            _context = context;
        }

        public async Task<List<ClienteModel>> GetAllAsync()
        {
            return await _context.ClienteModel.ToListAsync();
        }
    }
}
