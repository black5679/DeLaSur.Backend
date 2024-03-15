namespace DeLaSur.Backend.Application.Queries.Boveda.Get
{
    public class GetBovedaResponse
    {
        public int IdBoveda { get; set; }
        public int IdTipoBoveda { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        public string? Ubicacion { get; set; }
    }
}
