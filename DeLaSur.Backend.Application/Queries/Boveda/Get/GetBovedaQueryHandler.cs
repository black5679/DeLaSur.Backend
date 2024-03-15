using Dapper;
using DeLaSur.Backend.Domain.UoW;
using MediatR;
using System.Data;

namespace DeLaSur.Backend.Application.Queries.Boveda.Get
{
    public class GetBovedaQueryHandler : IRequestHandler<GetBovedaQuery, IEnumerable<GetBovedaResponse>>
    {
        private readonly IDb db;
        public GetBovedaQueryHandler(IDb db)
        {
            this.db = db;
        }
        public async Task<IEnumerable<GetBovedaResponse>> Handle(GetBovedaQuery request, CancellationToken cancellationToken)
        {
            var response = await db.Connection.QueryAsync<GetBovedaResponse>("Boveda.GetBoveda", null, null, null, CommandType.StoredProcedure);
            return response;
        }
    }
}
