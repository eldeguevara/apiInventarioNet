using apiinventario.Helpers;
using apiinventario.Services;
using Microsoft.AspNetCore.Mvc;

namespace apiinventario.Controllers
{
    [ApiController]
    [Route("api/producto")]
    public class ProductoController : ControllerBase
    {
        private readonly ProductoService _productoService;

        public ProductoController(ProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return await ReponseHelper.HandleSend(async () =>{
                var productos = await _productoService.GetAllProductosAsync();
                return productos;
            }, "Productos listados correctamente.");
            
        }

    }
}
