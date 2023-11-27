using Dapper;
using DeLaSur.Backend.Domain.Models;
using DeLaSur.Backend.Domain.Repositories;
using DeLaSur.Backend.Infrastructure.UserDefinedTableTypes;
using Mapster;
using System.Data;
using DeLaSur.Backend.Domain.Utils;

namespace DeLaSur.Backend.Infrastructure.Repositories
{
    public class MateriaPrimaBovedaRepository : IMateriaPrimaBovedaRepository
    {
        private readonly IDbConnection connection;
        private readonly IDbTransaction? transaction;
        public MateriaPrimaBovedaRepository(IDbConnection connection, IDbTransaction? transaction)
        {
            this.connection = connection;
            this.transaction = transaction;
        }
        public async Task<int> Save(List<MateriaPrimaBovedaModel> materiasPrimasBoveda, int idBoveda, int usuarioCreacion)
        {
            var materiasPrimas = materiasPrimasBoveda.Adapt<List<MateriaPrimaBovedaUserDefinedTableType>>();
            var id = await connection.ExecuteScalarAsync<int>("Boveda.SaveMateriaPrimaBoveda", new { MateriasPrimas = materiasPrimas.ToDataTable().AsTableValuedParameter(), IdBoveda = idBoveda, UsuarioCreacion = usuarioCreacion }, transaction, null, CommandType.StoredProcedure);
            return id;
        }
    }
}
