using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLaSur.Backend.Application.Queries.TarifaMateriaPrima.Get
{
    public class GetTarifaMateriaPrimaQuery : IRequest<IEnumerable<GetTarifaMateriaPrimaResponse>>
    {
    }
}
