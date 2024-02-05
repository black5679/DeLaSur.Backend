using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLaSur.Backend.Infrastructure.UserDefinedTableTypes
{
    internal class DetalleEntradaUserDefinedTableType
    {
        public required int IdMaterial { get; set; }
        public required int IdBoveda { get; set; }
        public required int Cantidad { get; set; }
    }
}
