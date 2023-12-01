using DeLaSur.Backend.Application.Queries.Movimiento.GetById;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLaSur.Backend.Application.Queries.Movimiento.Get
{
    public class GetMovimientoQuery : IRequest<IEnumerable<GetMovimientoResponse>>
    {
    }
}
