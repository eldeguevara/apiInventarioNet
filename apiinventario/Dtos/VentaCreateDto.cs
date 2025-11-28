namespace apiinventario.Dtos
{
    public class VentaCreateDto
    {
        public int IdCliente { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
    }
}
