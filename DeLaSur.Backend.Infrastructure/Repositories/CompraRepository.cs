using Dapper;
using DeLaSur.Backend.Domain.Models;
using DeLaSur.Backend.Domain.Repositories;
using System.Data;

namespace DeLaSur.Backend.Infrastructure.Repositories
{
    public class CompraRepository : ICompraRepository
    {
        private readonly IDbConnection connection;
        private readonly IDbTransaction? transaction;
        public CompraRepository(IDbConnection connection, IDbTransaction? transaction)
        {
            this.connection = connection;
            this.transaction = transaction;
        }
        public async Task<int> Insert(CompraModel compra)
        {
            var id = await connection.ExecuteScalarAsync<int>("Compra.InsertCompra", new { compra.IdProveedor }, transaction, null, CommandType.StoredProcedure);
            return id;
        }
    }
}
