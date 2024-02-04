namespace DeLaSur.Backend.Domain.Models
{
    public class MateriaPrimaModel : MaterialModel
    {
        public int IdMateriaPrima { get; set; }
        public new int IdMaterial { get; set; }
        public int IdCategoriaMateriaPrima { get; set; }
        public MateriaPrimaModel()
        {

        }
    }
}
