using DeLaSur.Backend.Application.Base;
using DeLaSur.Backend.Domain.Repositories;
using DeLaSur.Backend.Domain.UoW;
using DeLaSur.Backend.Infrastructure.Repositories;
using Mapster;
using MediatR;

namespace DeLaSur.Backend.Application.Queries.Inventario.Get
{
    public class GetInventarioQueryHandler : IRequestHandler<GetInventarioQuery, IEnumerable<BaseResponse>>
    {
        private readonly IInventarioRepository inventarioRepository;
        public GetInventarioQueryHandler(IDb db)
        {
            inventarioRepository = new InventarioRepository(db.Connection, null);
        }
        public async Task<IEnumerable<BaseResponse>> Handle(GetInventarioQuery request, CancellationToken cancellationToken)
        {
            var tipos = await inventarioRepository.Get();
            var response = tipos.Adapt<IEnumerable<BaseResponse>>();
            return response;
        }
    }
}
