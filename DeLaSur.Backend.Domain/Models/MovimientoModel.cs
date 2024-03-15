using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLaSur.Backend.Domain.Models
{
    public class MovimientoModel
    {
        public int Id { get; set; }
        public required int IdTipoMovimiento { get; set; }
        public DateTime FechaCreacion { get; set; }
        public required int UsuarioCreacion { get; set; }
        public List<DetalleMovimientoModel> DetallesMovimiento { get; set; }
        public MovimientoModel()
        {
            DetallesMovimiento = new List<DetalleMovimientoModel>();
        }
    }
}
