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

namespace DeLaSur.Backend.Application.Queries.Material.Get
{
    public class GetMaterialQueryHandler : IRequestHandler<GetMaterialQuery, IEnumerable<GetMaterialResponse>>
    {
        private readonly IDb db;
        public GetMaterialQueryHandler(IDb db)
        {
            this.db = db;
        }
        public async Task<IEnumerable<GetMaterialResponse>> Handle(GetMaterialQuery request, CancellationToken cancellationToken)
        {
            var materiales = await db.Connection.QueryAsync<GetMaterialResponse>("Material.GetMaterial", null, null, null, CommandType.StoredProcedure);
            return materiales;
        }
    }
}
