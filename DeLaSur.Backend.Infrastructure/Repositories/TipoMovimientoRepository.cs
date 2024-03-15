using Dapper;
using DeLaSur.Backend.Domain.Models;
using DeLaSur.Backend.Domain.Repositories;
using DeLaSur.Backend.Domain.UoW;
using DeLaSur.Backend.Infrastructure.Common;
using System.Data;

namespace DeLaSur.Backend.Infrastructure.Repositories
{
    public class TipoMovimientoRepository : Repository, ITipoMovimientoRepository
    {
        public TipoMovimientoRepository(IDbSession db) : base(db) { }
        public async Task<IEnumerable<TipoMovimientoModel>> Get()
        {
            var tipos = await Connection.QueryAsync<TipoMovimientoModel>("Movimiento.GetTipoMovimiento", null, Transaction, null, CommandType.StoredProcedure);
            return tipos;
        }
    }
}
