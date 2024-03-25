using DeLaSur.Backend.Domain.Base;

namespace DeLaSur.Backend.Domain.Models
{
    public class UsuarioModel : AuditModel
    {
        public int IdUsuario { get; set; }
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string Celular { get; set; } = null!;
        public string Documento { get; set; } = null!;
        public int IdTipoDocumento { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Password { get; set; } = null!;
    }
}
