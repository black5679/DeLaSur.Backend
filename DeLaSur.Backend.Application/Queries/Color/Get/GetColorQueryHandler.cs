using Dapper;
using DeLaSur.Backend.Domain.UoW;
using MediatR;
using System.Data;

namespace DeLaSur.Backend.Application.Queries.Color.Get
{
    public class GetColorQueryHandler : IRequestHandler<GetColorQuery, IEnumerable<GetColorResponse>>
    {
        private readonly IDb db;
        public GetColorQueryHandler(IDb db)
        {
            this.db = db;
        }
        public async Task<IEnumerable<GetColorResponse>> Handle(GetColorQuery request, CancellationToken cancellationToken)
        {
            var response = await db.Connection.QueryAsync<GetColorResponse>("Material.GetColor", null, null, null, CommandType.StoredProcedure);
            return response;
        }
    }
}
