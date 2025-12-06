using apiinventario.DataAccess;
using apiinventario.Dtos;
using apiinventario.Models;
using apiinventario.Repositorys;

namespace apiinventario.Services
{
    public class VentasService
    {
        private readonly ResumenVentasRepository _resumenVentasRepository;
        private readonly VentaRepository _ventaRepository;
        private readonly DetallleVentaRepository _detallleVentaRepository;
        private readonly ProductoRepository _productoRepository;
        private readonly ApiInventarioContext _context;

        public VentasService(
            ResumenVentasRepository resumenVentasRepository,
            VentaRepository ventaRepository,
            DetallleVentaRepository detallleVentaRepository,
            ProductoRepository productoRepository,
            ApiInventarioContext context
        )
        {
            _resumenVentasRepository = resumenVentasRepository;
            _ventaRepository = ventaRepository;
            _detallleVentaRepository = detallleVentaRepository;
            _productoRepository = productoRepository;
            _context = context;
        }

        public async Task<List<ResumenVentasView>> GetAllVentasAsync()
        {
            return await _resumenVentasRepository.GetAllAsync();
        }

        public async Task<List<ResumenVentasView>> GetVentasByClienteIdAsync(int idCliente)
        {
            return await _resumenVentasRepository.GetByClienteIdAsync(idCliente);
        }

        public async Task<object> CreateVentaAsync(VentaCreateDto dto)
        {
            //crear transaccion
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var producto = await _productoRepository.findByIdProducto(dto.IdProducto, true);

                //restar la cantidad solicitada al producto
                producto.Stock -= dto.Cantidad;
                //si la resta es menor a 0 generamos un error de que ya no hay productos
                if (producto.Stock < 0) throw new Exception("Stock insuficiente");
                //si todo esta bien se edita la cantidad de stock y se guarda la venta
                await _context.SaveChangesAsync();
                //Guardar venta encabezado
                var venta = await _ventaRepository.CreateAsync(new VentaModel { IdCliente = dto.IdCliente, Fecha = DateTime.Now });
                //Guardar detalle de la venta
                var detalle = await _detallleVentaRepository.CreateAsync(new DetalleVentaModel { IdVenta = venta.IdVenta, IdProducto = dto.IdProducto, Cantidad = dto.Cantidad, PrecioUnitario = producto.Precio });
                //Guardar todos lo cambios si todo salio bien
                await transaction.CommitAsync();

                return new { Venta = venta, Detalle = detalle };
            }
            catch
            {
                //revertir cambios en la db si algo salio mal
                await transaction.RollbackAsync();
                throw;
            }
        }

    }
}
