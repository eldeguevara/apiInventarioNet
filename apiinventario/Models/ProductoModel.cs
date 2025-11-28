using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiinventario.Models
{
    [Table("producto")]
    public class ProductoModel
    {
        [Key]
        [Column("id_producto")]
        public int IdProducto { get; set; }

        [Required]
        [Column("nombre_producto")]
        [MaxLength(250)]
        public string NombreProducto { get; set; } = string.Empty;

        [Required]
        [Column("precio", TypeName = "decimal(10,2)")]
        public decimal Precio { get; set; } = 0;

        [Required]
        [Column("stock")]
        public int Stock { get; set; } = 0;
    }
}
