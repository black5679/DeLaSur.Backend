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

namespace DeLaSur.Backend.Application.Queries.MateriaPrima.GetById
{
    public class GetByIdMateriaPrimaQueryHandler : IRequestHandler<GetByIdMateriaPrimaQuery, GetByIdMateriaPrimaResponse>
    {
        private readonly IMateriaPrimaRepository materiaPrimaRepository;
        public GetByIdMateriaPrimaQueryHandler(IDb db)
        {
            materiaPrimaRepository = new MateriaPrimaRepository(db.Connection, null);
        }
        public async Task<GetByIdMateriaPrimaResponse> Handle(GetByIdMateriaPrimaQuery request, CancellationToken cancellationToken)
        {
            var materiaPrima = await materiaPrimaRepository.GetById(request.Id);
            var response = materiaPrima.Adapt<GetByIdMateriaPrimaResponse>();
            return response;
        }
    }
}
