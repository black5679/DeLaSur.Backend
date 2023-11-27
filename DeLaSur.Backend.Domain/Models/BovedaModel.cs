using DeLaSur.Backend.Domain.Base;

namespace DeLaSur.Backend.Domain.Models
{
    public class BovedaModel : AuditModel
    {
        public required int Id { get; set; }
        public required int IdTipoBoveda { get; set; }
        public required string Codigo { get; set; }
        public required string? Descripcion { get; set; }
        public required string Ubicacion { get; set; }
    }
}
