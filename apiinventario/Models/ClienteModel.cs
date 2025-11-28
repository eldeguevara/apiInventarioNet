using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiinventario.Models
{
    [Table("cliente")]
    public class ClienteModel
    {
        [Key]
        [Column("id_cliente")]
        public int IdCliente { get; set; }

        [Required]
        [Column("nombre_cliente")]
        [MaxLength(500)]
        public string NombreCliente { get; set; } = string.Empty;

        [Column("email")]
        [MaxLength(500)]
        public string? Email { get; set; }
    }
}
