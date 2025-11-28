using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiinventario.Models
{
    [Table("detalle_venta")]
    public class DetalleVentaModel
    {
        [Key]
        [Column("id_detalle_venta")]
        public int IdDetalleVenta { get; set; }

        [Required]
        [Column("id_venta")]
        public int IdVenta { get; set; }

        [Required]
        [Column("id_producto")]
        public int IdProducto { get; set; }

        [Required]
        [Column("cantidad")]
        public int Cantidad { get; set; } = 0;

        [Required]
        [Column("precio_unitario", TypeName = "decimal(10,2)")]
        public decimal PrecioUnitario { get; set; } = 0;

        
        [ForeignKey("IdVenta")]
        public VentaModel? Venta { get; set; }

        [ForeignKey("IdProducto")]
        public ProductoModel? Producto { get; set; }
    }
}
