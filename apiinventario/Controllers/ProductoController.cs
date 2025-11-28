using apiinventario.DataAccess;
using apiinventario.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apiinventario.Controllers
{
    [ApiController]
    [Route("api/producto")]
    public class ProductoController : ControllerBase
    {
        private readonly ApiInventarioContext _context;

        public ProductoController(ApiInventarioContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return await ReponseHelper.HandleSend(async () =>{
                var productos = await _context.ProductoModel.ToListAsync();
                return productos;
            }, "Productos listados correctamente.");
            
        }

    }
}
