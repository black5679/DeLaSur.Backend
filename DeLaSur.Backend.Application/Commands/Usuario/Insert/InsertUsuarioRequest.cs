using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLaSur.Backend.Application.Commands.Usuario.Insert
{
    public class InsertUsuarioRequest
    {
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string Celular { get; set; } = null!;
        public string Documento { get; set; } = null!;
        public int IdTipoDocumento { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
