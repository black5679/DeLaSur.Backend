using DeLaSur.Backend.Domain.Base;

namespace DeLaSur.Backend.Domain.Models
{
    public class BovedaModel : AuditModel
    {
        public int IdBoveda { get; set; }
        public int IdTipoBoveda { get; set; }
        public string Codigo { get; set; } = null!;
        public string? Descripcion { get; set; }
        public string Ubicacion { get; set; } = null!;
    }
}
