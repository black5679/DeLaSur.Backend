using Dapper;
using DeLaSur.Backend.Application.Queries.Movimiento.GetById;
using DeLaSur.Backend.Domain.Exceptions;
using DeLaSur.Backend.Domain.Models;
using DeLaSur.Backend.Domain.Repositories;
using DeLaSur.Backend.Domain.UoW;
using DeLaSur.Backend.Infrastructure.Repositories;
using Mapster;
using MediatR;
using PuppeteerSharp;
using System.Data;
using System.Transactions;

namespace DeLaSur.Backend.Application.Queries.Movimiento.Get
{
    public class GetMovimientoQueryHandler : IRequestHandler<GetMovimientoQuery, IEnumerable<GetMovimientoResponse>>
    {
        private readonly IDb db;
        public GetMovimientoQueryHandler(IDb db)
        {
            this.db = db;
        }
        public async Task<IEnumerable<GetMovimientoResponse>> Handle(GetMovimientoQuery request, CancellationToken cancellationToken)
        {
            var response = await db.Connection.QueryAsync<GetMovimientoResponse>("Movimiento.GetMovimiento", null, null, null, CommandType.StoredProcedure);
            return response;
        }
    }
}
