using MediatR;

namespace DeLaSur.Backend.Application.Queries.Tarifa.Get
{
    public class GetTarifaQuery : IRequest<IEnumerable<GetTarifaResponse>>
    {
    }
}
