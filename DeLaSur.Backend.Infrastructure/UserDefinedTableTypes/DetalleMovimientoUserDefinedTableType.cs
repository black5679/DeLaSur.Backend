using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLaSur.Backend.Infrastructure.UserDefinedTableTypes
{
    internal class DetalleMovimientoUserDefinedTableType
    {
        public required int IdMercaderia { get; set; }
        public required int IdTipoMercaderia { get; set; }
        public required int Cantidad { get; set; }
    }
}
