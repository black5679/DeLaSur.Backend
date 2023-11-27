using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLaSur.Backend.Domain.Base
{
    public class AuditModel
    {
        public DateTime FechaCreacion { get; set; }
        public required int UsuarioCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int UsuarioModificacion { get; set; }
        public bool Status { get; set; }
    }
}
