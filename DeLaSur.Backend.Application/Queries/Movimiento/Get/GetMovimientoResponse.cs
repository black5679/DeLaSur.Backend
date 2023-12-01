using DeLaSur.Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLaSur.Backend.Application.Queries.Movimiento.Get
{
    public class GetMovimientoResponse
    {
        public int Id { get; set; }
        public string? TipoMovimiento { get; set; }
        public string? Inventario { get; set; }
        public string? TipoInventario { get; set; }
        public DateTime FechaCreacion { get; set; }
        public required int UsuarioCreacion { get; set; }
    }
}
