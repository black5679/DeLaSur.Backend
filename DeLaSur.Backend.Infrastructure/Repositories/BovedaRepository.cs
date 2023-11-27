using Dapper;
using DeLaSur.Backend.Domain.Models;
using DeLaSur.Backend.Domain.Repositories;
using System.Data;

namespace DeLaSur.Backend.Infrastructure.Repositories
{
    public class BovedaRepository : IBovedaRepository
    {
        private readonly IDbConnection connection;
        private readonly IDbTransaction? transaction;
        public BovedaRepository(IDbConnection connection, IDbTransaction? transaction)
        {
            this.connection = connection;
            this.transaction = transaction;
        }
        public async Task<int> Insert(BovedaModel boveda)
        {
            var id = await connection.ExecuteScalarAsync<int>("Boveda.InsertBoveda", new { boveda.IdTipoBoveda, boveda.Codigo, boveda.Descripcion, boveda.Ubicacion }, transaction, null, CommandType.StoredProcedure);
            return id;
        }
    }
}
