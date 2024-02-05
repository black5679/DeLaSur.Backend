using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLaSur.Backend.Application.Commands.Color.Insert
{
    public class InsertColorRequest
    {
        public required string Nombre { get; set; }
        public required string ColorHex { get; set; }
    }
}
