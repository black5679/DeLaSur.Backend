using DeLaSur.Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLaSur.Backend.Application.Queries.Movimiento.GetById
{
    public class GetByIdMovimientoResponse
    {
        public int Id { get; set; }
        public required int IdTipoMovimiento { get; set; }
        public required int IdInventario { get; set; }
        public required int Inventario { get; set; }
        public DateTime FechaCreacion { get; set; }
        public required int UsuarioCreacion { get; set; }
        public IEnumerable<DetalleMovimiento> DetallesMovimiento { get; set; } = Enumerable.Empty<DetalleMovimiento>();
    }
    public class DetalleMovimiento
    {
        public required int IdMercaderia { get; set; }
        public required int IdTipoMercaderia { get; set; }
        public int StockInicial { get; set; }
        public int StockFinal { get; set; }
        public required int Cantidad { get; set; }
    }
}
