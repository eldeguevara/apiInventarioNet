using System.ComponentModel.DataAnnotations.Schema;

namespace apiinventario.Models
{
    [Table("vwResumenVentas")]
    public class ResumenVentasView
    {
        [Column("id_cliente")]
        public int IdCliente { get; set; }

        [Column("nombre_cliente")]
        public string NombreCliente { get; set; } = string.Empty;

        [Column("email")]
        public string? Email { get; set; }

        [Column("fecha_venta", TypeName = "date")]
        public DateTime? FechaVenta { get; set; }

        [Column("id_producto")]
        public int? IdProducto { get; set; }

        [Column("nombre_producto")]
        public string? NombreProducto { get; set; }

        [Column("total_venta", TypeName = "decimal(10,2)")]
        public decimal TotalVenta { get; set; }

        [Column("precio_actual_producto", TypeName = "decimal(10,2)")]
        public decimal? PrecioActualProducto { get; set; }

        [Column("stock_actual")]
        public int? StockActual { get; set; }
    }
}
