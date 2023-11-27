using Dapper;
using DeLaSur.Backend.Domain.Models;
using DeLaSur.Backend.Domain.Repositories;
using System.Data;

namespace DeLaSur.Backend.Infrastructure.Repositories
{
    public class InventarioRepository : IInventarioRepository
    {
        private readonly IDbConnection connection;
        private readonly IDbTransaction? transaction;
        public InventarioRepository(IDbConnection connection, IDbTransaction? transaction)
        {
            this.connection = connection;
            this.transaction = transaction;
        }
        public async Task<IEnumerable<InventarioModel>> Get()
        {
            var inventarios = await connection.QueryAsync<InventarioModel>("Movimiento.GetInventario", null, transaction, null, CommandType.StoredProcedure);
            return inventarios;
        }
    }
}
