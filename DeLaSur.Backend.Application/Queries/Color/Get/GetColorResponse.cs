using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLaSur.Backend.Application.Queries.Color.Get
{
    public class GetColorResponse
    {
        public int IdColor { get; set; }
        public string? Nombre {  get; set; }
        public string? CodigoHex { get; set; }
    }
}
