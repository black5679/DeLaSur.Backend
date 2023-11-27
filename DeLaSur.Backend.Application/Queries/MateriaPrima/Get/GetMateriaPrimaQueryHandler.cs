using Dapper;
using DeLaSur.Backend.Domain.Models;
using DeLaSur.Backend.Domain.Repositories;
using DeLaSur.Backend.Domain.UoW;
using DeLaSur.Backend.Infrastructure.Repositories;
using Mapster;
using MediatR;
using PuppeteerSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

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
            var materiasPrimas = await db.Connection.QueryAsync<GetMateriaPrimaResponse>("MateriaPrima.GetMateriaPrima", null, null, null, CommandType.StoredProcedure);
            return materiasPrimas;
        }
    }
}
