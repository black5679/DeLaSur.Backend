using DeLaSur.Backend.Domain.Base;

namespace DeLaSur.Backend.Domain.Models
{
    public class EntradaModel : AuditModel
    {
        public int Id { get; set; }
        public int IdProveedor { get; set; }
        public List<DetalleEntradaModel> Detalles { get; set; }
        public EntradaModel()
        {
            Detalles = new List<DetalleEntradaModel>();
        }
    }
}
