using Dapper;
using DeLaSur.Backend.Domain.Models;
using DeLaSur.Backend.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeLaSur.Backend.Infrastructure.Repositories
{
    public class TipoMovimientoRepository : ITipoMovimientoRepository
    {
        private readonly IDbConnection connection;
        private readonly IDbTransaction? transaction;
        public TipoMovimientoRepository(IDbConnection connection, IDbTransaction? transaction)
        {
            this.connection = connection;
            this.transaction = transaction;
        }
        public async Task<IEnumerable<TipoMovimientoModel>> Get()
        {
            var tipos = await connection.QueryAsync<TipoMovimientoModel>("Movimiento.GetTipoMovimiento", null, transaction, null, CommandType.StoredProcedure);
            return tipos;
        }
    }
}
