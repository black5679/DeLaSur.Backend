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

namespace DeLaSur.Backend.Application.Queries.TarifaMateriaPrima.Get
{
    public class GetTarifaMateriaPrimaQueryHandler : IRequestHandler<GetTarifaMateriaPrimaQuery, IEnumerable<GetTarifaMateriaPrimaResponse>>
    {
        private readonly IDb db;
        public GetTarifaMateriaPrimaQueryHandler(IDb db)
        {
            this.db = db;
        }
        public async Task<IEnumerable<GetTarifaMateriaPrimaResponse>> Handle(GetTarifaMateriaPrimaQuery request, CancellationToken cancellationToken)
        {
            var tarifas = await db.Connection.QueryAsync<GetTarifaMateriaPrimaResponse>("MateriaPrima.GetTarifaMateriaPrima", null, null, null, CommandType.StoredProcedure);
            return tarifas;
        }
    }
}
