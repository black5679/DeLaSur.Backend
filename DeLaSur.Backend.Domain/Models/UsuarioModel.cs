using DeLaSur.Backend.Domain.Base;

namespace DeLaSur.Backend.Domain.Models
{
    public class UsuarioModel : AuditModel
    {
        public int Id { get; set; }
        public required string Nombres { get; set; }
        public required string Apellidos { get; set; }
        public required string Correo { get; set; }
        public required string Celular { get; set; }
        public required int TipoDocumento { get; set; }
        public required string Documento { get; set; }
        public required DateTime FechaNacimiento { get; set; }
        public required string Password { get; set; }
    }
}
