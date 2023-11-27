using DeLaSur.Backend.Domain.Base;

namespace DeLaSur.Backend.Domain.Models
{
    public class MateriaPrimaModel : AuditModel
    {
        public required int Id { get; set; }
        public required int IdCategoriaMateriaPrima { get; set; }
        public required string Nombre { get; set; }
    }
}
