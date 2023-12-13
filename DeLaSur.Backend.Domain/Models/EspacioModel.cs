using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLaSur.Backend.Domain.Models
{
    public class EspacioModel
    {
        public int Id { get; set; }
        public required int IdMaterial { get; set; }
        public int? IdForma { get; set; }
    }
}
