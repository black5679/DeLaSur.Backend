namespace DeLaSur.Backend.Application.Commands.Compra.Update
{
    public class UpdateCompraRequest
    {
        public required int Id { get; set; }
        public required int IdProveedor { get; set; }
        public required int UsuarioModificacion { get; set; }
        public required List<UpdateDetalleCompraRequest> Detalles { get; set; }
    }
    public class UpdateDetalleCompraRequest
    {
        public required int IdMaterial { get; set; }
        public required int Cantidad { get; set; }
        public required decimal Precio { get; set; }
    }
}
