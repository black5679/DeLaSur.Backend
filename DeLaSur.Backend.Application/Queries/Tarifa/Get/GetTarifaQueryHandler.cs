using Dapper;
using DeLaSur.Backend.Domain.UoW;
using MediatR;
using System.Data;

namespace DeLaSur.Backend.Application.Queries.Tarifa.Get
{
    public class GetTarifaQueryHandler : IRequestHandler<GetTarifaQuery, IEnumerable<GetTarifaResponse>>
    {
        private readonly IDb db;
        public GetTarifaQueryHandler(IDb db)
        {
            this.db = db;
        }
        public async Task<IEnumerable<GetTarifaResponse>> Handle(GetTarifaQuery request, CancellationToken cancellationToken)
        {
            var tarifas = await db.Connection.QueryAsync<GetTarifaResponse>("Material.GetTarifa", null, null, null, CommandType.StoredProcedure);
            return tarifas;
        }
    }
}
