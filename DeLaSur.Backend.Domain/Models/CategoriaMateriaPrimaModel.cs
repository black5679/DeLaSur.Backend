using DeLaSur.Backend.Domain.Base;

namespace DeLaSur.Backend.Domain.Models
{
    public class CategoriaMateriaPrimaModel : AuditModel
    {
        public int IdCategoriaMateriaPrima { get; set; }
        public int IdTipoMateriaPrima { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }
}
