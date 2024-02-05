using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLaSur.Backend.Infrastructure.UserDefinedTableTypes
{
    internal class DetalleMovimientoUserDefinedTableType
    {
        public required int IdMaterial { get; set; }
        public required int IdTipoMaterial { get; set; }
        public required int IdInventario { get; set; }
        public required int Cantidad { get; set; }
    }
}
