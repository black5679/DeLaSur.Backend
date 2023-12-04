using Dapper;
using DeLaSur.Backend.Domain.Models;
using DeLaSur.Backend.Domain.Repositories;
using DeLaSur.Backend.Infrastructure.UserDefinedTableTypes;
using Mapster;
using System.Data;
using DeLaSur.Backend.Domain.Utils;

namespace DeLaSur.Backend.Infrastructure.Repositories
{
    public class MaterialBovedaRepository : IMaterialBovedaRepository
    {
        private readonly IDbConnection connection;
        private readonly IDbTransaction? transaction;
        public MaterialBovedaRepository(IDbConnection connection, IDbTransaction? transaction)
        {
            this.connection = connection;
            this.transaction = transaction;
        }
        public async Task<int> Save(List<MaterialBovedaModel> materialesBoveda, int usuarioCreacion)
        {
            var materiales = materialesBoveda.Adapt<List<MaterialBovedaUserDefinedTableType>>();
            var id = await connection.ExecuteScalarAsync<int>("Boveda.SaveMaterialBoveda", new { Materiales = materiales.ToDataTable().AsTableValuedParameter(), UsuarioCreacion = usuarioCreacion }, transaction, null, CommandType.StoredProcedure);
            return id;
        }
    }
}
