using DeLaSur.Backend.Domain.UoW;
using MediatR;
using Dapper;
using System.Data;

namespace DeLaSur.Backend.Application.Queries.TipoMateriaPrima.Get
{
    public class GetTipoMateriaPrimaQueryHandler : IRequestHandler<GetTipoMateriaPrimaQuery, IEnumerable<GetTipoMateriaPrimaResponse>>
    {
        private readonly IDb db;
        public GetTipoMateriaPrimaQueryHandler(IDb db)
        {
            this.db = db;
        }
        public async Task<IEnumerable<GetTipoMateriaPrimaResponse>> Handle(GetTipoMateriaPrimaQuery request, CancellationToken cancellationToken)
        {
            var response = await db.Connection.QueryAsync<GetTipoMateriaPrimaResponse>("Material.GetTipoMateriaPrima", null, null, null, CommandType.StoredProcedure);
            return response;
        }
    }
}
