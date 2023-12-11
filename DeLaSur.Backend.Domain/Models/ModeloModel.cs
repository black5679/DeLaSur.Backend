using DeLaSur.Backend.Domain.Base;

namespace DeLaSur.Backend.Domain.Models
{
    public class ModeloModel : AuditModel
    {
        public int Id { get; set; }
        public required int IdMaterial { get; set; }
        public required string Extension { get; set; }
    }
}
