namespace DeLaSur.Backend.Infrastructure.UserDefinedTableTypes
{
    internal class TarifaUserDefinedTableType
    {
        public int IdMaterial { get; set; }
        public int IdPureza { get; set; }
        public int? IdForma { get; set; }
        public decimal Precio { get; set; }
        public decimal Peso { get; set; }
    }
}
