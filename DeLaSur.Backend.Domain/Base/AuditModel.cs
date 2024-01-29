namespace DeLaSur.Backend.Domain.Base
{
    public class AuditModel
    {
        public DateTime FechaCreacion { get; set; }
        public int UsuarioCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int UsuarioModificacion { get; set; }
        public bool Status { get; set; }
    }
}
