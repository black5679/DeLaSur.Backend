using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLaSur.Backend.Infrastructure.UserDefinedTableTypes
{
    internal class TarifaMateriaPrimaUserDefinedTableType
    {
        public int IdMateriaPrima { get; set; }
        public int IdPureza { get; set; }
        public decimal Precio { get; set; }
        public decimal Peso { get; set; }
        public decimal Largo { get; set; }
        public decimal Ancho { get; set; }
        public decimal Alto { get; set; }
    }
}
