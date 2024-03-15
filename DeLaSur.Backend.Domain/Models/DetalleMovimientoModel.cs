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
        public required int IdMaterial { get; set; }
        public required int IdTipoMaterial { get; set; }
        public required int IdInventario { get; set; }
        public int StockInicial { get; set; }
        public int StockFinal { get; set; }
        public required int Cantidad { get; set; }
    }
}
