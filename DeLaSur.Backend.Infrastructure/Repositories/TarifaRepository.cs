using Dapper;
using DeLaSur.Backend.Domain.Models;
using DeLaSur.Backend.Domain.Repositories;
using DeLaSur.Backend.Domain.UoW;
using DeLaSur.Backend.Domain.Utils;
using DeLaSur.Backend.Infrastructure.Common;
using DeLaSur.Backend.Infrastructure.UserDefinedTableTypes;
using Mapster;
using System.Data;

namespace DeLaSur.Backend.Infrastructure.Repositories
{
    public class TarifaRepository : Repository, ITarifaRepository
    {
        public TarifaRepository(IDbSession db) : base(db) { }
        public async Task<TarifaModel?> GetById(int id)
        {
            var tarifa = await Connection.QueryFirstOrDefaultAsync<TarifaModel>("Material.GetTarifaById", new { IdTarifa = id }, Transaction, null, CommandType.StoredProcedure);
            return tarifa;
        }
        public async Task Save(List<TarifaModel> tarifas, int idFuente)
        {
            var tarifasList = tarifas.Adapt<List<TarifaUserDefinedTableType>>();
            await Connection.ExecuteAsync("Material.SaveTarifa", new { Tarifas = tarifasList.ToDataTable().AsTableValuedParameter(), IdFuente = idFuente }, Transaction, null, CommandType.StoredProcedure);
        }
    }
}
