using DeLaSur.Backend.Domain.Repositories;
using DeLaSur.Backend.Domain.UoW;
using DeLaSur.Backend.Infrastructure.Repositories;
using Mapster;
using MediatR;

namespace DeLaSur.Backend.Application.Queries.Material.GetById
{
    public class GetByIdMaterialQueryHandler : IRequestHandler<GetByIdMaterialQuery, GetByIdMaterialResponse>
    {
        private readonly IMaterialRepository materialRepository;
        public GetByIdMaterialQueryHandler(IDb db)
        {
            materialRepository = new MaterialRepository(db.Connection, null);
        }
        public async Task<GetByIdMaterialResponse> Handle(GetByIdMaterialQuery request, CancellationToken cancellationToken)
        {
            var material = await materialRepository.GetById(request.Id);
            var response = material.Adapt<GetByIdMaterialResponse>();
            return response;
        }
    }
}
