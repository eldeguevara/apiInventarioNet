using apiinventario.DataAccess;
using apiinventario.Dtos;
using apiinventario.Helpers;
using Microsoft.AspNetCore.Mvc;
using apiinventario.Services;
using apiinventario.Models;
using Microsoft.EntityFrameworkCore;

namespace apiinventario.Controllers
{
    [ApiController]
    [Route("api/venta")]
    public class VentasController : ControllerBase
    {
        private readonly VentasService _ventasService;
        private readonly ApiInventarioContext _context;

        public VentasController(VentasService ventasService, ApiInventarioContext context)
        {
            _ventasService = ventasService;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return await ReponseHelper.HandleSend(async () => {
                var resumenVenta = await _ventasService.GetAllVentasAsync();
                return resumenVenta;
            }, "Ventas listados correctamente.");

        }

        [HttpGet("{idCliente}")]
        public async Task<IActionResult> GetById(int idCliente)
        {
            return await ReponseHelper.HandleSend(async () => {
                var resumenVenta = await _ventasService.GetVentasByClienteIdAsync(idCliente);
                return resumenVenta;
            }, "Ventas listados correctamente.");
        }

        [HttpPost]
        public async Task<IActionResult> CrearVenta([FromBody] VentaCreateDto dto)
        {
            return await ReponseHelper.HandleSend(async () =>
            {
                var result = await _ventasService.CreateVentaAsync(dto);
                return result;
            }, "Venta creada correctamente");
        }

    }
}
