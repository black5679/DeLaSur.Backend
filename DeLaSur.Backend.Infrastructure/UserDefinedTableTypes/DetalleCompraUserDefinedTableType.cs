using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLaSur.Backend.Infrastructure.UserDefinedTableTypes
{
    internal class DetalleCompraUserDefinedTableType
    {
        public required int IdMaterial { get; set; }
        public required int Cantidad { get; set; }
        public required decimal Precio { get; set; }
    }
}
