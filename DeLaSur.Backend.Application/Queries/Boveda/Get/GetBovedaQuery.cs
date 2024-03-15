using MediatR;

namespace DeLaSur.Backend.Application.Queries.Boveda.Get
{
    public class GetBovedaQuery : IRequest<IEnumerable<GetBovedaResponse>>
    {
    }
}
