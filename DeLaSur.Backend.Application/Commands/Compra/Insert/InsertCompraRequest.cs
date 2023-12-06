namespace DeLaSur.Backend.Application.Commands.Compra.Insert
{
    public class InsertCompraRequest
    {
        public required int IdProveedor { get; set; }
        public required int UsuarioCreacion { get; set; }
        public required List<InsertDetalleCompraRequest> Detalles { get; set; }
    }
    public class InsertDetalleCompraRequest
    {
        public required int IdMaterial { get; set; }
        public required int Cantidad { get; set; }
        public required decimal Precio { get; set; }
    }
}
