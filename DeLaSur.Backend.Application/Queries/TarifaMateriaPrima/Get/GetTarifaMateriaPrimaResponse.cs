namespace DeLaSur.Backend.Application.Queries.TarifaMateriaPrima.Get
{
    public class GetTarifaMateriaPrimaResponse
    {
        public int Id { get; set; }
        public string? MateriaPrima { get; set; }
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
        public DateTime FechaModificacion { get; set; }
    }
}
