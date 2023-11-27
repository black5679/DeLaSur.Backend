using DeLaSur.Backend.Application.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLaSur.Backend.Application.Queries.TipoMovimiento.Get
{
    public class GetTipoMovimientoQuery : IRequest<IEnumerable<BaseResponse>>
    {
    }
}
