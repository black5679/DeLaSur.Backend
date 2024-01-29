using Dapper;
using DeLaSur.Backend.Domain.Models;
using System.Data;

namespace DeLaSur.Backend.Domain.Repositories
{
    public class MateriaPrimaRepository : IMateriaPrimaRepository
    {
        private readonly IDbConnection connection;
        private readonly IDbTransaction? transaction;
        public MateriaPrimaRepository(IDbConnection connection, IDbTransaction? transaction)
        {
            this.connection = connection;
            this.transaction = transaction;
        }
        public async Task<int> Insert(MateriaPrimaModel materiaPrima)
        {
            var id = await connection.ExecuteScalarAsync<int>("Material.InsertMateriaPrima", new { materiaPrima.IdSubCategoriaMateriaPrima, materiaPrima.Material.Nombre, materiaPrima.Material.Descripcion, materiaPrima.Material.UsuarioCreacion }, transaction, null, CommandType.StoredProcedure);
            return id;
        }
    }
}
