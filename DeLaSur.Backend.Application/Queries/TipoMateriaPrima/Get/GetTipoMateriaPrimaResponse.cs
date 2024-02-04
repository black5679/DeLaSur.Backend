using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLaSur.Backend.Application.Queries.TipoMateriaPrima.Get
{
    public class GetTipoMateriaPrimaResponse
    {
        public int IdTipoMateriaPrima { get; set; }
        public string? Nombre { get; set; }
    }
}
