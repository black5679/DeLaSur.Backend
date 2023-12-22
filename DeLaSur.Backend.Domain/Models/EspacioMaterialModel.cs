namespace DeLaSur.Backend.Domain.Models
{
    public class EspacioMaterialModel
    {
        public required int IdEspacio { get; set; }
        public required int IdMaterial { get; set; }
        public required string ColorHex { get; set; }
    }
}
