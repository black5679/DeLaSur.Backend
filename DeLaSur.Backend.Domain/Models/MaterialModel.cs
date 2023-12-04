using DeLaSur.Backend.Domain.Base;

namespace DeLaSur.Backend.Domain.Models
{
    public class MaterialModel : AuditModel
    {
        public required int Id { get; set; }
        public required int IdCategoriaMaterial { get; set; }
        public required string Nombre { get; set; }
        public string? Descripcion { get; set; }
    }
}
