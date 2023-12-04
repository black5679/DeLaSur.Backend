using Dapper;
using DeLaSur.Backend.Domain.Models;
using DeLaSur.Backend.Domain.Repositories;
using DeLaSur.Backend.Domain.Utils;
using DeLaSur.Backend.Infrastructure.UserDefinedTableTypes;
using Mapster;
using System.Data;

namespace DeLaSur.Backend.Infrastructure.Repositories
{
    public class EntradaRepository : IEntradaRepository
    {
        private readonly IDbConnection connection;
        private readonly IDbTransaction? transaction;
        public EntradaRepository(IDbConnection connection, IDbTransaction? transaction)
        {
            this.connection = connection;
            this.transaction = transaction;
        }
        public async Task<int> Insert(EntradaModel entrada)
        {
            var detalles = entrada.Detalles.Adapt<List<DetalleEntradaUserDefinedTableType>>();
            var id = await connection.ExecuteScalarAsync<int>("Entrada.InsertEntrada", new { entrada.IdProveedor, entrada.UsuarioCreacion, Detalles = detalles.ToDataTable().AsTableValuedParameter() }, transaction, null, CommandType.StoredProcedure);
            return id;
        }
    }
}
