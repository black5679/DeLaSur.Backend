using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLaSur.Backend.Application.Commands.MateriaPrimaBoveda.Insert
{
    public class InsertMateriaPrimaBovedaRequest
    {
        public required List<MateriaPrimaBoveda> MateriasPrimas { get; set; }
        public required int IdBoveda { get; set; }
        public required int UsuarioCreacion { get; set; }
    }
    public class MateriaPrimaBoveda
    {
        public int IdMateriaPrima { get; set; }
        public int Stock { get; set; }
        public int StockMinimo { get; set; }
        public int StockVenta { get; set; }
    }
}
