using DeLaSur.Backend.Domain.Base;

namespace DeLaSur.Backend.Domain.Models
{
    public class CompraModel : AuditModel
    {
        public required int Id { get; set; }
        public required int IdProveedor { get; set; }
    }
}
