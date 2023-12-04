using Dapper;
using DeLaSur.Backend.Domain.Models;
using DeLaSur.Backend.Domain.Repositories;
using DeLaSur.Backend.Domain.Utils;
using DeLaSur.Backend.Infrastructure.UserDefinedTableTypes;
using Mapster;
using System.Data;

namespace DeLaSur.Backend.Infrastructure.Repositories
{
    public class TarifaRepository : ITarifaRepository
    {
        private readonly IDbConnection connection;
        private readonly IDbTransaction? transaction;
        public TarifaRepository(IDbConnection connection, IDbTransaction? transaction)
        {
            this.connection = connection;
            this.transaction = transaction;
        }
        public async Task<TarifaModel> GetById(int id)
        {
            var tarifa = await connection.QueryFirstOrDefaultAsync<TarifaModel>("Material.GetByIdTarifa", new { Id = id }, transaction, null, CommandType.StoredProcedure);
            return tarifa;
        }
        public async Task Save(List<TarifaModel> tarifas, int idFuente)
        {
            var tarifasList = tarifas.Adapt<List<TarifaUserDefinedTableType>>();
            await connection.ExecuteAsync("Material.SaveTarifa", new { Tarifas = tarifasList.ToDataTable().AsTableValuedParameter(), IdFuente = idFuente }, transaction, null, CommandType.StoredProcedure);
        }
    }
}
