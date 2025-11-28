using apiinventario.DataAccess;
using apiinventario.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apiinventario.Controllers
{
    [ApiController]
    [Route("api/cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly ApiInventarioContext _context;

        public ClienteController(ApiInventarioContext context)
        {
            _context = context;
        }

        // GET: Cliente
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return await ReponseHelper.HandleSend(async () =>{
                var clientes = await _context.ClienteModel.ToListAsync();
                return clientes;
            }, "Clientes listados correctamente.");
        }
    }
}
