using DeLaSur.Backend.Application.Base;
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

namespace DeLaSur.Backend.Application.Queries.TipoMovimiento.Get
{
    public class GetTipoMovimientoQueryHandler : IRequestHandler<GetTipoMovimientoQuery, IEnumerable<BaseResponse>>
    {
        private readonly ITipoMovimientoRepository tipoMovimientoRepository;
        public GetTipoMovimientoQueryHandler(IDb db, ITipoMovimientoRepository tipoMovimientoRepository)
        {
            this.tipoMovimientoRepository = tipoMovimientoRepository;
        }
        public async Task<IEnumerable<BaseResponse>> Handle(GetTipoMovimientoQuery request, CancellationToken cancellationToken)
        {
            var tipos = await tipoMovimientoRepository.Get();
            var response = tipos.Adapt<IEnumerable<BaseResponse>>();
            return response;
        }
    }
}
