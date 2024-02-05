namespace DeLaSur.Backend.Application.Queries.Tarifa.Get
{
    public class GetTarifaResponse
    {
        public int IdTarifa { get; set; }
        public string? Material { get; set; }
        public string? Pureza { get; set; }
        public string? Color { get; set; }
        public string? Forma { get; set; }
        public string? Fuente { get; set; }
        public decimal Precio { get; set; }
        public decimal Peso { get; set; }
        public decimal Largo { get; set; }
        public decimal Ancho { get; set; }
        public decimal Alto { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
