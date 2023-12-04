using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLaSur.Backend.Application.Queries.Tarifa.Get
{
    public class GetTarifaQuery : IRequest<IEnumerable<GetTarifaResponse>>
    {
    }
}
