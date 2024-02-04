using DeLaSur.Backend.Domain.Base;

namespace DeLaSur.Backend.Domain.Models
{
    public class SubCategoriaMateriaPrimaModel : AuditModel
    {
        public int IdSubCategoriaMateriaPrima { get; set; }
        public int IdCategoriaMateriaPrima { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }
}
