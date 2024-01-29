using DeLaSur.Backend.Domain.UoW;
using MediatR;
using Dapper;
using System.Data;

namespace DeLaSur.Backend.Application.Queries.MateriaPrima.Get
{
    public class GetMateriaPrimaQueryHandler : IRequestHandler<GetMateriaPrimaQuery, IEnumerable<GetMateriaPrimaResponse>>
    {
        private readonly IDb db;
        public GetMateriaPrimaQueryHandler(IDb db)
        {
            this.db = db;
        }
        public async Task<IEnumerable<GetMateriaPrimaResponse>> Handle(GetMateriaPrimaQuery request, CancellationToken cancellationToken)
        {
            var response = await db.Connection.QueryAsync<GetMateriaPrimaResponse>("Material.GetMateriaPrima", null, null, null, CommandType.StoredProcedure);
            return response;
        }
    }
}
