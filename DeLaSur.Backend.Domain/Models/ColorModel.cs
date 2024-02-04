using DeLaSur.Backend.Domain.Base;

namespace DeLaSur.Backend.Domain.Models
{
    public class ColorModel : AuditModel
    {
        public int IdColor { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string CodigoHex { get; set; } = string.Empty;
    }
}
