using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLaSur.Backend.Application.Commands.Entrada.Insert
{
    public class InsertEntradaRequest
    {
        public required int IdProveedor { get; set; }
        public required int UsuarioCreacion { get; set; }
        public required List<DetalleEntrada> Detalles { get; set; }
    }
    public class DetalleEntrada
    {
        public required int IdMaterial { get; set; }
        public required int IdBoveda { get; set; }
        public required int Cantidad { get; set; }
    }
}
