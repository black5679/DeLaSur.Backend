namespace DeLaSur.Backend.Domain.Models
{
    public class MateriaPrimaModel
    {
        public int Id { get; set; }
        public int IdMaterial { get; set; }
        public int IdSubCategoriaMateriaPrima { get; set; }
        public MaterialModel Material { get; set; }
        public MateriaPrimaModel()
        {
            Material = new MaterialModel();
        }
    }
}
