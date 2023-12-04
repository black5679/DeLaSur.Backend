using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLaSur.Backend.Infrastructure.UserDefinedTableTypes
{
    internal class MaterialBovedaUserDefinedTableType
    {
        public int IdBoveda { get; set; }
        public int IdMaterial { get; set; }
        public int Stock { get; set; }
        public int StockMinimo { get; set; }
        public int StockVenta { get; set; }
    }
}
