using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLaSur.Backend.Application.Queries.MateriaPrima.GetById
{
    public class GetByIdMateriaPrimaResponse
    {
        public int Id { get; set; }
        public int IdCategoriaMateriaPrima { get; set; }
        public string? Nombre { get; set; }
    }
}
