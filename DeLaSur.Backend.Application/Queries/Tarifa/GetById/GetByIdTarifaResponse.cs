namespace DeLaSur.Backend.Application.Queries.Tarifa.GetById
{
    public class GetByIdTarifaResponse
    {
        public int IdTarifa { get; set; }
        public int IdMateriaPrima { get; set; }
        public int IdPureza { get; set; }
        public int IdColor { get; set; }
        public int IdForma { get; set; }
        public int IdFuente { get; set; }
        public decimal Precio { get; set; }
        public decimal Peso { get; set; }
        public decimal Largo { get; set; }
        public decimal Ancho { get; set; }
        public decimal Alto { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}
