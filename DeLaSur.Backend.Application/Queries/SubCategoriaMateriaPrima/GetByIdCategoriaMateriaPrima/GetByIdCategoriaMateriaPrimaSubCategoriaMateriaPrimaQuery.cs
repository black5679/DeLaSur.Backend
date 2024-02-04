using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLaSur.Backend.Application.Queries.SubCategoriaMateriaPrima.GetByIdCategoriaMateriaPrima
{
    public class GetByIdCategoriaMateriaPrimaSubCategoriaMateriaPrimaQuery : IRequest<IEnumerable<GetByIdCategoriaMateriaPrimaSubCategoriaMateriaPrimaResponse>>
    {
        public int IdCategoriaMateriaPrima { get; set; }
    }
}
