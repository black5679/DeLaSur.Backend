using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLaSur.Backend.Domain.Models
{
    public class TipoMovimientoModel
    {
        public required int Id { get; set; }
        public required string Nombre { get; set; }
        public bool Status { get; set; }
    }
}
