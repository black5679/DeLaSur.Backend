using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLaSur.Backend.Domain.Models
{
    public class ProductoModel
    {
        public int Id { get; set; }
        public int IdMaterial { get; set; }
        public int IdCategoriaProducto { get; set; }
    }
}
