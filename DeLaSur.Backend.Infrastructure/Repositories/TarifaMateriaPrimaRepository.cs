using Dapper;
using DeLaSur.Backend.Domain.Models;
using DeLaSur.Backend.Domain.Repositories;
using System.Data;

namespace DeLaSur.Backend.Infrastructure.Repositories
{
    public class TarifaMateriaPrimaRepository : ITarifaMateriaPrimaRepository
    {
        private readonly IDbConnection connection;
        private readonly IDbTransaction? transaction;
        public TarifaMateriaPrimaRepository(IDbConnection connection, IDbTransaction? transaction)
        {
            this.connection = connection;
            this.transaction = transaction;
        }
        public async Task<int> Save(List<TarifaMateriaPrimaModel> tarifaMateriaPrima)
        {
            var id = await connection.ExecuteScalarAsync<int>("MateriaPrima.SaveTarifaMateriaPrima", new {  }, transaction, null, CommandType.StoredProcedure);
            return id;
        }
    }
}
