using Dapper;
using DeLaSur.Backend.Domain.Models;
using DeLaSur.Backend.Domain.Repositories;
using DeLaSur.Backend.Domain.Utils;
using DeLaSur.Backend.Infrastructure.UserDefinedTableTypes;
using Mapster;
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
        public async Task<TarifaMateriaPrimaModel> GetById(int id)
        {
            var tarifa = await connection.QueryFirstOrDefaultAsync<TarifaMateriaPrimaModel>("MateriaPrima.GetByIdTarifaMateriaPrima", new { Id = id }, transaction, null, CommandType.StoredProcedure);
            return tarifa;
        }
        public async Task Save(List<TarifaMateriaPrimaModel> tarifasMateriaPrima, int idFuente)
        {
            var tarifas = tarifasMateriaPrima.Adapt<List<TarifaMateriaPrimaUserDefinedTableType>>();
            await connection.ExecuteAsync("MateriaPrima.SaveTarifaMateriaPrima", new { Tarifas = tarifas.ToDataTable().AsTableValuedParameter(), IdFuente = idFuente }, transaction, null, CommandType.StoredProcedure);
        }
    }
}
