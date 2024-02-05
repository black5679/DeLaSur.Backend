using DeLaSur.Backend.Domain.Exceptions;
using DeLaSur.Backend.Domain.Repositories;
using DeLaSur.Backend.Domain.UoW;
using DeLaSur.Backend.Infrastructure.Repositories;
using Mapster;
using MediatR;

namespace DeLaSur.Backend.Application.Queries.Tarifa.GetById
{
    public class GetByIdTarifaQueryHandler : IRequestHandler<GetByIdTarifaQuery, GetByIdTarifaResponse>
    {
        private readonly ITarifaRepository tarifaRepository;
        public GetByIdTarifaQueryHandler(ITarifaRepository tarifaRepository)
        {
            this.tarifaRepository = tarifaRepository;
        }
        public async Task<GetByIdTarifaResponse> Handle(GetByIdTarifaQuery request, CancellationToken cancellationToken)
        {
            var tarifa = await tarifaRepository.GetById(request.Id) ?? throw new NotFoundException("No se encontró el tarifario");
            var response = tarifa.Adapt<GetByIdTarifaResponse>();
            return response;
        }
    }
}
