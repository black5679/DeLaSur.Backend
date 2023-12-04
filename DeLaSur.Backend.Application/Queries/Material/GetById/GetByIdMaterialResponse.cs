using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLaSur.Backend.Application.Queries.Material.GetById
{
    public class GetByIdMaterialResponse
    {
        public int Id { get; set; }
        public int IdCategoriaMaterial { get; set; }
        public string? Nombre { get; set; }
    }
}
