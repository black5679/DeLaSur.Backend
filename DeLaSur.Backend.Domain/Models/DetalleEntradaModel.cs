using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLaSur.Backend.Domain.Models
{
    public class DetalleEntradaModel
    {
        public int IdEntrada { get; set; }
        public int IdMaterial { get; set; }
        public int Cantidad { get; set; }
    }
}
