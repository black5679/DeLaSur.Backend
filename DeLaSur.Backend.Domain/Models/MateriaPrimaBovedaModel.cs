using DeLaSur.Backend.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLaSur.Backend.Domain.Models
{
    public class MateriaPrimaBovedaModel : AuditModel
    {
        public int IdBoveda { get; set; }
        public int IdMateriaPrima { get; set; }
        public int Stock { get; set; }
        public int StockMinimo { get; set; }
        public int StockVenta { get; set; }
    }
}
