using apiinventario.DataAccess;
using apiinventario.Dtos;
using apiinventario.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using apiinventario.Models;

namespace apiinventario.Controllers
{
    [ApiController]
    [Route("api/venta")]
    public class VentasController : ControllerBase
    {
        private readonly ApiInventarioContext _context;

        public VentasController(ApiInventarioContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return await ReponseHelper.HandleSend(async () => {
                var resumenVenta = await _context.ResumenVentasView.ToListAsync();
                return resumenVenta;
            }, "Ventas listados correctamente.");

        }

        [HttpGet("{idCliente}")]
        public async Task<IActionResult> GetById(int idCliente)
        {
            return await ReponseHelper.HandleSend(async () => {
                var resumenVenta = await _context.ResumenVentasView
                    .Where(rv => rv.IdCliente == idCliente)
                    .ToListAsync();
                return resumenVenta;
            }, "Ventas listados correctamente.");
        }

        [HttpPost]
        public async Task<IActionResult> CrearVenta([FromBody] VentaCreateDto dto)
        {
            return await ReponseHelper.HandleSend(async () =>
            {
                using var transaction = await _context.Database.BeginTransactionAsync();

                try
                {
                    var venta = new VentaModel { IdCliente = dto.IdCliente, Fecha = DateTime.Now };
                    _context.VentaModel!.Add(venta);
                    await _context.SaveChangesAsync();

                    var producto = await _context.ProductoModel!.FirstOrDefaultAsync(p => p.IdProducto == dto.IdProducto);
                    if (producto == null) throw new Exception("Producto no encontrado");

                    var detalle = new DetalleVentaModel { IdVenta = venta.IdVenta, IdProducto = dto.IdProducto, Cantidad = dto.Cantidad, PrecioUnitario = producto.Precio };
                    _context.DetalleVentaModel!.Add(detalle);

                    producto.Stock -= dto.Cantidad;
                    if (producto.Stock < 0) throw new Exception("Stock insuficiente");

                    await _context.SaveChangesAsync();

                    await transaction.CommitAsync();

                    return new { Venta = venta, Detalle = detalle };
                }
                catch
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }, "Venta creada correctamente");
        }

    }
}
