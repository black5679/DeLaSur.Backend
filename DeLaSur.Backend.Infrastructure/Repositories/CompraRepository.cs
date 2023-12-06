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
            var id = await connection.ExecuteScalarAsync<int>("Compra.InsertCompra", new { compra.IdProveedor, compra.UsuarioCreacion }, transaction, null, CommandType.StoredProcedure);
            return id;
        }
        public async Task<int> Update(CompraModel compra)
        {
            var id = await connection.ExecuteScalarAsync<int>("Compra.UpdateCompra", new { compra.Id, compra.IdProveedor, compra.UsuarioModificacion }, transaction, null, CommandType.StoredProcedure);
            return id;
        }
    }
}
