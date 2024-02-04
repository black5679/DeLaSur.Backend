using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLaSur.Backend.Application.Queries.CategoriaMateriaPrima.GetByIdTipoMateriaPrima
{
    public class GetByIdTipoMateriaPrimaCategoriaMateriaPrimaQuery : IRequest<IEnumerable<GetByIdTipoMateriaPrimaCategoriaMateriaPrimaResponse>>
    {
        public int IdTipoMateriaPrima { get; set; }
    }
}
