using apiinventario.Helpers;
using apiinventario.Services;
using Microsoft.AspNetCore.Mvc;

namespace apiinventario.Controllers
{
    [ApiController]
    [Route("api/cliente")]
    public class ClienteController : ControllerBase
    {
        private ClienteService _clienteService;

        public ClienteController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        // GET: Cliente
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return await ReponseHelper.HandleSend(async () =>{
                var clientes = await _clienteService.GetAllClientesAsync();
                return clientes;
            }, "Clientes listados correctamente.");
        }
    }
}
