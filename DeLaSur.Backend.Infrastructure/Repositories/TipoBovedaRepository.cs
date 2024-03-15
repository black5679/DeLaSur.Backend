using Dapper;
using DeLaSur.Backend.Domain.Models;
using DeLaSur.Backend.Domain.Repositories;
using DeLaSur.Backend.Domain.UoW;
using DeLaSur.Backend.Infrastructure.Common;
using System.Data;

namespace DeLaSur.Backend.Infrastructure.Repositories
{
    public class TipoBovedaRepository : Repository, ITipoBovedaRepository
    {
        public TipoBovedaRepository(IDbSession db) : base(db) { }
        public async Task<IEnumerable<TipoBovedaModel>> Get()
        {
            var tipos = await Connection.QueryAsync<TipoBovedaModel>("Boveda.GetTipoBoveda", null, Transaction, null, CommandType.StoredProcedure);
            return tipos;
        }
    }
}
