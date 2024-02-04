using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLaSur.Backend.Domain.Models
{
    public class ProductoModel : MaterialModel
    {
        public int IdProducto { get; set; }
        public new int IdMaterial { get; set; }
        public int IdCategoriaProducto { get; set; }
    }
}
