using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLaSur.Backend.Domain.Models
{
    public class DetalleMovimientoModel
    {
        public int IdMovimiento { get; set; }
        public required int IdMercaderia { get; set; }
        public required int IdTipoMercaderia { get; set; }
        public int StockInicial { get; set; }
        public int StockFinal { get; set; }
        public required int Cantidad { get; set; }
    }
}
