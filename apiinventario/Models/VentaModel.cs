using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiinventario.Models
{
    [Table("venta")]
    public class VentaModel
    {
        [Key]
        [Column("id_venta")]
        public int IdVenta { get; set; }

        [Column("fecha", TypeName = "date")]
        public DateTime Fecha { get; set; } = DateTime.Now.Date;

        [Required]
        [Column("id_cliente")]
        public int IdCliente { get; set; }

        [ForeignKey("IdCliente")]
        public ClienteModel? Cliente { get; set; }
    }
}
