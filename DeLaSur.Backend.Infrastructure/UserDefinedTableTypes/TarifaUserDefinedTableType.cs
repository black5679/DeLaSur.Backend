namespace DeLaSur.Backend.Infrastructure.UserDefinedTableTypes
{
    internal class TarifaUserDefinedTableType
    {
        public int IdMaterial { get; set; }
        public int IdPureza { get; set; }
        public decimal Precio { get; set; }
        public decimal Peso { get; set; }
        public decimal Largo { get; set; }
        public decimal Ancho { get; set; }
        public decimal Alto { get; set; }
    }
}
