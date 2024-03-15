using DeLaSur.Backend.Application.Base;
using MediatR;

namespace DeLaSur.Backend.Application.Queries.TipoMovimiento.Get
{
    public class GetTipoMovimientoQuery : IRequest<IEnumerable<BaseResponse>>
    {
    }
}
