using DeLaSur.Backend.Domain.Base;

namespace DeLaSur.Backend.Domain.Models
{
    public class DetalleCompraModel : AuditModel
    {
        public int IdCompra { get; set; }
        public int IdMaterial { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
    }
}
