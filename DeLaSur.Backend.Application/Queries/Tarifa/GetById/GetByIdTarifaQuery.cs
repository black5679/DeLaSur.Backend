using MediatR;

namespace DeLaSur.Backend.Application.Queries.Tarifa.GetById
{
    public class GetByIdTarifaQuery : IRequest<GetByIdTarifaResponse>
    {
        public int Id { get; set; }
    }
}
