namespace DeLaSur.Backend.Application.Queries.Tarifa.Get
{
    public class GetTarifaResponse
    {
        public int IdTarifa { get; set; }
        public string? Material { get; set; }
        public string? Pureza { get; set; }
        public string? Forma { get; set; }
        public string? Fuente { get; set; }
        public decimal Precio { get; set; }
        public decimal Peso { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
