using DeLaSur.Backend.Domain.Repositories;
using DeLaSur.Backend.Domain.UoW;
using DeLaSur.Backend.Infrastructure.Repositories;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLaSur.Backend.Application.Queries.TarifaMateriaPrima.GetById
{
    public class GetByIdTarifaMateriaPrimaQueryHandler : IRequestHandler<GetByIdTarifaMateriaPrimaQuery, GetByIdTarifaMateriaPrimaResponse>
    {
        private readonly ITarifaMateriaPrimaRepository tarifaMateriaPrimaRepository;
        public GetByIdTarifaMateriaPrimaQueryHandler(IDb db)
        {
            tarifaMateriaPrimaRepository = new TarifaMateriaPrimaRepository(db.Connection, null);
        }
        public async Task<GetByIdTarifaMateriaPrimaResponse> Handle(GetByIdTarifaMateriaPrimaQuery request, CancellationToken cancellationToken)
        {
            var tarifa = await tarifaMateriaPrimaRepository.GetById(request.Id);
            var response = tarifa.Adapt<GetByIdTarifaMateriaPrimaResponse>();
            return response;
        }
    }
}
