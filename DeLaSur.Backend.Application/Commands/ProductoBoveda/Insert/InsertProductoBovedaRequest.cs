using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLaSur.Backend.Application.Commands.ProductoBoveda.Insert
{
    public class InsertProductoBovedaRequest
    {
        public required List<ProductoBoveda> Productos { get; set; }
        public required int IdBoveda { get; set; }
        public required int UsuarioCreacion { get; set; }
    }
    public class ProductoBoveda
    {
        public int IdProducto { get; set; }
        public int Stock { get; set; }
        public int StockMinimo { get; set; }
        public int StockVenta { get; set; }
    }
}
