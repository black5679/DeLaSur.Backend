using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLaSur.Backend.Application.Queries.MateriaPrima.Get
{
    public class GetMateriaPrimaQuery : IRequest<IEnumerable<GetMateriaPrimaResponse>>
    {
    }
}
