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

namespace DeLaSur.Backend.Application.Queries.TipoBoveda.Get
{
    public class GetTipoBovedaQueryHandler : IRequestHandler<GetTipoBovedaQuery, IEnumerable<BaseResponse>>
    {
        private readonly ITipoBovedaRepository tipoBovedaRepository;
        public GetTipoBovedaQueryHandler(IDb db, ITipoBovedaRepository tipoBovedaRepository)
        {
            this.tipoBovedaRepository = tipoBovedaRepository;
        }
        public async Task<IEnumerable<BaseResponse>> Handle(GetTipoBovedaQuery request, CancellationToken cancellationToken)
        {
            var tipos = await tipoBovedaRepository.Get();
            var response = tipos.Adapt<IEnumerable<BaseResponse>>();
            return response;
        }
    }
}
